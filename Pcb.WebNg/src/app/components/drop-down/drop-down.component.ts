// Based on https://github.com/primefaces/primeng/blob/master/src/app/components/dropdown/dropdown.ts

import {NgModule, Component, ElementRef, OnInit, AfterViewInit, AfterContentInit, AfterViewChecked, OnDestroy, Input, Output, Renderer2,
	EventEmitter, ContentChildren, QueryList, ViewChild, TemplateRef, forwardRef, ChangeDetectorRef, NgZone,ViewRef,ChangeDetectionStrategy,
	ViewEncapsulation,
	Directive} from '@angular/core';
import { NG_VALUE_ACCESSOR, ControlValueAccessor } from '@angular/forms';
import { trigger, transition, style, animate, AnimationEvent } from '@angular/animations';
import { CdkVirtualScrollViewport, ScrollingModule } from '@angular/cdk/scrolling';
import { SelectItem } from '@models/select-item.model';
import { DomHandler } from '@components/dom/domhandler';
import { ObjectUtils, FilterUtils } from 'src/app/utils/public_api';

const DROPDOWN_VALUE_ACCESSOR: any = {
	provide: NG_VALUE_ACCESSOR,
	useExisting: forwardRef(() => DropDownComponent),
	multi: true
  };

@Directive({
	// tslint:disable-next-line: directive-selector
	selector: '[pTemplate]',
})
export class PrimeTemplateDirective {

	@Input() type: string;

	// tslint:disable-next-line: no-input-rename
	@Input('pTemplate') name: string;

	constructor(public template: TemplateRef<any>) {}

	getType(): string {
		return this.name;
	}
}

@Component({
	selector: 'app-drop-down',
	templateUrl: './drop-down.component.html',
	styleUrls: ['./drop-down.component.scss'],
	animations: [
		trigger('overlayAnimation', [
			transition(':enter', [
				style({opacity: 0, transform: 'scaleY(0.8)'}),
				animate('{{showTransitionParams}}')
			]),
			transition(':leave', [
				animate('{{hideTransitionParams}}', style({ opacity: 0 }))
			])
		])
	],
	// tslint:disable-next-line: no-host-metadata-property
	host: {
		'[class.p-inputwrapper-filled]': 'filled',
		'[class.p-inputwrapper-focus]': 'focused'
	},
	providers: [DROPDOWN_VALUE_ACCESSOR],
	changeDetection: ChangeDetectionStrategy.OnPush,
	encapsulation: ViewEncapsulation.None,
})
export class DropDownComponent implements  OnInit, AfterViewInit, AfterContentInit, AfterViewChecked, OnDestroy, ControlValueAccessor {

	@Input() get disabled(): boolean {
		return this._disabled;
	};

	set disabled(_disabled: boolean) {
		if (_disabled)
			this.focused = false;

		this._disabled = _disabled;
		if (!(this.cd as ViewRef).destroyed) {
			this.cd.detectChanges();
		}
	}

	constructor(public el: ElementRef, public renderer: Renderer2, public cd: ChangeDetectorRef, public zone: NgZone) {}

	@Input() get options(): any[] {
		return this._options;
	}

	set options(val: any[]) {
		const opts = this.optionLabel ? ObjectUtils.generateSelectItems(val, this.optionLabel) : val;
		this._options = opts;
		this.optionsToDisplay = this._options;
		this.updateSelectedOption(this.value);
		this.optionsChanged = true;
		this.updateFilledState();

		if (this.filterValue && this.filterValue.length) {
			this.activateFilter();
		}
	}

	get label(): string {
		return (this.selectedOption ? this.selectedOption.label : null);
	}


	@Input() scrollHeight = '200px';

	@Input() filter: boolean;

	@Input() name: string;

	@Input() style: any;

	@Input() panelStyle: any;

	@Input() styleClass: string;

	@Input() panelStyleClass: string;

	@Input() readonly: boolean;

	@Input() required: boolean;

	@Input() editable: boolean;

	@Input() appendTo: any;

	@Input() tabindex: number;

	@Input() placeholder: string;

	@Input() filterPlaceholder: string;

	@Input() filterLocale: string;

	@Input() inputId: string;

	@Input() selectId: string;

	@Input() dataKey: string;

	@Input() filterBy = 'label';

	@Input() autofocus: boolean;

	@Input() resetFilterOnHide = false;

	@Input() dropdownIcon = 'pi pi-chevron-down';

	@Input() optionLabel: string;

	@Input() autoDisplayFirst = true;

	@Input() group: boolean;

	@Input() showClear: boolean;

	@Input() emptyFilterMessage = 'No results found';

	@Input() virtualScroll: boolean;

	@Input() itemSize: number;

	@Input() autoZIndex = true;

	@Input() baseZIndex = 0;

	@Input() showTransitionOptions = '.12s cubic-bezier(0, 0, 0.2, 1)';

	@Input() hideTransitionOptions = '.1s linear';

	@Input() ariaFilterLabel: string;

	@Input() ariaLabelledBy: string;

	@Input() filterMatchMode = 'contains';

	@Input() maxlength: number;

	@Input() tooltip = '';

	@Input() tooltipPosition = 'right';

	@Input() tooltipPositionStyle = 'absolute';

	@Input() tooltipStyleClass: string;

	@Input() autofocusFilter = true;

	// tslint:disable-next-line: no-output-on-prefix
	@Output() onChange: EventEmitter<any> = new EventEmitter();

	// tslint:disable-next-line: no-output-on-prefix
	@Output() onFocus: EventEmitter<any> = new EventEmitter();

	// tslint:disable-next-line: no-output-on-prefix
	@Output() onBlur: EventEmitter<any> = new EventEmitter();

	// tslint:disable-next-line: no-output-on-prefix
	@Output() onClick: EventEmitter<any> = new EventEmitter();

	// tslint:disable-next-line: no-output-on-prefix
	@Output() onShow: EventEmitter<any> = new EventEmitter();

	// tslint:disable-next-line: no-output-on-prefix
	@Output() onHide: EventEmitter<any> = new EventEmitter();

	@ViewChild('container') containerViewChild: ElementRef;

	@ViewChild('filter') filterViewChild: ElementRef;

	@ViewChild('in') accessibleViewChild: ElementRef;

	@ViewChild(CdkVirtualScrollViewport) viewPort: CdkVirtualScrollViewport;

	@ViewChild('editableInput') editableInputViewChild: ElementRef;

	@ContentChildren(PrimeTemplateDirective) templates: QueryList<any>;

	private _disabled: boolean;

	overlay: HTMLDivElement;

	itemsWrapper: HTMLDivElement;

	itemTemplate: TemplateRef<any>;

	groupTemplate: TemplateRef<any>;

	selectedItemTemplate: TemplateRef<any>;

	selectedOption: any;

	_options: any[];

	value: any;

	optionsToDisplay: any[];

	hover: boolean;

	focused: boolean;

	filled: boolean;

	overlayVisible: boolean;

	documentClickListener: any;

	optionsChanged: boolean;

	panel: HTMLDivElement;

	dimensionsUpdated: boolean;

	hoveredItem: any;

	selectedOptionUpdated: boolean;

	filterValue: string;

	searchValue: string;

	searchIndex: number;

	searchTimeout: any;

	previousSearchChar: string;

	currentSearchChar: string;

	documentResizeListener: any;

	virtualAutoScrolled: boolean;

	virtualScrollSelectedIndex: number;

	viewPortOffsetTop = 0;

	preventModelTouched: boolean;

	onModelChange: any = () => {};

	onModelTouched: any = () => {};

	ngAfterContentInit() {
		this.templates.forEach((item) => {
			switch(item.getType()) {
				case 'item':
					this.itemTemplate = item.template;
				break;

				case 'selectedItem':
					this.selectedItemTemplate = item.template;
				break;

				case 'group':
					this.groupTemplate = item.template;
				break;

				default:
					this.itemTemplate = item.template;
				break;
			}
		});
	}

	ngOnInit() {
		this.optionsToDisplay = this.options;
		this.updateSelectedOption(null);
	}

	ngAfterViewInit() {
		if (this.editable) {
			this.updateEditableLabel();
		}
	}

	updateEditableLabel(): void {
		if (this.editableInputViewChild && this.editableInputViewChild.nativeElement) {
			this.editableInputViewChild.nativeElement.value = (this.selectedOption ? this.selectedOption.label : this.value||'');
		}
	}

	onItemClick(event) {
		const option = event.option;

		if (!option.disabled) {
			this.selectItem(event, option);
			this.accessibleViewChild.nativeElement.focus();
		}

		setTimeout(() => {
			this.hide(event);
		}, 150);
	}

	selectItem(event, option) {
		if (this.selectedOption !== option) {
			this.selectedOption = option;
			this.value = option.value;
			this.filled = true;

			this.onModelChange(this.value);
			this.updateEditableLabel();
			this.onChange.emit({
				originalEvent: event.originalEvent,
				value: this.value
			});

			if (this.virtualScroll) {
				setTimeout(() => {
					this.viewPortOffsetTop = this.viewPort ? this.viewPort.measureScrollOffset() : 0;
				}, 1);
			}
		}
	}

	ngAfterViewChecked() {
		if (this.optionsChanged && this.overlayVisible) {
			this.optionsChanged = false;

			if (this.virtualScroll) {
				this.updateVirtualScrollSelectedIndex(true);
			}

			this.zone.runOutsideAngular(() => {
				setTimeout(() => {
					this.alignOverlay();
				}, 1);
			});
		}

		if (this.selectedOptionUpdated && this.itemsWrapper) {
			if (this.virtualScroll && this.viewPort) {
				const range = this.viewPort.getRenderedRange();
				this.updateVirtualScrollSelectedIndex(false);

				if (range.start > this.virtualScrollSelectedIndex || range.end < this.virtualScrollSelectedIndex) {
					this.viewPort.scrollToIndex(this.virtualScrollSelectedIndex);
				}
			}

			const selectedItem = DomHandler.findSingle(this.overlay, 'li.p-highlight');
			if (selectedItem) {
				DomHandler.scrollInView(this.itemsWrapper, DomHandler.findSingle(this.overlay, 'li.p-highlight'));
			}
			this.selectedOptionUpdated = false;
		}
	}

	writeValue(value: any): void {
		if (this.filter) {
			this.resetFilter();
		}

		this.value = value;
		this.updateSelectedOption(value);
		this.updateEditableLabel();
		this.updateFilledState();
		this.cd.markForCheck();
	}

	resetFilter(): void {
		this.filterValue = null;

		if (this.filterViewChild && this.filterViewChild.nativeElement) {
			this.filterViewChild.nativeElement.value = '';
		}

		this.optionsToDisplay = this.options;
	}

	updateSelectedOption(val: any): void {
		this.selectedOption = this.findOption(val, this.optionsToDisplay);
		if (this.autoDisplayFirst && !this.placeholder && !this.selectedOption && this.optionsToDisplay
				&& this.optionsToDisplay.length && !this.editable) {
			this.selectedOption = this.optionsToDisplay[0];
		}
		this.selectedOptionUpdated = true;
	}

	registerOnChange(fn: any): void {
		this.onModelChange = fn;
	}

	registerOnTouched(fn: any): void {
		this.onModelTouched = fn;
	}

	setDisabledState(val: boolean): void {
		this.disabled = val;
	}

	onMouseclick(event) {
		if (this.disabled || this.readonly || this.isInputClick(event)) {
			return;
		}

		this.onClick.emit(event);
		this.accessibleViewChild.nativeElement.focus();

		if (this.overlayVisible)
			this.hide(event);
		else
			this.show();

		this.cd.detectChanges();
	}

	isInputClick(event): boolean {
		return DomHandler.hasClass(event.target, 'p-dropdown-clear-icon') ||
			event.target.isSameNode(this.accessibleViewChild.nativeElement) ||
			(this.editableInputViewChild && event.target.isSameNode(this.editableInputViewChild.nativeElement));
	}

	isOutsideClicked(event: Event): boolean {
		return !(this.el.nativeElement.isSameNode(event.target) || this.el.nativeElement.contains(event.target)
			|| (this.overlay && this.overlay.contains(event.target as Node)));
	}

	onEditableInputClick() {
		this.bindDocumentClickListener();
	}

	onEditableInputFocus(event) {
		this.focused = true;
		this.hide(event);
		this.onFocus.emit(event);
	}

	onEditableInputChange(event) {
		this.value = event.target.value;
		this.updateSelectedOption(this.value);
		this.onModelChange(this.value);
		this.onChange.emit({
			originalEvent: event,
			value: this.value
		});
	}

	show() {
		this.overlayVisible = true;
	}

	onOverlayAnimationStart(event: AnimationEvent) {
		switch (event.toState) {
			case 'visible':
				this.overlay = event.element;
				const itemsWrapperSelector = this.virtualScroll ? '.cdk-virtual-scroll-viewport' : '.p-dropdown-items-wrapper';
				this.itemsWrapper = DomHandler.findSingle(this.overlay, itemsWrapperSelector);
				this.appendOverlay();
				if (this.autoZIndex) {
					this.overlay.style.zIndex = String(this.baseZIndex + (++DomHandler.zindex));
				}
				this.alignOverlay();
				this.bindDocumentClickListener();
				this.bindDocumentResizeListener();

				if (this.options && this.options.length) {
					if (!this.virtualScroll) {
						const selectedListItem = DomHandler.findSingle(this.itemsWrapper, '.p-dropdown-item.p-highlight');
						if (selectedListItem) {
							DomHandler.scrollInView(this.itemsWrapper, selectedListItem);
						}
					}
				}

				if (this.filterViewChild && this.filterViewChild.nativeElement) {
					this.preventModelTouched = true;

					if (this.autofocusFilter) {
						this.filterViewChild.nativeElement.focus();
					}
				}

				this.onShow.emit(event);
			break;

			case 'void':
				this.onOverlayHide();
			break;
		}
	}

	scrollToSelectedVirtualScrollElement() {
		if (!this.virtualAutoScrolled) {
			if (this.viewPortOffsetTop) {
				this.viewPort.scrollToOffset(this.viewPortOffsetTop);
			}
			else if (this.virtualScrollSelectedIndex > -1) {
				this.viewPort.scrollToIndex(this.virtualScrollSelectedIndex);
			}
		}

		this.virtualAutoScrolled = true;
	}

	updateVirtualScrollSelectedIndex(resetOffset) {
		if (this.selectedOption && this.optionsToDisplay && this.optionsToDisplay.length) {
			if (resetOffset) {
				this.viewPortOffsetTop = 0;
			}

			this.virtualScrollSelectedIndex = this.findOptionIndex(this.selectedOption.value, this.optionsToDisplay);
		}
	}

	appendOverlay() {
		if (this.appendTo) {
			if (this.appendTo === 'body')
				document.body.appendChild(this.overlay);
			else
				DomHandler.appendChild(this.overlay, this.appendTo);

			if (!this.overlay.style.minWidth) {
				this.overlay.style.minWidth = DomHandler.getWidth(this.containerViewChild.nativeElement) + 'px';
			}
		}
	}

	restoreOverlayAppend() {
		if (this.overlay && this.appendTo) {
			this.el.nativeElement.appendChild(this.overlay);
		}
	}

	hide(event) {
		this.overlayVisible = false;

		if (this.filter && this.resetFilterOnHide) {
			this.resetFilter();
		}

		if (this.virtualScroll) {
			this.virtualAutoScrolled = false;
		}

		this.cd.markForCheck();
		this.onHide.emit(event);
	}

	alignOverlay() {
		if (this.overlay) {
			if (this.appendTo)
				DomHandler.absolutePosition(this.overlay, this.containerViewChild.nativeElement);
			else
				DomHandler.relativePosition(this.overlay, this.containerViewChild.nativeElement);
		}
	}

	onInputFocus(event) {
		this.focused = true;
		this.onFocus.emit(event);
	}

	onInputBlur(event) {
		this.focused = false;
		this.onBlur.emit(event);

		if (!this.preventModelTouched) {
			this.onModelTouched();
		}
		this.preventModelTouched = false;
	}

	findPrevEnabledOption(index) {
		let prevEnabledOption;

		if (this.optionsToDisplay && this.optionsToDisplay.length) {
			for (let i = (index - 1); 0 <= i; i--) {
				const option = this.optionsToDisplay[i];
				if (option.disabled) {
					continue;
				}
				else {
					prevEnabledOption = option;
					break;
				}
			}

			if (!prevEnabledOption) {
				for (let i = this.optionsToDisplay.length - 1; i >= index ; i--) {
					const option = this.optionsToDisplay[i];
					if (option.disabled) {
						continue;
					}
					else {
						prevEnabledOption = option;
						break;
					}
				}
			}
		}

		return prevEnabledOption;
	}

	findNextEnabledOption(index) {
		let nextEnabledOption;

		if (this.optionsToDisplay && this.optionsToDisplay.length) {
			for (let i = (index + 1); index < (this.optionsToDisplay.length - 1); i++) {
				const option = this.optionsToDisplay[i];
				if (option.disabled) {
					continue;
				}
				else {
					nextEnabledOption = option;
					break;
				}
			}

			if (!nextEnabledOption) {
				for (let i = 0; i < index; i++) {
					const option = this.optionsToDisplay[i];
					if (option.disabled) {
						continue;
					}
					else {
						nextEnabledOption = option;
						break;
					}
				}
			}
		}

		return nextEnabledOption;
	}

	onKeydown(event: KeyboardEvent, search: boolean) {
		if (this.readonly || !this.optionsToDisplay || this.optionsToDisplay.length === null) {
			return;
		}

		// tslint:disable-next-line: deprecation
		switch(event.which) {
			// down
			case 40:
				if (!this.overlayVisible && event.altKey) {
					this.show();
				}
				else {
					if (this.group) {
						const selectedItemIndex = this.selectedOption ? this.findOptionGroupIndex(this.selectedOption.value, this.optionsToDisplay) : -1;

						if (selectedItemIndex !== -1) {
							const nextItemIndex = selectedItemIndex.itemIndex + 1;
							if (nextItemIndex < (this.optionsToDisplay[selectedItemIndex.groupIndex].items.length)) {
								this.selectItem(event, this.optionsToDisplay[selectedItemIndex.groupIndex].items[nextItemIndex]);
								this.selectedOptionUpdated = true;
							}
							else if (this.optionsToDisplay[selectedItemIndex.groupIndex + 1]) {
								this.selectItem(event, this.optionsToDisplay[selectedItemIndex.groupIndex + 1].items[0]);
								this.selectedOptionUpdated = true;
							}
						}
						else {
							this.selectItem(event, this.optionsToDisplay[0].items[0]);
						}
					}
					else {
						const selectedItemIndex = this.selectedOption ? this.findOptionIndex(this.selectedOption.value, this.optionsToDisplay) : -1;
						const nextEnabledOption = this.findNextEnabledOption(selectedItemIndex);
						if (nextEnabledOption) {
							this.selectItem(event, nextEnabledOption);
							this.selectedOptionUpdated = true;
						}
					}
				}

				event.preventDefault();

			break;

			// up
			case 38:
				if (this.group) {
					const selectedItemIndex = this.selectedOption ? this.findOptionGroupIndex(this.selectedOption.value, this.optionsToDisplay) : -1;
					if (selectedItemIndex !== -1) {
						const prevItemIndex = selectedItemIndex.itemIndex - 1;
						if (prevItemIndex >= 0) {
							this.selectItem(event, this.optionsToDisplay[selectedItemIndex.groupIndex].items[prevItemIndex]);
							this.selectedOptionUpdated = true;
						}
						else if (prevItemIndex < 0) {
							const prevGroup = this.optionsToDisplay[selectedItemIndex.groupIndex - 1];
							if (prevGroup) {
								this.selectItem(event, prevGroup.items[prevGroup.items.length - 1]);
								this.selectedOptionUpdated = true;
							}
						}
					}
				}
				else {
					const selectedItemIndex = this.selectedOption ? this.findOptionIndex(this.selectedOption.value, this.optionsToDisplay) : -1;
					const prevEnabledOption = this.findPrevEnabledOption(selectedItemIndex);
					if (prevEnabledOption) {
						this.selectItem(event, prevEnabledOption);
						this.selectedOptionUpdated = true;
					}
				}

				event.preventDefault();
			break;

			// space
			case 32:
			case 32:
				if (!this.overlayVisible){
					this.show();
					event.preventDefault();
				}
			break;

			// enter
			case 13:
				if (!this.filter || (this.optionsToDisplay && this.optionsToDisplay.length > 0)) {
					this.hide(event);
				}

				event.preventDefault();
			break;

			// escape and tab
			case 27:
			case 9:
				this.hide(event);
			break;

			// search item based on keyboard input
			default:
				if (search) {
					this.search(event);
				}
			break;
		}
	}

	search(event) {
		if (this.searchTimeout) {
			clearTimeout(this.searchTimeout);
		}

		const char = event.key;
		this.previousSearchChar = this.currentSearchChar;
		this.currentSearchChar = char;

		if (this.previousSearchChar === this.currentSearchChar)
			this.searchValue = this.currentSearchChar;
		else
			this.searchValue = this.searchValue ? this.searchValue + char : char;

		let newOption;
		if (this.group) {
			const searchIndex = this.selectedOption
				? this.findOptionGroupIndex(this.selectedOption.value, this.optionsToDisplay) : {groupIndex: 0, itemIndex: 0};
			newOption = this.searchOptionWithinGroup(searchIndex);
		}
		else {
			let searchIndex = this.selectedOption ? this.findOptionIndex(this.selectedOption.value, this.optionsToDisplay) : -1;
			newOption = this.searchOption(++searchIndex);
		}

		if (newOption && !newOption.disabled) {
			this.selectItem(event, newOption);
			this.selectedOptionUpdated = true;
		}

		this.searchTimeout = setTimeout(() => {
			this.searchValue = null;
		}, 250);
	}

	searchOption(index) {
		let option;

		if (this.searchValue) {
			option = this.searchOptionInRange(index, this.optionsToDisplay.length);

			if (!option) {
				option = this.searchOptionInRange(0, index);
			}
		}

		return option;
	}

	searchOptionInRange(start, end) {
		for (let i = start; i < end; i++) {
			const opt = this.optionsToDisplay[i];
			if (opt.label.toLocaleLowerCase(this.filterLocale).startsWith((this.searchValue as any)
				.toLocaleLowerCase(this.filterLocale)) && !opt.disabled) {
				return opt;
			}
		}

		return null;
	}

	searchOptionWithinGroup(index) {
		// let option;

		if (this.searchValue) {
			for (let i = index.groupIndex; i < this.optionsToDisplay.length; i++) {
				for (let j = (index.groupIndex === i) ? (index.itemIndex + 1) : 0; j < this.optionsToDisplay[i].items.length; j++) {
					const opt = this.optionsToDisplay[i].items[j];
					if (opt.label.toLocaleLowerCase(this.filterLocale).startsWith((this.searchValue as any)
						.toLocaleLowerCase(this.filterLocale)) && !opt.disabled) {
						return opt;
					}
				}
			}

			// if (!option) {
			// 	for (let i = 0; i <= index.groupIndex; i++) {
			// 		for (let j = 0; j < ((index.groupIndex === i) ? index.itemIndex : this.optionsToDisplay[i].items.length); j++) {
			// 			const opt = this.optionsToDisplay[i].items[j];
			// 			if (opt.label.toLocaleLowerCase(this.filterLocale).startsWith((this.searchValue as any)
			// 				.toLocaleLowerCase(this.filterLocale)) && !opt.disabled) {
			// 				return opt;
			// 			}
			// 		}
			// 	}
			// }
		}

		return null;
	}

	findOptionIndex(val: any, opts: any[]): number {
		let index = -1;
		if (opts) {
			for (let i = 0; i < opts.length; i++) {
				if ((val == null && opts[i].value == null) || ObjectUtils.equals(val, opts[i].value, this.dataKey)) {
					index = i;
					break;
				}
			}
		}

		return index;
	}

	findOptionGroupIndex(val: any, opts: any[]): any {
		let groupIndex;
		let itemIndex;

		if (opts) {
			for (let i = 0; i < opts.length; i++) {
				groupIndex = i;
				itemIndex = this.findOptionIndex(val, opts[i].items);

				if (itemIndex !== -1) {
					break;
				}
			}
		}

		if (itemIndex !== -1) {
			return {groupIndex, itemIndex};
		}
		else {
			return -1;
		}
	}

	findOption(val: any, opts: any[], inGroup?: boolean): SelectItem {
		if (this.group && !inGroup) {
			let opt: SelectItem;
			if (opts && opts.length) {
				for (const optgroup of opts) {
					opt = this.findOption(val, optgroup.items, true);
					if (opt) {
						break;
					}
				}
			}
			return opt;
		}
		else {
			const index: number = this.findOptionIndex(val, opts);
			return (index !== -1) ? opts[index] : null;
		}
	}

	onFilter(event): void {
		const inputValue = event.target.value;
		if (inputValue && inputValue.length) {
			this.filterValue = inputValue;
			this.activateFilter();
		}
		else {
			this.filterValue = null;
			this.optionsToDisplay = this.options;
		}

		this.optionsChanged = true;
	}

	activateFilter() {
		const searchFields: string[] = this.filterBy.split(',');

		if (this.options && this.options.length) {
			if (this.group) {
				const filteredGroups = [];
				for (const optgroup of this.options) {
					const filteredSubOptions = FilterUtils.filter(optgroup.items, searchFields, this.filterValue, this.filterMatchMode, this.filterLocale);
					if (filteredSubOptions && filteredSubOptions.length) {
						filteredGroups.push({
							label: optgroup.label,
							value: optgroup.value,
							items: filteredSubOptions
						});
					}
				}

				this.optionsToDisplay = filteredGroups;
			}
			else {
				this.optionsToDisplay = FilterUtils.filter(this.options, searchFields, this.filterValue, this.filterMatchMode, this.filterLocale);
			}

			this.optionsChanged = true;
		}
	}

	applyFocus(): void {
		if (this.editable)
			DomHandler.findSingle(this.el.nativeElement, '.p-dropdown-label.p-inputtext').focus();
		else
			DomHandler.findSingle(this.el.nativeElement, 'input[readonly]').focus();
	}

	focus(): void {
		this.applyFocus();
	}

	bindDocumentClickListener() {
		if (!this.documentClickListener) {
			this.documentClickListener = this.renderer.listen('document', 'click', (event) => {
				if (this.isOutsideClicked(event)) {
					this.hide(event);
					this.unbindDocumentClickListener();
				}

				this.cd.markForCheck();
			});
		}
	}

	unbindDocumentClickListener() {
		if (this.documentClickListener) {
			this.documentClickListener();
			this.documentClickListener = null;
		}
	}

	bindDocumentResizeListener() {
		this.documentResizeListener = this.onWindowResize.bind(this);
		window.addEventListener('resize', this.documentResizeListener);
	}

	unbindDocumentResizeListener() {
		if (this.documentResizeListener) {
			window.removeEventListener('resize', this.documentResizeListener);
			this.documentResizeListener = null;
		}
	}

	onWindowResize() {
		if (!DomHandler.isAndroid()) {
			// tslint:disable-next-line: deprecation
			this.hide(event);
		}
	}

	updateFilledState() {
		this.filled = (this.selectedOption != null);
	}

	clear(event: Event) {
		this.value = null;
		this.onModelChange(this.value);
		this.onChange.emit({
			originalEvent: event,
			value: this.value
		});
		this.updateSelectedOption(this.value);
		this.updateEditableLabel();
		this.updateFilledState();
	}

	onOverlayHide() {
		this.unbindDocumentClickListener();
		this.unbindDocumentResizeListener();
		this.overlay = null;
		this.itemsWrapper = null;
		this.onModelTouched();
	}

	ngOnDestroy() {
		this.restoreOverlayAppend();
		this.onOverlayHide();
	}

}


// @NgModule({
// 	imports: [CommonModule, ScrollingModule, TooltipDirective, RippleComponent],
// 	exports: [DropDownComponent, ScrollingModule],
// 	declarations: [DropDownComponent,DropdownItemComponent]
// })
// export class DropdownModule { }