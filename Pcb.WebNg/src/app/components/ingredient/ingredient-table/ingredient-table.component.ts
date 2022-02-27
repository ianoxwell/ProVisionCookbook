import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { BaseTableComponent } from '@components/base/table.component.base';
import { Ingredient, PurchasedBy } from '@models/ingredient';

@Component({
  selector: 'app-ingredient-table',
  templateUrl: './ingredient-table.component.html',
  styleUrls: ['./ingredient-table.component.scss']
})
export class IngredientTableComponent extends BaseTableComponent<Ingredient> implements OnInit {
  @Output() editRow = new EventEmitter<Ingredient>();
  displayedColumns = ['name', 'foodGroup', 'allergies', 'purchasedBy'];
  purchasedBy = PurchasedBy;

  constructor() {
    super();
  }

  ngOnInit(): void {
    this.dataSource = new MatTableDataSource(this.data.items);
    this.dataLength = this.data.totalCount;
    this.dataCount = this.data.items.length;
  }

  /** on row / ingredient clicked emit to parent the row */
  goto(row: Ingredient) {
    this.editRow.emit(row);
  }
}
