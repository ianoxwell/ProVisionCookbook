import { TestBed } from '@angular/core/testing';
import { provideMockActions } from '@ngrx/effects/testing';
import { Observable } from 'rxjs';

import { FilterPayloadEffects } from './filter-payload.effects';

describe('FilterPayloadEffects', () => {
	// tslint:disable-next-line: prefer-const
	let actions$: Observable<any>;
	let effects: FilterPayloadEffects;

	beforeEach(() => {
		TestBed.configureTestingModule({
			providers: [
			FilterPayloadEffects,
			provideMockActions(() => actions$)
			]
		});

		effects = TestBed.inject<FilterPayloadEffects>(FilterPayloadEffects);
	});

	it('should be created', () => {
		expect(effects).toBeTruthy();
	});
});
