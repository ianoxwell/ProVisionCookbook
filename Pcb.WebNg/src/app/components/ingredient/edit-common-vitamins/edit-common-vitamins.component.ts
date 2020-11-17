import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { DecimalThreePlaces, DecimalTwoPlaces } from '@models/static-variables';

@Component({
  selector: 'app-edit-common-vitamins',
  templateUrl: './edit-common-vitamins.component.html',
  styleUrls: ['./edit-common-vitamins.component.scss']
})
export class EditCommonVitaminsComponent implements OnInit {
	@Input() form: FormGroup;
	@Output() markAsDirty = new EventEmitter<void>();

	decimalTwoPlaces = DecimalTwoPlaces;
	decimalThreePlaces = DecimalThreePlaces;
	constructor() { }

	ngOnInit() {
	}

}
