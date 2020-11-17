import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { DecimalThreePlaces, DecimalTwoPlaces } from '@models/static-variables';

@Component({
  selector: 'app-edit-common-minerals',
  templateUrl: './edit-common-minerals.component.html',
  styleUrls: ['./edit-common-minerals.component.scss']
})
export class EditCommonMineralsComponent implements OnInit {

	@Input() form: FormGroup;
	@Output() markAsDirty = new EventEmitter<void>();

	decimalTwoPlaces = DecimalTwoPlaces;
	decimalThreePlaces = DecimalThreePlaces;
	constructor() { }

	ngOnInit() {
	}

}
