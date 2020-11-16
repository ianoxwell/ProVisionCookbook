import { Component, Input, OnInit } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';

import { QuestionBase } from '../../models/questions/question-base.model';
import { QuestionControlService } from '../../services/question-control.service';

import { DropdownQuestion } from '../../models/questions/question-dropdown.model';
import { TextboxQuestion } from '../../models/questions/question-textbox.model';
import { TextAreaQuestion } from '../../models/questions/question-textarea.model';
import { RadioButtonQuestion } from '../../models/questions/question-radio-button.model';
import { CheckBoxQuestion } from '../../models/questions/question-checkbox.model';
import { QuestionArray } from '../../models/common.model';
import { DateTimeQuestion } from '../../models/questions/question-date-time.model';

@Component({
  selector: 'app-shopping',
  templateUrl: './shopping.component.html',
  styleUrls: ['./shopping.component.scss'],
  providers: [ QuestionControlService ]
})
export class ShoppingComponent implements OnInit {


  outerQuestions: QuestionBase<string>[] = [
	new DropdownQuestion({
		key: 'brave',
		label: 'Bravery Rating',
		options: [
		{key: 'solid',  value: 'Solid'},
		{key: 'great',  value: 'Great'},
		{key: 'good',   value: 'Good'},
		{key: 'unproven', value: 'Unproven'}
		],
		order: 3
	}),

	new RadioButtonQuestion({
		key: 'bravery',
		label: 'Bravery Rating',
		options: [
		{key: 'solid',  value: 'Solid'},
		{key: 'great',  value: 'Great'},
		{key: 'good',   value: 'Good'},
		{key: 'unproven', value: 'Unproven'}
		],
		order: 4
	}),

	new CheckBoxQuestion({
		key: 'certified',
		label: 'Certified',
		value: true,
		order: 6
	}),

	new TextboxQuestion({
		key: 'firstName',
		label: 'First name',
		value: 'Bombasts',
		validators: {required: true},
		order: 1
	}),

	new TextAreaQuestion({
		key: 'description',
		label: 'About you',
		order: 5
	}),

	new TextboxQuestion({
		key: 'emailAddress',
		label: 'Email',
		type: 'email',
		validators: {required: true, minLength: 2},
		validationMessages: [
		{ type: 'required', message: 'Your Name is <strong>required</strong>' },
		{ type: 'minlength', message: 'Your Name is a little longer' },
		{ type: 'maxlength', message: 'Is your Name really THAT long?' },
		{ type: 'pattern', message: 'Your username must contain only numbers and letters' }
		],
		order: 2
	}),

	new DateTimeQuestion({
		key: 'dateTimeBooking',
		label: 'Book Recipe',
		validators: {required: true},
		order: 7,
		outerClass: 'flex-box flex-row'
	})
  ];

  childQuestion: QuestionBase<string>[] = [
	new TextboxQuestion({
		key: 'otherName',
		label: 'First name',
		value: 'Bombasts',
		validators: {required: true},
		order: 1
	}),

	new TextAreaQuestion({
		key: 'shirtDescription',
		label: 'About you',
		order: 5
	}),

	new TextboxQuestion({
		key: 'secretAddress',
		label: 'Email',
		type: 'email',
		validators: {required: true, minLength: 2},
		validationMessages: [
		{ type: 'required', message: 'Your Name is <strong>required</strong>' },
		{ type: 'minlength', message: 'Your Name is a little longer' },
		{ type: 'maxlength', message: 'Is your Name really THAT long?' },
		{ type: 'pattern', message: 'Your username must contain only numbers and letters' }
		],
		order: 2
	})
  ];

  questions: QuestionArray[] = [
	{
		key: 'parent',
		label: 'First Layer',
		order: 1,
		isChild: false,
		questions: this.outerQuestions
	},
	{
		key: 'innerQuestions',
		label: 'Inner Items',
		order: 2,
		isChild: true,
		questions: this.childQuestion
	}
  ];

  form: FormGroup;
  payLoad = '';

  constructor(private qcs: QuestionControlService) {  }

  ngOnInit() {
	this.form = this.qcs.createLayeredFormGroup(this.questions.sort((a, b) => a.order - b.order));
	console.log('the form', this.form, this.questions);
  }

  patchForm(patchObject) {
	this.form.patchValue(patchObject);
  }

  onSubmit() {
	this.payLoad = JSON.stringify(this.form.getRawValue());
	console.log('payload right', this.payLoad, this.form);
	this.patchForm({brave: 'solid', emailAddress: 'cat@dog.com', firstName: 'Steve', innerQuestions: {otherName: 'Harry'}});
  }

  groupOrControl(item: FormControl | FormGroup): boolean {
	console.log('item', item, Object.keys(item));
	return true;
  }

}
