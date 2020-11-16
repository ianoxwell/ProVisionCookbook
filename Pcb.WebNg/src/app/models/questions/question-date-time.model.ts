import { QuestionBase } from './question-base.model';
export class DateTimeQuestion extends QuestionBase<string> {
	controlType = 'dateTime';
	type: boolean;
	optionString = 'type';
	constructor(options: {} = {}) {
		super(options);
		this.type = options[this.optionString] || false;
	}
}
