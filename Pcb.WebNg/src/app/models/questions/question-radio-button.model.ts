import { QuestionBase } from './question-base.model';

export class RadioButtonQuestion extends QuestionBase<string> {
	controlType = 'radioButton';
	options: {key: string, value: string}[] = [];
	optionString = 'options';

	constructor(options: {} = {}) {
		super(options);
		this.options = options[this.optionString] || [];
	}
}
