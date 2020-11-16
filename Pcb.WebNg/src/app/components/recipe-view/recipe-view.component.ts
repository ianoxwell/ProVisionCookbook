import {Component, OnInit, Input, Output, EventEmitter} from '@angular/core';
import {Recipe} from '@models/recipe';
import { SentenceCasePipe } from '@pipes/sentence-case.pipe';
import { MeasurementModel } from '@models/ingredient-model';
import { IngredientList } from '@models/ingredientList';

@Component({
  selector: 'app-recipe-view',
  templateUrl: './recipe-view.component.html',
  styleUrls: ['./recipe-view.component.scss']
})
export class RecipeViewComponent implements OnInit {
	@Input() selectedRecipe: Recipe;
	@Input() measurements: MeasurementModel[];

	constructor(
		private sentenceCase: SentenceCasePipe
	) { }

	ngOnInit() {
	}

	printView() {
		// todo complete the print views
		console.log('go and print');
	}

	englishIngredientItem(ingredient: IngredientList): string {
		let unit = ingredient.unit;
		if (unit.length < 5 || unit === 'tbsps') {
			const newUnit = this.measurements.find(measure => (measure.shortName === unit || measure.altShortName === unit));
			if (!!newUnit) {
				unit = newUnit.title;
			}
		}
		return `${ingredient.quantity} ${unit} ${this.sentenceCase.transform(ingredient.ingredientName)}`;
	}

	routerLinkURL(ingredient: IngredientList): string {
		return `/savoury/ingredients/item/${ingredient.ingredientId}`;
	}

}
