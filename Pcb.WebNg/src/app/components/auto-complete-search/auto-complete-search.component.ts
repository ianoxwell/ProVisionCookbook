import { AfterContentInit, Component, EventEmitter, Input, OnChanges, Optional, Output, Self, SimpleChanges, ViewChild } from '@angular/core';
import { AbstractControl, ControlValueAccessor, FormControl, NgControl } from '@angular/forms';
import { MatAutocompleteTrigger } from '@angular/material/autocomplete';
import { ErrorStateMatcher } from '@angular/material/core';
import { ComponentBase } from '@components/base/base.component.base';
import { ReferenceItem } from '@models/reference.model';
import { isObservable, Observable, of } from 'rxjs';
import { filter, takeUntil, tap } from 'rxjs/operators';

@Component({
  selector: 'app-auto-complete-search',
  templateUrl: './auto-complete-search.component.html',
  styleUrls: ['./auto-complete-search.component.scss']
})
export class AutoCompleteSearchComponent extends ComponentBase implements ControlValueAccessor, AfterContentInit, OnChanges  {

	// Important inputs
	@Input() placeholder: string;
	@Input() matHint: string;

	// Function to format the display of the ref items.
	@Input() displayWith: (item: ReferenceItem) => string = ((i: ReferenceItem) => i?.title);

	@Input() values: Observable<ReferenceItem[]> | ReferenceItem[];
	@Output() filterChange = new EventEmitter<string>();

	// Gets a reference to the MatAutocompleteTrigger.
	@ViewChild(MatAutocompleteTrigger, { read: MatAutocompleteTrigger, static: true}) auto: MatAutocompleteTrigger;

	// custom error matcher to link the input to the error state of the control
	readonly errorStateMatcher: ErrorStateMatcher = {
		isErrorState: () => (this.control && this.control.invalid && this.control.touched)
	};

	// Copy of '@Input() values' guaranteed to be an actual observable (as opposed to the 'maybe observable maybe sync data' @Input() values)
	values$: Observable<ReferenceItem[]>;

	filterControl = new FormControl();
	control: AbstractControl;
	// tslint:disable-next-line: no-input-rename
	@Input('value') _value: ReferenceItem;
	onChange: any = () => {};
	onTouched: any = () => {};

	get value() {
		return this._value;
	}

	set value(val) {
		this._value = val;
		this.onChange(val);
		this.onTouched();
	}

	constructor(
		@Optional() @Self() public ngControl: NgControl
	) {
		super();
		if (!!ngControl) {
			// Setting the value accessor directly (instead of using
			// the providers) to avoid running into a circular import.
			ngControl.valueAccessor = this;
		}
	}

	ngAfterContentInit(): void {
		this.control = this.ngControl?.control;
		this.getWatchFilterText(this.filterControl.valueChanges).subscribe();
		this.resetFilterValue(this.control.valueChanges).subscribe();
	}
	ngOnChanges(changes: SimpleChanges): void {
		const values = changes.values;
		if (values && values.currentValue !== values.previousValue) {
			this.values$ = isObservable(this.values) ? this.values : of(this.values);
		}
	}

	registerOnChange(fn): void {
		this.onChange = fn;
	}

	writeValue(value): void {
		this.value = value;
	}

	registerOnTouched(fn): void {
		this.onTouched = fn;
	}

	setDisabledState(isDisabled: boolean): void {
		if (isDisabled) {
			this.filterControl.disable();
		} else {
			this.filterControl.enable();
		}
	}

	onBlur(): void {
		// When the user blurs our of the control we need to ensure that the filterControl holds the currently selected text.
		// The set timeout ensures that the users 'click' event to select a new ref item goes through first.
		// Otherwise the filter will have updated by the time the autocomplete goes to check the item,
		// and we'll lose the selected item.

		// commented out for now
		console.log('auto-complete blur', this.filterControl.value);
		// setTimeout(() => {
		// 	// If the user clears out the filter, and there is an existing value, we clear the value.
		// 	if (!this.filterControl.value?.length && this.value) {
		// 		this.value = null;
		// 	}
		// 	this.resetFilterControlValue(this.value);
		// }, 500);
		// this.onTouched();
	}

	// Watches for changes to the filter text and emits.
	getWatchFilterText(filterValue$: Observable<string>): Observable<any> {
		return filterValue$.pipe(
			filter(filterValue => typeof filterValue === 'string'), // There's a tendency for the autocomplete to shove ref items down the pipe...
			tap(filterValue => this.filterChange.emit(filterValue)),
			takeUntil(this.ngUnsubscribe)
		);
	}

	// Resets the filter text when the selected object changes.
	resetFilterValue(value$: Observable<ReferenceItem>): Observable<any> {

		const result$ = value$.pipe(
			tap(item => this.resetFilterControlValue(item)),
			takeUntil(this.ngUnsubscribe)
		);

		return result$;
	}

	onSelect(value: ReferenceItem): void {
		this.value = value;
		// this.control.setValue(value);
		// this.control.markAsDirty();
	}

	/* Makes the autocomplete options list appear when the user clicks on the input field.
	 * By default the options only appear when the input gains focus, so the user
	 * would have to click outside the input and then click back into the input.
	 */
	onInputClick(): void {
		if (!this.auto.panelOpen) {
			this.filterChange.emit(this.filterControl.value);
			this.auto.openPanel();
		}
	}

	private resetFilterControlValue(item: ReferenceItem): void {
		const text = this.displayWith(item) ?? '';
		this.filterControl.setValue(text);
	}

}
