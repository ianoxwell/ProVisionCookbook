import * as ts from 'typescript';
import { EOL } from 'os';

/**
 * Will read the Abstract Syntax Tree of the `fileContents` and extract from that:
 *  * the names and types of all constructors' parameters
 *  * the names of all public method
 *  * the path to the dependencies
 * @example
 * class Test {
 *  constructor(service: MyService, param: string) { }
 *
 *  async future() {}
 *  now() {}
 * }
 * // result would be
 * {
 *  name: 'Test',
 *  constructorParams: [{name: 'service', type:'MyService', importPath:'../../my.service.ts'},
 * 		{name: 'param', type:'string', importPath: '-----no-import-path----'}],
 *  publicMethods: ['future', 'now']
 * }
 * @param fileName the name of the file (required by ts API)
 * @param fileContents contents of the file
 */
export function readClassNamesAndConstructorParams(
	fileName: string,
	fileContents: string
): ClassDescription[] {
	const sourceFile = ts.createSourceFile(fileName, fileContents, ts.ScriptTarget.ES2015, true);

	const res = read(sourceFile);
	const enrichedRes = res.map(r => ({
		...r,
		constructorParams: addImportPaths(r.constructorParams, fileContents)
	}));
	return enrichedRes;
}

export function readMaterialItemsUsed(fileContents: string): MaterialItems {
	// const sourceFile = parse5.parse(fileContents);
	// const res = read(sourceFile);
	let materialItems: string[] = [];
	let importMaterial: string[] = [];
	if (fileContents.includes('mat-icon')) {
		materialItems.push(`MatIconModule`);
		importMaterial.push(`import { MatIconModule } from '@angular/material/icon';`);
	}
	if (fileContents.includes('mat-toolbar')) {
		materialItems.push(`MatToolbarModule`);
		importMaterial.push(`import { MatToolbarModule } from '@angular/material/toolbar';`);
	}
	if (fileContents.includes('mat-tab')) {
		materialItems.push(`MatTabsModule`);
		importMaterial.push(`import { MatTabsModule } from '@angular/material/tabs';`);
	}
	if (fileContents.includes('mat-button') || fileContents.includes('mat-flat-button') || fileContents.includes('mat-raised-button')) {
		materialItems.push(`MatButtonModule`);
		importMaterial.push(`import { MatButtonModule } from '@angular/material/button';`);
	}
	if (fileContents.includes('mat-form-field')) {
		materialItems.push(`ReactiveFormsModule`, `MatFormFieldModule`, `MatInputModule`);
		importMaterial.push(`import { ReactiveFormsModule } from '@angular/forms';`,
			`import { MatFormFieldModule } from '@angular/material/form-field';`,
			`import { MatInputModule } from '@angular/material/input';`);
	}
	// mat-select
	if (fileContents.includes('mat-select')) {
		materialItems.push(`MatSelectModule`);
		importMaterial.push(`import { MatSelectModule } from '@angular/material/select';`);
	}
	// mat-checkbox
	if (fileContents.includes('mat-checkbox')) {
		materialItems.push(`MatCheckboxModule`);
		importMaterial.push(`import { MatCheckboxModule } from '@angular/material/checkbox';`);
	}
	// date-picker
	if (fileContents.includes('mat-datepicker')) {
		materialItems.push(`MatDatepickerModule`);
		importMaterial.push(`import { MatDatepickerModule } from '@angular/material/datepicker';`);
	}
	// mat-divider
	if (fileContents.includes('mat-divider')) {
		materialItems.push(`MatDividerModule`);
		importMaterial.push(`import { MatDividerModule } from '@angular/material/divider';`);
	}
	// mat-chips
	if (fileContents.includes('mat-chip')) {
		materialItems.push(`MatChipsModule`);
		importMaterial.push(`import { MatChipsModule } from '@angular/material/chips';`);
	}
	// mat-autocomplete
	if (fileContents.includes('mat-chip')) {
		materialItems.push(`MatAutocompleteModule`);
		importMaterial.push(`import { MatAutocompleteModule } from '@angular/material/autocomplete';`);
	}
	// MatCardModule
	if (fileContents.includes('mat-card')) {
		materialItems.push(`MatCardModule`);
		importMaterial.push(`import { MatCardModule } from '@angular/material/card';`);
	}
	// mat-table
	if (fileContents.includes('mat-table')) {
		materialItems.push(`MatTableModule`, `MatSortModule`, `MatPaginatorModule`);
		importMaterial.push(`import { MatTableModule } from '@angular/material/table';`,
			`import { MatSortModule } from '@angular/material/sort';`,
			`import { MatPaginatorModule } from '@angular/material/paginator';`);
	}
	// mat-menu
	if (fileContents.includes('mat-menu')) {
		materialItems.push(`MatMenuModule`);
		importMaterial.push(`import { MatMenuModule } from '@angular/material/menu';`);
	}
	if (materialItems.length > 0) {
		materialItems = materialItems.map(item => `\t\t\t\t${item},${EOL}`);
		importMaterial = importMaterial.map(item => `${item}${EOL}`);
		materialItems.push(`\t\t\t\tNoopAnimationsModule,`);
		importMaterial.push(`import { NoopAnimationsModule } from '@angular/platform-browser/animations';`);
	}
	return { materialItems, importMaterial };
}

function read(node: ts.Node) {
	let result: ClassDescription[] = [];
	if (node.kind === ts.SyntaxKind.ClassDeclaration) {
		const classDeclaration = node as ts.ClassDeclaration;
		result = [
			{
				name: classDeclaration.name != null ? classDeclaration.name.getText() : 'default',
				constructorParams: readConstructorParams(node as ts.ClassDeclaration),
				publicMethods: readPublicMethods(node as ts.ClassDeclaration)
			}
		];
	}

	ts.forEachChild(node, n => {
		const r = read(n);
		if (r && r.length > 0) {
			result = result.concat(r);
		}
	});

	return result;
}

function readConstructorParams(node: ts.ClassDeclaration): ConstructorParam[] {
	let params: ConstructorParam[] = [];

	// tslint:disable-next-line: no-shadowed-variable
	ts.forEachChild(node, node => {
		if (node.kind === ts.SyntaxKind.Constructor) {
			const constructor = node as ts.ConstructorDeclaration;

			params = constructor.parameters.map(p => ({
				name: p.name.getText(),
				type: (p.type && p.type.getText()) || 'any' // the type of constructor param or any if not passed
			}));
		}
	});
	return params;
}

function readPublicMethods(node: ts.ClassDeclaration): string[] {
	const publicMethods: string[] = [];

	// tslint:disable-next-line: no-shadowed-variable
	ts.forEachChild(node, node => {
		if (node.kind === ts.SyntaxKind.MethodDeclaration) {
			const method = node as ts.MethodDeclaration;

			if (methodIsPublic(method)) {
				publicMethods.push(method.name.getText());
			}
		}
	});
	return publicMethods;
}

function methodIsPublic(methodNode: ts.MethodDeclaration) {
	const flags = ts.getCombinedModifierFlags(methodNode);
	// check if the private flag is part of this binary flag - if not means the method is public
	return (
		(flags && ts.ModifierFlags.Private) !== ts.ModifierFlags.Private &&
		(flags && ts.ModifierFlags.Protected) !== ts.ModifierFlags.Protected
	);
}

function addImportPaths(params: ConstructorParam[], fullText: string) {
	return params.map(p => {
		const match = fullText.match(new RegExp(`import.*${p.type}.*from.*('|")(.*)('|")`)) || [];
		return { ...p, importPath: match[2] }; // take the 2 match     1-st^^^  ^^2-nd
	});
}
export interface ClassDescription {
	name: string;
	constructorParams: ConstructorParam[];
	publicMethods: string[];
}

export interface MaterialItems {
	materialItems: string[];
	importMaterial: string[];
}

export interface ConstructorParam {
	name: string;
	type: string;
	importPath?: string;
}
