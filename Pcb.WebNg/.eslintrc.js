const { join } = require("path");
module.exports = {
	parser: '@typescript-eslint/parser', // Specifies the ESLint parser
	extends: [
		'plugin:@typescript-eslint/recommended', // Uses the recommended rules from the @typescript-eslint/eslint-plugin
		'prettier/@typescript-eslint', // Uses eslint-config-prettier to disable ESLint rules from @typescript-eslint/eslint-plugin that would conflict with prettier
		'plugin:prettier/recommended', // Enables eslint-plugin-prettier and eslint-config-prettier. This will display prettier errors as ESLint errors. Make sure this is always the last configuration in the extends array.
		'plugin:rxjs/recommended' // May need to be modified - https://github.com/cartant/eslint-plugin-rxjs
	],
	ignorePatterns: ['msal.config.json'], // Prevents the error 'Parsing error: "parserOptions.project" has been set for @typescript-eslint/parser'
	parserOptions: {
		ecmaVersion: 2020, // Allows for the parsing of modern ECMAScript features
		project: [join(__dirname, "./tsconfig.json")],
		sourceType: 'module', // Allows for the use of imports
		extraFileExtensions: ['.config.json', '.json'], // Allows for the use of .config.json and .json file extensions - REQUIRED FOR MSAL AUTHENTICATION
	},
	rules: {
		// Place to specify ESLint rules. Can be used to overwrite rules specified from the extended configs
	}
};
