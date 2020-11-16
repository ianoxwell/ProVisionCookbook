import {
	apply,
	applyTemplates,
	mergeWith,
	Rule,
	SchematicContext,
	Tree,
	url,
	move
} from '@angular-devkit/schematics';

export class AutoSpyOptions {
	path = '.';
}

export default function(options: AutoSpyOptions): Rule {
	// tslint:disable-next-line: variable-name
	return (_tree: Tree, _context: SchematicContext) => {
		const source = apply(url(`./files`), [applyTemplates({}), move(options.path)]);
		return mergeWith(source);
	};
}
