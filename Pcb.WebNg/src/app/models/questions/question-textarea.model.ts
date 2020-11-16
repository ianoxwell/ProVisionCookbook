import { QuestionBase } from './question-base.model';

export class TextAreaQuestion extends QuestionBase<string> {
  controlType = 'textArea';
  type: string;
  optionString = 'type';

  constructor(options: {} = {}) {
	super(options);
	this.type = options[this.optionString] || [];
  }
}
