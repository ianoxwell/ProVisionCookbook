import { TestBed } from '@angular/core/testing';

import { IngredientConstructService } from './ingredient-construct.service';

describe('IngredientConstructService', () => {
	let service: IngredientConstructService;

	beforeEach(() => {
		TestBed.configureTestingModule({});
		service = TestBed.inject(IngredientConstructService);
	});

	it('should be created', () => {
		expect(service).toBeTruthy();
	});
});
