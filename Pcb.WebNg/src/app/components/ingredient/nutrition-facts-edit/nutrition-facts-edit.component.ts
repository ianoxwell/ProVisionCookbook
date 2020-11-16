import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { ComponentBase } from '@components/base/base.component.base';
import { DecimalThreePlaces, DecimalTwoPlaces } from '@models/static-variables';
import { first, takeUntil, tap } from 'rxjs/operators';
import { merge, zip } from 'rxjs';
import { Label } from 'ng2-charts';
import { ChartOptions, ChartType } from 'chart.js';

@Component({
  selector: 'app-nutrition-facts-edit',
  templateUrl: './nutrition-facts-edit.component.html',
  styleUrls: ['./nutrition-facts-edit.component.scss']
})
export class NutritionFactsEditComponent extends ComponentBase implements OnInit {
	@Input() nutritionFacts: FormGroup;
	@Output() markAsDirty = new EventEmitter<void>();

	decimalTwoPlaces = DecimalTwoPlaces;
	decimalThreePlaces = DecimalThreePlaces;
	O3ToO6Ratio = 0;
	public pieChartLabels: Label[] = ['Carbohydrates', 'Fat', 'Protein', 'Water'];
	public pieChartData: number[];
	public pieChartType: ChartType = 'pie';
	public pieChartLegend = true;
	public pieChartColors = [
	  {
		backgroundColor: ['rgba(255,0,0,0.8)', 'rgba(0,255,0,0.8)', 'rgba(0,255,255,0.8)', 'rgba(0,0,255,0.8)'],
	  },
	];
	 // Pie
	 public pieChartOptions: ChartOptions = {
		responsive: true,
		legend: {
		  position: 'left',
		},
	  };
	constructor() { super(); }

	ngOnInit() {
		this.listenAnyFormChanges();
		this.listenOmegaRatio();
		this.listenNutrientTotals();
		this.pieChartData = this.updatePieChartData();
	}

	// Mark the parent form as Dirty if any form element changes
	// only listens for the first change (because then it is dirty) - may have to reload on save...
	listenAnyFormChanges(): void {
		this.nutritionFacts.valueChanges.pipe(
			first(),
			tap(() => this.markAsDirty.emit()),
		).subscribe();
	}
	listenOmegaRatio(): void {
		// recalculate the Omega3 ratio on changes to their respective fields only
		merge(this.nutritionFacts.get('omega3s').valueChanges,
			this.nutritionFacts.get('omega6s').valueChanges).pipe(
			tap(() => this.O3ToO6Ratio = this.getO3ToO6Ratio()),
			takeUntil(this.ngUnsubscribe)
		).subscribe();

	}

	// Subscribe to valueChanges in the major 4 items and mark as touched to update the error status of the form
	// links to nutrient-total.validator
	listenNutrientTotals(): void {
		const carbs: FormControl = this.nutritionFacts.get('totalCarbohydrate') as FormControl;
		const fat: FormControl = this.nutritionFacts.get('totalFat') as FormControl;
		const water: FormControl = this.nutritionFacts.get('water') as FormControl;
		const protein: FormControl = this.nutritionFacts.get('protein') as FormControl;
		merge(
			carbs.valueChanges,
			fat.valueChanges,
			water.valueChanges,
			protein.valueChanges).pipe(
			tap(() => {
				carbs.markAsTouched();
				fat.markAsTouched();
				water.markAsTouched();
				protein.markAsTouched();
				this.pieChartData = this.updatePieChartData();
			}),
			takeUntil(this.ngUnsubscribe)
		).subscribe();
	}

	// Omega 6 is known to fuel inflammatory cycles in the body, a high ratio of omega3 to 6 is therefore preferred
	getO3ToO6Ratio(): number {
		const formValue = this.nutritionFacts.getRawValue();
		return (Number(formValue.omega3s) && formValue.omega6s > 0) ? Math.round(formValue.omega3s / formValue.omega6s * 100) / 100 : 0;
	}

	updatePieChartData(): number[] {
		const pieValues = this.nutritionFacts.getRawValue();
		return [pieValues.totalCarbohydrate, pieValues.totalFat, pieValues.protein, pieValues.water];
	}

}
