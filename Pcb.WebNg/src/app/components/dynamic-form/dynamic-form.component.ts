import { Component, Input, OnInit } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { QuestionBase } from '../../models/questions/question-base.model';

@Component({
  selector: 'app-dynamic-question',
  templateUrl: './dynamic-form.component.html',
  styleUrls: ['./dynamic-form.component.scss']
})
export class DynamicFormComponent implements OnInit {
  @Input() question: QuestionBase<string>;
  @Input() form: FormGroup;
  get isValid() { return this.form.controls[this.question.key].valid; }
  get formControlItem() { return this.form.get( this.question.key.toString()); }
  constructor() { }

  ngOnInit(): void {
  }

}
