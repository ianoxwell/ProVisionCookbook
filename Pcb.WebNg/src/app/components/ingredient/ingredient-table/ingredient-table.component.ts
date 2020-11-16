import {Component, EventEmitter, OnInit, Output} from '@angular/core';

import {MatTableDataSource} from '@angular/material/table';
import {Ingredient, IngredientNameSpace, PurchasedBy} from '@models/ingredient';
import {BaseTableComponent} from '@components/base/table.component.base';

@Component({
  selector: 'app-ingredient-table',
  templateUrl: './ingredient-table.component.html',
  styleUrls: ['./ingredient-table.component.scss']
})
export class IngredientTableComponent extends BaseTableComponent implements OnInit {
  @Output() editRow = new EventEmitter<Ingredient>();
  displayedColumns = ['name', 'parent', 'allergies', 'purchasedBy'];
  purchasedBy = PurchasedBy;

  constructor() {
	super();
  }

  ngOnInit(): void {
	this.dataSource = new MatTableDataSource(this.data.items);
	this.dataLength = this.data.totalCount;
  }

  // on row / ingredient clicked emit to parent the row
  goto(row: Ingredient) {
	this.editRow.emit(row);
  }

  // todo - work out what this function is doing here
  public modifyIngredient(ingredient: Ingredient, editOrNew: string) {
	// Function called from the Parent using the Viewchild from ingredients.component this.table.dataSource,
	console.log('modifyIngredient in Data-table.component', this.dataSource.data, ingredient, editOrNew);
	if (editOrNew === 'edit') {
		// filter/find the dataSource and replace the ingredient._id with incoming ingredient
		console.log('before', this.dataSource.data.find((item) => item._id === ingredient.id), ingredient);
		// const idxNumber: number = this.dataSource.data.indexOf()
		const idxNumber = this.dataSource.data.findIndex((item) => item._id === ingredient.id);
		this.dataSource.data[idxNumber] = ingredient;
		console.log('after', this.dataSource.data);
	} else if (editOrNew === 'new') {
		// push the new ingredient to the table
		this.dataSource.data.push(ingredient);
		// this.dataSource.data = [...this.dataSource.data, ingredient];
		// this.dataSource.sort();
		console.log('after', this.dataSource.data);
	} else if (editOrNew === 'delete') {
		const index = this.dataSource.data.findIndex((item) => item._id === ingredient.id);
		this.dataSource.data = [...this.dataSource.data.slice(0, index), ...this.dataSource.data.slice(index + 1)];
		console.log('after', this.dataSource.data, index);
	}
	this.dataLength = this.dataSource.data.length;
	this.sort.sortChange.emit();
	// this.dataSource.sort.sort();
	// this.table.dataSource = this.dataSource;
	// this.table.renderRows();
	// Object.assign(this.table.dataSource, this.dataSource);
  }

}
