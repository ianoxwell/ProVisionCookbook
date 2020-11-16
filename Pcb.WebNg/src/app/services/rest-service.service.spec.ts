import { TestBed } from '@angular/core/testing';

import { RestService } from './rest-service.service';
import { HttpClientModule } from '@angular/common/http';

describe('RestServiceService', () => {
	beforeEach(() => TestBed.configureTestingModule({
		imports: [HttpClientModule]
	}));

	it('should be created', () => {
			const service: RestService = TestBed.inject(RestService);
			expect(service).toBeTruthy();
	});
});
