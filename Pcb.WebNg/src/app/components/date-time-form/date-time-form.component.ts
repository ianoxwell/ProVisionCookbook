/* note combination of https://coryrylan.com/blog/angular-custom-form-controls-with-reactive-forms-and-ngmodel for the formControl
	plus modification from https://stackoverflow.com/questions/48649987/angular-material-datetime-picker-component CularBytes comment
*/

import { Component, Input, forwardRef, HostBinding, AfterContentInit } from '@angular/core';
import { MatDatepickerInputEvent } from '@angular/material/datepicker';
import {MAT_MOMENT_DATE_FORMATS, MomentDateAdapter} from '@angular/material-moment-adapter';
import {DateAdapter, MAT_DATE_FORMATS, MAT_DATE_LOCALE} from '@angular/material/core';
import { ControlValueAccessor, NG_VALUE_ACCESSOR } from '@angular/forms';

import * as moment_ from 'moment';

const moment = moment_;

import { MAT_MOMENT_DATE_ADAPTER_OPTIONS } from '@angular/material-moment-adapter';
import { FormControl, FormGroup } from '@angular/forms';
import { Validations, HourMin } from '../../models/common.model';


class DateConfig {
  startView: 'month' | 'year' | 'multi-year';
  touchUi: boolean;
  minDate: moment_.Moment;
  maxDate: moment_.Moment;
}

@Component({
  selector: 'app-date-time-form',
  templateUrl: './date-time-form.component.html',
  styleUrls: ['./date-time-form.component.scss'],
  providers: [
		{provide: DateAdapter, useClass: MomentDateAdapter, deps: [MAT_DATE_LOCALE]},
		{provide: MAT_DATE_FORMATS, useValue: MAT_MOMENT_DATE_FORMATS},
		{
			provide: NG_VALUE_ACCESSOR,
			useExisting: forwardRef(() => DateTimeFormComponent),
			multi: true
		}
	]
})
export class DateTimeFormComponent implements ControlValueAccessor, AfterContentInit {
  @HostBinding('attr.id')
	externalId = '';
	@Input() disabled: boolean;
	@Input() labelDate: string;
	@Input() externalClass: string;
	@Input() internalClass: string;
	@Input() purpose: string;
	@Input() dateOnly: boolean;
	@Input() validationMessages: Validations;

  public dateForm: FormControl;
  public timeFormGroup: FormGroup;
  public endTime: FormControl;

  public momentDate: moment_.Moment;
  public timeSet: HourMin;
  public config: DateConfig;

  @Input()
	set id(value: string) {
		this._ID = value;
		this.externalId = null;
	}
	get id() {
		return this._ID;
	}
	private _ID = '';
	// tslint:disable-next-line: no-input-rename
	@Input('value') valued: Date;
	onChange: any = () => {};
	onTouched: any = () => {};
	get value() {
		return this.valued;
	}
	set value(val) {
		this.valued = val;
		this.onChange(val);
		this.onTouched();
	}

  constructor(private adapter: DateAdapter<any>) { }

  ngAfterContentInit(): void {
		this.initialiseDateTime();
	}
	registerOnChange(fn): void {
		this.onChange = fn;
	}
	writeValue(value): void {
		if (value) {
			this.value = value;
		}
	}
	registerOnTouched(fn): void {
		this.onTouched = fn;
	}

 /*
	*	Date and time methods
	*/
	initialiseDateTime(): void {
		this.adapter.setLocale('en-au');
		this.config = new DateConfig();
		if (this.purpose === 'birthday') {
			this.config.startView = 'multi-year';
			this.config.maxDate = moment().add(-15, 'year');
			this.config.minDate = moment().add(-90, 'year' );
			this.dateOnly = true;
		} else {
			this.config.startView = 'month';
			this.config.maxDate = moment().add(100, 'year');
			this.config.minDate = moment().add(-100, 'year');
		}
		if (window.screen.width < 767) {
			this.config.touchUi = true;
		}
		if (this.value) {
			const mom = moment(this.value);
			if (mom.isBefore(moment('1900-01-01'))) {
			this.momentDate = moment();
			} else {
			this.momentDate = mom;
			}
		} else {
			this.momentDate = moment();
		}
		if (this.momentDate.minute() % 5 !== 0 && !this.dateOnly) {
			this.momentDate.minute(Math.ceil(this.momentDate.minute() / 5) * 5).second(0);
			this.value = this.momentDate.toDate();
		}
		this.dateForm = new FormControl(this.momentDate);
		if (this.disabled) {
			this.dateForm.disable();
		}
		this.endTime = new FormControl(this.momentDate.format('HH:mm'));
		this.timeFormGroup = new FormGroup({
			endTime: this.endTime
		});
		this.timeSet = this.setTimes();
	}
	public dateChange(date: MatDatepickerInputEvent<any>) {
		if (moment.isMoment(date.value)) {
			this.momentDate = moment(date.value);
			if (this.dateOnly) {
				this.momentDate = this.momentDate.utc(true);
			} else {
				this.momentDate.hour(this.timeSet.hours).minute(this.timeSet.minutes).second(0);
			}
			const newDate = this.momentDate.toDate();
			this.value = newDate;
		}
	}
	public timeChange(time: string) {
		function hours12to24(h: number, pm: boolean) {
			return h === 12 ? pm ? 12 : 0 : pm ? h + 12 : h;
		}
		const splitTime = time.slice(0, -3).split(':');
		let hour = Number(splitTime[0]);
		const minute = Number(splitTime[1]);
		if (time.indexOf('PM') > -1) {
			hour = hours12to24(hour, true);
		}
		console.log('time change', time, minute);
		this.momentDate = this.momentDate.hour(hour).minute(minute).second(0);
		this.timeSet = this.setTimes();
		const newDate = this.momentDate.toDate();
		this.value = newDate;
	}
	setTimes(): HourMin {
		return {
			hours: this.momentDate.hours(),
			minutes: this.momentDate.minutes()
		};
	}

}
