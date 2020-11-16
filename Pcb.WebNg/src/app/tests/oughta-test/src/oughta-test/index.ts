import {
	apply,
	applyTemplates,
	mergeWith,
	move,
	Rule,
	SchematicContext,
	Tree,
	url
} from '@angular-devkit/schematics';
import { EOL } from 'os';
import { Logger } from '@angular-devkit/core/src/logger';
import { normalize, basename, extname } from '@angular-devkit/core';
import { readClassNamesAndConstructorParams, readMaterialItemsUsed } from './read/read';

class SpecOptions {
	name: string;
}
// You don't have to export the function as default. You can also have more than one rule factory
// per file.
export function oughtaTest({ name }: SpecOptions): Rule {
	return (tree: Tree, context: SchematicContext) => {
		const logger = context.logger.createChild('oughta.index');
		logger.info(`Params: name: ${name}`);
		try {
			return createNewSpec(name, tree, logger);
		} catch (e) {
			e = e || {};
			logger.error(e.message || 'An error occurred');
			logger.debug(
				`---Error--- ${EOL}${e.message || 'Empty error message'} ${e.stack ||
					'Empty stack.'}`
			);
		}
	};
}

function createNewSpec(name: string, tree: Tree, logger: Logger) {
	const content = tree.read(name);
	const htmlContent = tree.read(name.slice(0, -2) + 'html');
	if (content == null) {
		logger.error(`The file ${name} is missing or empty.`);
	} else {
		// we aim at creating or updating a spec from the class under test (name)
		// for the spec name we'll need to parse the base file name and its extension and calculate the path

		// normalize the / and \ according to local OS
		// --name = ./example/example.component.ts -> example.component.ts
		const fileName = basename(normalize(name));
		// --name = ./example/example.component.ts -> ./example/example.component and the ext name -> .ts
		// for import { ExampleComponent } from "./example/example.component"
		const normalizedName = fileName.slice(0, fileName.length - extname(fileName).length);

		// the new spec file name
		const specFileName = `${normalizedName}.spec.ts`;

		const path = name.split(fileName)[0]; // split on the filename - so we get only an array of one item

		const { params, className, publicMethods } = parseClassUnderTestFile(name, content);
		const { materialItems, importMaterial } = readMaterialItemsUsed(parseMaterialHTMLItems(htmlContent));
		const templateSource = apply(url('./files'), [
			applyTemplates({
				// the name of the new spec file
				specFileName,
				normalizedName,
				className,
				publicMethods,
				declaration: toDeclaration(),
				provide: toProviders(),
				imports: toImports(),
				constructorParams: toConstructorParams(),
				params,
				materialItems,
				importMaterial
			}),
			move(path)
		]);

		return mergeWith(templateSource);
		/**
		 * End of the create function
		 * Below are the in-scope functions
		 */

		// functions defined in the scope of the else to use params and such
		// for getting called in the template - todo - just call the functions and get the result
		function toConstructorParams() {
			return params.map(p => p.name).join(',');
		}
		function toDeclaration() {
			return params
				.filter(ty => ty.type !== 'Router')
				.map(p =>
					p.type === 'FormBuilder'
						? `	const formBuilder: FormBuilder = new FormBuilder();`
						: `	const ${p.type.charAt(0).toLowerCase() + p.type.slice(1)}Spy: Spy<${p.type}> = autoSpy(${p.type});`
				)
				.join(EOL);
		}
		function toProviders() {
			return params
				.filter(ty => ty.type !== 'Router')
				.map(p => {
					if (p.type === 'FormBuilder') {
						return `\t\t\t\t{ provide: FormBuilder, useValue: formBuilder },`;
					}
					return `\t\t\t\t{ provide: ${p.type}, useValue: ${p.type.charAt(0).toLowerCase() + p.type.slice(1)}Spy },`;
				}
				)
				.join(EOL);
		}
		function toImports() {
			return params
				.filter(ty => ty.type === 'Router')
				.map(() => `\t\t\t\tRouterTestingModule.withRoutes([
					// { path: 'examplePath', component: MockComponent(ExampleComponent) },
					{ path: '**', redirectTo: '' }
				])`)
				.join(EOL);
		}
	}
}

function parseClassUnderTestFile(name: string, fileContents: Buffer) {
	const classDescriptions = readClassNamesAndConstructorParams(
		name,
		fileContents.toString('utf8')
	);
	// we'll take the first class with any number of constructor params or just the first if there are none
	const classWithConstructorParamsOrFirst =
		classDescriptions.filter(c => c.constructorParams.length > 0)[0] || classDescriptions[0];
	if (classWithConstructorParamsOrFirst == null) {
		throw new Error('No classes found to be spec-ed!');
	}
	const {
		constructorParams: params,
		name: className,
		publicMethods
	} = classWithConstructorParamsOrFirst;

	return { params, className, publicMethods };
}

function parseMaterialHTMLItems(fileContents: Buffer | null) {
	if (!fileContents) {
		return '';
	}
	return fileContents.toString('utf8');
}
