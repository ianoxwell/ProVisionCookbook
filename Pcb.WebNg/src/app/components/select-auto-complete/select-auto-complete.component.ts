// based on Maloths Naresh's work  - https://medium.com/@cryptoipl/angular-material-multi-select-with-autocomplete-113065d58dab
import { Component, OnInit, Input, Output, EventEmitter, OnChanges } from '@angular/core';
import { FormControl } from '@angular/forms';
import { MatCheckbox } from '@angular/material/checkbox';
import { MatSelect } from '@angular/material/select';

@Component({
	selector: 'app-select-auto-complete',
	templateUrl: './select-auto-complete.component.html',
	styleUrls: ['./select-auto-complete.component.scss']
})
export class SelectAutoCompleteComponent implements OnChanges {

	@Input() disabled = false;
	@Input() control: FormControl;
	@Input() errorMsg = '';
	@Input() showErrorMsg = false;
	@Input() multiple = true;
	@Input() labelLength = 30;
	@Input() display = 'title';
	@Input() value = 'id';
	@Input() placeholder: string;
	@Input() selectedOptions = []; // array of values that have been selected
	@Input() options = []; // main array of values - usually value pair [{id: number, key: string}]
	@Input() allowSelectAll = false;

	@Output() selectionChange = new EventEmitter();

	displayString = '';
	filteredOptions = [];
	selectAllChecked = false;

	constructor() { }

	ngOnChanges() {
		this.filteredOptions = this.options;
		if (this.selectedOptions) {
			this.control.patchValue( this.selectedOptions );
		}
	}

	deselectAll(): void {
		this.control.patchValue(null);
	}

	toggleSelectAll(val: boolean): void {
		if (val) {
			this.filteredOptions.forEach((option) => {
				if (!this.control.value.includes(option[this.value])) {
					this.control.patchValue( this.control.value.concat(option[this.value]) );
				}
			});
		} else {
			const filteredValues1 = this.getFilteredOptionsValues();
			this.control.patchValue( this.control.value.filter((item) => !filteredValues1.includes(item)) );
		}
		this.selectionChange.emit(this.control.value);
	}

	filterItem(value: string): void {
		this.filteredOptions = this.options.filter((item) => {
			return (!!item[this.display]) ? item[this.display].toLowerCase().indexOf(value.toLowerCase()) > -1 : false;
		});
		this.selectAllChecked = true;
		this.filteredOptions.forEach((item) => {
			if (this.control.value && !this.control.value.includes(item[this.value])) {
				this.selectAllChecked = false;
			}
		});
	}

	getFilteredOptionsValues(): any[] {
			const filteredValues = [];
			this.filteredOptions.forEach(option => {
				filteredValues.push(option[this.value]);
			});
			return filteredValues;
	}

	onDisplayString(): string {
		this.displayString = '';
		if (this.control.value && this.control.value.length) {
			let displayOption = [];
			let numberLabels = 0;
			if (this.multiple) {
				displayOption = this.options.filter((option) => this.control.value.includes(option[this.value]));
				if (displayOption.length) {
					displayOption.every((item, ind) => {
						if (item && this.displayString.length + item[this.display].length < this.labelLength )  {
							this.displayString += item[this.display] + ', ';
							numberLabels ++;
						}
						return this.displayString.length < ( this.labelLength );
					});
					this.displayString = this.displayString.slice(0, -2);
					if ( this.control.value.length - numberLabels > 0) {
						this.displayString += ' (+' + (this.control.value.length - numberLabels) + ' others)';
					}
				}
			} else {
				// Single select display
				displayOption = this.options.filter((option) => option.value === this.control.value);
				if (displayOption.length) {
					this.displayString = displayOption[0][this.display];
				}
			}
		}
		return this.displayString;
	}


	onSelectionChange(val: MatSelect) {
		const filteredValues = this.getFilteredOptionsValues();
		let count = 0;
		if (this.multiple && this.control.value) {
			this.control.value.filter((item) => {
				if (filteredValues.includes(item)) {
					count++;
				}
			});
			this.selectAllChecked = count === this.filteredOptions.length;
		}
		this.control.patchValue( val.value );
		this.selectionChange.emit(this.control.value);
	}

}
