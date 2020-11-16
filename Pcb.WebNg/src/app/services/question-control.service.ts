import { Injectable } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';

import { QuestionBase } from '../models/questions/question-base.model';
import { QuestionArray } from '../models/common.model';

@Injectable()
export class QuestionControlService {
  constructor() { }

  createLayeredFormGroup(questionArray: Array<QuestionArray>): FormGroup {
	const group: any = {};

	questionArray.forEach(item => {
	  if (!item.isChild) {
		item.questions.forEach(question => {
		  group[question.key] = this.someNameHere(question);
		});
	  } else {
		group[item.key] = this.toFormGroup(item.questions);
	  }

	});
	console.log('group', group);
	return new FormGroup(group);
  }

  someNameHere(question) {
	const validators = [];
	if (question.validators && Object.keys(question.validators).length > 0) {
	  Object.keys(question.validators).filter(item => !!question.validators[item]).forEach(item => {
		if (item === 'required') {
		  validators.push (Validators.required);
		} else {
		  validators.push (Validators[item](question.validators[item]));
		}
	  });
	}
	return validators.length > 0 ? new FormControl(question.value || '', validators)
										  : new FormControl(question.value || '');
  }

  toFormGroup(questions: QuestionBase<string>[] ) {
	const group: any = {};

	questions.forEach(question => {
	  group[question.key] = this.someNameHere(question);
	});
	return new FormGroup(group);
  }
}
