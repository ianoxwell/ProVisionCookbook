import { AfterViewInit, Component, ElementRef, EventEmitter, Input, OnInit, Output, ViewChild } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { ComponentBase } from '@components/base/base.component.base';
import { DecimalThreePlaces, DecimalTwoPlaces } from '@models/static-variables';
import { first, takeUntil, tap } from 'rxjs/operators';
import { merge } from 'rxjs';
import { Label } from 'ng2-charts';
import { ChartOptions, ChartType } from 'chart.js';

@Component({
  selector: 'app-edit-ingredient-nutrition',
  templateUrl: './edit-ingredient-nutrition.component.html',
  styleUrls: ['./edit-ingredient-nutrition.component.scss']
})
export class EditIngredientNutritionComponent extends ComponentBase implements OnInit, AfterViewInit {
	@ViewChild('doughNutCanvas') doughNutCanvas: ElementRef;
	@Input() form: FormGroup;
	@Output() markAsDirty = new EventEmitter<void>();

	decimalTwoPlaces = DecimalTwoPlaces;
	decimalThreePlaces = DecimalThreePlaces;
	O3ToO6Ratio = 0;
	public pieChartLabels: Label[] = ['Carbohydrates', 'Fat', 'Protein', 'Water'];
	public pieChartData: number[] = [0,0,0,0];
	public pieChartType: ChartType = 'doughnut';
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
		  position: 'bottom',
		},
		animation:{ onProgress: () => this.updateTextCenterDoughNut() },
		// tooltips: {enabled: false},
		hover: {mode: null},
	  };
	constructor() { super(); }

	ngOnInit() {
		this.listenAnyFormChanges();
		this.listenOmegaRatio();
		this.listenNutrientTotals();
		this.pieChartData = this.updatePieChartData()
	}

	ngAfterViewInit(): void {
		setTimeout(() => this.pieChartData = this.updatePieChartData(), 500);
	}
	// Mark the parent form as Dirty if any form element changes
	// only listens for the first change (because then it is dirty) - may have to reload on save...
	listenAnyFormChanges(): void {
		this.form.valueChanges.pipe(
			first(),
			tap(() => this.markAsDirty.emit()),
		).subscribe();
	}
	listenOmegaRatio(): void {
		// recalculate the Omega3 ratio on changes to their respective fields only
		merge(this.form.get('omega3s').valueChanges,
			this.form.get('omega6s').valueChanges).pipe(
			tap(() => this.O3ToO6Ratio = this.getO3ToO6Ratio()),
			takeUntil(this.ngUnsubscribe)
		).subscribe();

	}

	// Subscribe to valueChanges in the major 4 items and mark as touched to update the error status of the form
	// links to nutrient-total.validator
	listenNutrientTotals(): void {
		const carbs: FormControl = this.form.get('totalCarbohydrate') as FormControl;
		const fat: FormControl = this.form.get('totalFat') as FormControl;
		const water: FormControl = this.form.get('water') as FormControl;
		const protein: FormControl = this.form.get('protein') as FormControl;
		const calories: FormControl = this.form.get('calories') as FormControl;
		merge(
			carbs.valueChanges,
			fat.valueChanges,
			water.valueChanges,
			protein.valueChanges,
			calories.valueChanges).pipe(
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
		const formValue = this.form.getRawValue();
		return (Number(formValue.omega3s) && formValue.omega6s > 0) ? Math.round(formValue.omega3s / formValue.omega6s * 100) / 100 : 0;
	}

	updatePieChartData(): number[] {
		const pieValues = this.form.getRawValue();
		return [pieValues.totalCarbohydrate, pieValues.totalFat, pieValues.protein, pieValues.water];
	}

	updateTextCenterDoughNut(): void {
		const ctx = this.doughNutCanvas.nativeElement.getContext('2d');
		const formValue = this.form.getRawValue();
		const calories = formValue.calories;
		const subheading = 'Kcal / 100g';
		const stringWidth = (txt: string) => ctx.measureText(txt).width;
		const width = ctx.canvas.width;
		const height = ctx.canvas.clientHeight;

		ctx.textAlign = 'center';
		ctx.textBaseline = 'middle';


		const caloriesFontSize = Math.floor(1.3 * (width / stringWidth(calories)));
		const subheadingFontSize = Math.floor(caloriesFontSize / 2);
		const centerX = (width * 0.5);
		const centerY = (height / 2 - 16);

		ctx.font = caloriesFontSize + 'px Arial';
		ctx.fillStyle = 'blue';
		ctx.fillText(calories, centerX, centerY - caloriesFontSize/2);

		ctx.font = subheadingFontSize + 'px Arial';
		ctx.fillStyle = 'orange';
		ctx.fillText(subheading, centerX, centerY + subheadingFontSize);
		console.log('ctxx', caloriesFontSize, ctx.measureText(calories).width, subheadingFontSize, centerX, centerY, ctx.canvas.clientWidth);
		ctx.restore();
	}

}