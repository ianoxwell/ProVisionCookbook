import { Injectable } from '@angular/core';
import { FormControl, FormGroup, ValidatorFn } from '@angular/forms';

@Injectable({ providedIn: 'root' })

export class NutrientTotalValidator {
	public totalCalc(): ValidatorFn | null {
		return (group: FormGroup): { [key: string]: any } => {
			if (!group) {
				return null;
			}
			const error = { exceeds100: { message: 'Total of protein, fat, carbohydrate and water exceeds 100g'}};
			// const nutrientGroup: FormGroup = group.get('nutritionFacts') as FormGroup;

			const ctrlGroup = {
				protein: group.get('protein') as FormControl,
				fat: group.get('totalFat') as FormControl,
				carbs: group.get('totalCarbohydrate') as FormControl,
				water: group.get('water') as FormControl
			}
			const totalValue: number = Object.keys(ctrlGroup).reduce((addition: number, key: string) =>	addition + Number(ctrlGroup[key].value), 0);
			if (totalValue > 100) {
				Object.keys(ctrlGroup).forEach((key: string) => {
					const currentError = ctrlGroup[key].errors;
					ctrlGroup[key].setErrors({...currentError, ...error });
				});
				return error;

			} else {
				Object.keys(ctrlGroup).forEach((key: string) => {
					const currentError = ctrlGroup[key].errors;
					if (currentError?.hasOwnProperty('exceeds100')) {
						delete currentError.exceeds100;
					}
					if (currentError === null || Object.keys(currentError).length === 0) {
						ctrlGroup[key].setErrors(null);
					} else {
						ctrlGroup[key].setErrors({...currentError});
					}
				});
				return null;
			}
		}
	}
}