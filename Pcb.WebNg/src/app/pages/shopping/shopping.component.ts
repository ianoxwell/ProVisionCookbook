import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';

@Component({
  selector: 'app-shopping',
  templateUrl: './shopping.component.html',
  styleUrls: ['./shopping.component.scss'],
})
export class ShoppingComponent implements OnInit {

  form: FormGroup;
  payLoad = '';

  constructor() { }

  ngOnInit() {

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
