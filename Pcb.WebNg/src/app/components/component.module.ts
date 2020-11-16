import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CompleteMaterialModule } from '../app-material.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { HttpClientModule } from '@angular/common/http';

import { DragNDropComponent } from './drag-ndrop/drag-ndrop.component';
import { SearchBarComponent } from './search-bar/search-bar.component';
import { RecipeCardComponent } from './recipe-card/recipe-card.component';
import { RecipeViewComponent } from './recipe-view/recipe-view.component';
import { ScriptsComponent } from '../settings/scripts/scripts.component';
import { AppHeaderComponent } from './app-header/app-header.component';
import { DynamicFormComponent } from './dynamic-form/dynamic-form.component';
import { DynamicErrorsComponent } from './dynamic-errors/dynamic-errors.component';
import { DateTimeFormComponent } from './date-time-form/date-time-form.component';
import { IngredientEditComponent } from './ingredient/ingredient-edit/ingredient-edit.component';
import { IconTextComponent } from './icon-text/icon-text.component';
import { IngredientFilterComponent } from './ingredient/ingredient-filter/ingredient-filter.component';
import { PipesModule } from '@pipes/pipes.module';
import { IngredientTableComponent } from './ingredient/ingredient-table/ingredient-table.component';
import { IngredientPricesFormComponent } from './ingredient/ingredient-prices-form/ingredient-prices-form.component';
import { IngredientConversionFormComponent } from './ingredient/ingredient-conversion-form/ingredient-conversion-form.component';
import { SelectAutoCompleteComponent } from './select-auto-complete/select-auto-complete.component';
import { ToastItemComponent } from './toast/toast-item/toast-item.component';
import { ToastComponent } from './toast/toast.component';import { LoadingIndicatorComponent } from './loading-indicator/loading-indicator.component';
import { DropDownComponent } from './drop-down/drop-down.component';
import { DropdownItemComponent } from './drop-down/drop-down-item.component';
import { TooltipDirective } from '../directives/tooltip.directive';
import { ChartsModule } from 'ng2-charts';
import { PageTitleComponent } from './page-title/page-title.component';
import { IngredientNutritionFormComponent } from './ingredient/ingredient-nutrition-form/ingredient-nutrition-form.component';
import { SharedComponentModule } from './shared-component.module';
import { DigitOnlyModule } from '@uiowa/digit-only';
import { NutritionFactsEditComponent } from './ingredient/nutrition-facts-edit/nutrition-facts-edit.component';
import { NutrientTotalValidator } from '../validators/nutrient-total.validator';

@NgModule({
  imports: [
	CompleteMaterialModule,
	CommonModule,
	FormsModule,
	ReactiveFormsModule,
	RouterModule,
	HttpClientModule,
	PipesModule,
	ChartsModule,
	SharedComponentModule,
	DigitOnlyModule
  ],
  declarations: [
	DragNDropComponent,
	SearchBarComponent,
	RecipeCardComponent,
	RecipeViewComponent,
	ScriptsComponent,
	AppHeaderComponent,
	DynamicFormComponent,
	DynamicErrorsComponent,
	DateTimeFormComponent,
	IngredientEditComponent,
	IngredientFilterComponent,
	IconTextComponent,
	IngredientTableComponent,
	IngredientPricesFormComponent,
	IngredientConversionFormComponent,
	SelectAutoCompleteComponent,
	ToastItemComponent,
	ToastComponent,
	LoadingIndicatorComponent,
	DropdownItemComponent,
	DropDownComponent,
	TooltipDirective,
	PageTitleComponent,
	IngredientNutritionFormComponent,
	NutritionFactsEditComponent
  ],
  exports: [
	DragNDropComponent,
	SearchBarComponent,
	RecipeCardComponent,
	RecipeViewComponent,
	ScriptsComponent,
	AppHeaderComponent,
	DynamicFormComponent,
	DynamicErrorsComponent,
	DateTimeFormComponent,
	IngredientEditComponent,
	IngredientFilterComponent,
	IconTextComponent,
	IngredientTableComponent,
	IngredientPricesFormComponent,
	IngredientConversionFormComponent,
	SelectAutoCompleteComponent,
	ToastComponent,
	LoadingIndicatorComponent,
	DropDownComponent,
	TooltipDirective,
	PageTitleComponent,
	IngredientNutritionFormComponent
  ],
  providers: [
	  NutrientTotalValidator
  ]
})
export class ComponentModule { }
