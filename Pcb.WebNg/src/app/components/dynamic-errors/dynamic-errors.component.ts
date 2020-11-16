import { Component, OnInit, Input } from '@angular/core';
import { Validations } from '../../models/common.model';
import { FormControl } from '@angular/forms';

@Component({
  selector: 'app-dynamic-errors',
  templateUrl: './dynamic-errors.component.html',
  styleUrls: ['./dynamic-errors.component.scss']
})
export class DynamicErrorsComponent implements OnInit {
  @Input() validation: Validations;
  @Input() formControlItem: FormControl;

  constructor() { }

  ngOnInit(): void {
  }

}
