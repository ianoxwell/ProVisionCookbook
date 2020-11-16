import { HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { MeasurementModel } from '@models/ingredient-model';
import { ReferenceAll } from '@models/reference.model';
import { BehaviorSubject, Observable, of } from 'rxjs';
import { catchError, map } from 'rxjs/operators';
import { RefDataService } from './ref-data.service';

@Injectable()
export class ReferenceService {
	private refAllSubject$ = new BehaviorSubject<ReferenceAll>(null);

	private measurementSubject$ = new BehaviorSubject<Array<MeasurementModel>>(null);

	constructor(
		private refDataService: RefDataService
	) { }

	getAllReferences(): Observable<ReferenceAll> {
		return (!!this.refAllSubject$.value) ? this.refAllSubject$.asObservable() : this.setRefAll();
	}

	setRefAll(): Observable<ReferenceAll> {
		return this.refDataService.getAllReferences().pipe(
			map((result: ReferenceAll) => {
				this.refAllSubject$.next(result);
				return result;
			}),
			catchError((err: HttpErrorResponse) => {
				console.log('Error getting all reference Data', err);
				return of({});
			})
		);
	}

	getMeasurements(): Observable<Array<MeasurementModel>> {
		return (!!this.measurementSubject$.value) ? this.measurementSubject$.asObservable() : this.setMeasurements();
	}

	setMeasurements(): Observable<Array<MeasurementModel>> {
		return this.refDataService.getMeasurements().pipe(
			map((result: MeasurementModel[]) => {
				this.measurementSubject$.next(result);
				return result;
			}),
			catchError((err: HttpErrorResponse) => {
				console.log('Error getting measurement Data', err);
				return of([]);
			})
		);
	}

}
