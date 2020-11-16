import { NG_VALUE_ACCESSOR } from '@angular/forms';
import { forwardRef, Component, Input, TemplateRef, Output, EventEmitter } from '@angular/core';
import { DropDownComponent } from './drop-down.component';
import { SelectItem } from '@models/select-item.model';



  @Component({
	  selector: 'app-dropdown-item',
	  template: `
		  <li (click)="onOptionClick($event)" role="option" pRipple
			  [attr.aria-label]="option.label" [attr.aria-selected]="selected"
			  [ngStyle]="{'height': itemSize + 'px'}" tabindex="0"
			  [ngClass]="{'p-dropdown-item':true, 'p-highlight': selected, 'p-disabled':(option.disabled)}">
			  <span *ngIf="!template">{{option.label||'empty'}}</span>
			  <ng-container *ngTemplateOutlet="template; context: {$implicit: option}"></ng-container>
		  </li>
	  `
  })
  export class DropdownItemComponent {

	  @Input() option: SelectItem;

	  @Input() selected: boolean;

	  @Input() disabled: boolean;

	  @Input() visible: boolean;

	  @Input() itemSize: number;

	  @Input() template: TemplateRef<any>;

	  // tslint:disable-next-line: no-output-on-prefix
	  @Output() onClick: EventEmitter<any> = new EventEmitter();

	  onOptionClick(event: Event) {
		  this.onClick.emit({
			  originalEvent: event,
			  option: this.option
		  });
	  }
  }
