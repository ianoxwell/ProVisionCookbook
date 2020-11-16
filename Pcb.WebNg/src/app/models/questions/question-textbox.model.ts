import { QuestionBase } from './question-base.model';

export class TextboxQuestion extends QuestionBase<string> {
  controlType = 'textbox';
  type: string;
  optionString = 'type';

  constructor(options: {} = {}) {
	super(options);
	this.type = options[this.optionString] || '';
  }
}
