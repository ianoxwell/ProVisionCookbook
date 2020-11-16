import { QuestionBase } from './question-base.model';

export class DropdownQuestion extends QuestionBase<string> {
	controlType = 'dropdown';
	options: {key: string, value: string}[] = [];
	optionString = 'options';

	constructor(options: {} = {}) {
		super(options);
		this.options = options[this.optionString] || [];
	}
}
