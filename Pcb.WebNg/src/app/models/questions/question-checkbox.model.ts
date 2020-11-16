import { QuestionBase } from './question-base.model';

export class CheckBoxQuestion extends QuestionBase<string> {
  controlType = 'checkBox';
  type: boolean;
  optionString = 'type';

  constructor(options: {} = {}) {
	super(options);
	this.options = options[this.optionString] || [];
  }
}
