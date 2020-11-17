import {Component, EventEmitter, OnInit, Output} from '@angular/core';

import {MatTableDataSource} from '@angular/material/table';
import {Ingredient, PurchasedBy} from '@models/ingredient';
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


}
