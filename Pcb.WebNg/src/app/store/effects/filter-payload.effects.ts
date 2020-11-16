import { Injectable } from '@angular/core';
import { Actions, Effect, ofType } from '@ngrx/effects';
import { Action } from '@ngrx/store';
import { Observable, of } from 'rxjs';
// import { QueryFilterService } from '../../services/query-filter.service';

import * as filterPayloadActions from '../action/filter-payload.actions';
import { FilterQuery } from '../../models/filterQuery';
import { switchMap } from 'rxjs/internal/operators/switchMap';
import { map } from 'rxjs/internal/operators/map';

@Injectable()
export class FilterPayloadEffects {

	constructor(
		private actions$: Actions,
		// private queryFilterService: QueryFilterService
	) {}

@Effect()
	loadQueryFilter$: Observable<Action> = this.actions$.pipe(
		ofType(filterPayloadActions.FilterPayloadActionTypes.LoadFilterPayloads),
		switchMap(() => {
			return of({type: 'string'});
			// this.queryFilterService.currentData
			// 	.pipe(
			// 		map((query: FilterQuery) => {
			// 			return new filterPayloadActions.SetFilterPayLoad(query);
			// 		})
			// 	);
		})
	);
}
