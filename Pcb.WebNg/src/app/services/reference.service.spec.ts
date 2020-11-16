/* tslint:disable:no-unused-variable */

import { TestBed, waitForAsync, inject } from '@angular/core/testing';
import { ReferenceService } from './reference.service';

	describe('Service: Reference', () => {
	beforeEach(() => {
		TestBed.configureTestingModule({
		providers: [ReferenceService]
		});
	});

	it('should ...', inject([ReferenceService], (service: ReferenceService) => {
		expect(service).toBeTruthy();
	}));
});
