import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { Recipe } from '@models/recipe';

@Component({
	selector: 'app-recipe-card',
	templateUrl: './recipe-card.component.html',
	styleUrls: ['./recipe-card.component.scss']
})
export class RecipeCardComponent implements OnInit {
	@Input() recipeInput: Recipe;
	@Output() clickedRecipe = new EventEmitter<Recipe>();

	constructor() {}
	more() {
		console.log('guess what - more');
	}
	ngOnInit() {}
}
