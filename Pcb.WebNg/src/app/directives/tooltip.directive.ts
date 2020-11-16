import { Directive, Input, ElementRef, NgZone, AfterViewInit, OnDestroy } from '@angular/core';
import { DomHandler } from '@components/dom/domhandler';

@Directive({
  selector: '[appTooltip]'
})
export class TooltipDirective implements AfterViewInit, OnDestroy {

	@Input() tooltipPosition = 'right';

	@Input() tooltipEvent = 'hover';

	@Input() appendTo: any = 'body';

	@Input() positionStyle: string;

	@Input() tooltipStyleClass: string;

	@Input() tooltipZIndex = 'auto';

	@Input() escape = true;

	@Input() showDelay: number;

	@Input() hideDelay: number;

	@Input() life: number;

	@Input('tooltipDisabled') get disabled(): boolean {
		return this._disabled;
	}
	set disabled(val:boolean) {
		this._disabled = val;
		this.deactivate();
	}

	_disabled: boolean;

	container: any;

	styleClass: string;

	tooltipText: any;

	showTimeout: any;

	hideTimeout: any;

	active: boolean;

	_text: string;

	mouseEnterListener: any = () => {};

	mouseLeaveListener: any = () => {};

	clickListener: any = () => {};

	focusListener: any = () => {};

	blurListener: any = () => {};

	resizeListener: any = () => {};

	constructor(public el: ElementRef, public zone: NgZone) { }

	ngAfterViewInit() {
		this.zone.runOutsideAngular(() => {
			if (this.tooltipEvent === 'hover') {
				this.mouseEnterListener = this.onMouseEnter.bind(this);
				this.mouseLeaveListener = this.onMouseLeave.bind(this);
				this.clickListener = this.onClick.bind(this);
				this.el.nativeElement.addEventListener('mouseenter', this.mouseEnterListener);
				this.el.nativeElement.addEventListener('mouseleave', this.mouseLeaveListener);
				this.el.nativeElement.addEventListener('click', this.clickListener);
			}
			else if (this.tooltipEvent === 'focus') {
				this.focusListener = this.onFocus.bind(this);
				this.blurListener = this.onBlur.bind(this);
				this.el.nativeElement.addEventListener('focus', this.focusListener);
				this.el.nativeElement.addEventListener('blur', this.blurListener);
			}
		});
	}

	onMouseEnter(e: Event) {
		if (!this.container && !this.showTimeout) {
			this.activate();
		}
	}

	onMouseLeave(e: Event) {
		this.deactivate();
	}

	onFocus(e: Event) {
		this.activate();
	}

	onBlur(e: Event) {
		this.deactivate();
	}

	onClick(e: Event) {
		this.deactivate();
	}

	activate() {
		this.active = true;
		this.clearHideTimeout();

		if (this.showDelay)
			this.showTimeout = setTimeout(() => { this.show() }, this.showDelay);
		else
			this.show();

		if (this.life) {
			const duration = this.showDelay ? this.life + this.showDelay : this.life;
			this.hideTimeout = setTimeout(() => { this.hide() }, duration);
		}
	}

	deactivate() {
		this.active = false;
		this.clearShowTimeout();

		if (this.hideDelay) {
			this.clearHideTimeout();    // life timeout
			this.hideTimeout = setTimeout(() => { this.hide() }, this.hideDelay);
		}
		else {
			this.hide();
		}
	}

	get text(): string {
		return this._text;
	}

	@Input('appTooltip') set text(text: string) {
		this._text = text;
		if (this.active) {
			if (this._text) {
				if (this.container && this.container.offsetParent) {
					this.updateText();
					this.align();
				}
				else {
					this.show();
				}
			}
			else {
				this.hide();
			}
		}
	}

	create() {
		if (this.container) {
			this.clearHideTimeout();
			this.remove();
		}

		this.container = document.createElement('div');

		const tooltipArrow = document.createElement('div');
		tooltipArrow.className = 'p-tooltip-arrow';
		this.container.appendChild(tooltipArrow);

		this.tooltipText = document.createElement('div');
		this.tooltipText.className = 'p-tooltip-text';

		this.updateText();

		if (this.positionStyle) {
			this.container.style.position = this.positionStyle;
		}

		this.container.appendChild(this.tooltipText);

		if (this.appendTo === 'body')
			document.body.appendChild(this.container);
		else if (this.appendTo === 'target')
			DomHandler.appendChild(this.container, this.el.nativeElement);
		else
			DomHandler.appendChild(this.container, this.appendTo);

		this.container.style.display = 'inline-block';
	}

	show() {
		if (!this.text || this.disabled) {
			return;
		}

		this.create();
		this.align();
		DomHandler.fadeIn(this.container, 250);

		if (this.tooltipZIndex === 'auto')
			this.container.style.zIndex = ++DomHandler.zindex;
		else
			this.container.style.zIndex = this.tooltipZIndex;

		this.bindDocumentResizeListener();
	}

	hide() {
		this.remove();
	}

	updateText() {
		if (this.escape) {
			this.tooltipText.innerHTML = '';
			this.tooltipText.appendChild(document.createTextNode(this._text));
		}
		else {
			this.tooltipText.innerHTML = this._text;
		}
	}

	align() {
		const position = this.tooltipPosition;

		switch (position) {
			case 'top':
				this.alignTop();
				if (this.isOutOfBounds()) {
					this.alignBottom();
					if (this.isOutOfBounds()) {
						this.alignRight();

						if (this.isOutOfBounds()) {
							this.alignLeft();
						}
					}
				}
				break;

			case 'bottom':
				this.alignBottom();
				if (this.isOutOfBounds()) {
					this.alignTop();
					if (this.isOutOfBounds()) {
						this.alignRight();

						if (this.isOutOfBounds()) {
							this.alignLeft();
						}
					}
				}
				break;

			case 'left':
				this.alignLeft();
				if (this.isOutOfBounds()) {
					this.alignRight();

					if (this.isOutOfBounds()) {
						this.alignTop();

						if (this.isOutOfBounds()) {
							this.alignBottom();
						}
					}
				}
				break;

			case 'right':
				this.alignRight();
				if (this.isOutOfBounds()) {
					this.alignLeft();

					if (this.isOutOfBounds()) {
						this.alignTop();

						if (this.isOutOfBounds()) {
							this.alignBottom();
						}
					}
				}
				break;
		}
	}

	getHostOffset() {
		if (this.appendTo === 'body' || this.appendTo === 'target') {
			const offset = this.el.nativeElement.getBoundingClientRect();
			const targetLeft = offset.left + DomHandler.getWindowScrollLeft();
			const targetTop = offset.top + DomHandler.getWindowScrollTop();

			return { left: targetLeft, top: targetTop };
		}
		else {
			return { left: 0, top: 0 };
		}
	}

	alignRight() {
		this.preAlign('right');
		const hostOffset = this.getHostOffset();
		const left = hostOffset.left + DomHandler.getOuterWidth(this.el.nativeElement);
		const top = hostOffset.top + (DomHandler.getOuterHeight(this.el.nativeElement) - DomHandler.getOuterHeight(this.container)) / 2;
		this.container.style.left = left + 'px';
		this.container.style.top = top + 'px';
	}

	alignLeft() {
		this.preAlign('left');
		const hostOffset = this.getHostOffset();
		const left = hostOffset.left - DomHandler.getOuterWidth(this.container);
		const top = hostOffset.top + (DomHandler.getOuterHeight(this.el.nativeElement) - DomHandler.getOuterHeight(this.container)) / 2;
		this.container.style.left = left + 'px';
		this.container.style.top = top + 'px';
	}

	alignTop() {
		this.preAlign('top');
		const hostOffset = this.getHostOffset();
		const left = hostOffset.left + (DomHandler.getOuterWidth(this.el.nativeElement) - DomHandler.getOuterWidth(this.container)) / 2;
		const top = hostOffset.top - DomHandler.getOuterHeight(this.container);
		this.container.style.left = left + 'px';
		this.container.style.top = top + 'px';
	}

	alignBottom() {
		this.preAlign('bottom');
		const hostOffset = this.getHostOffset();
		const left = hostOffset.left + (DomHandler.getOuterWidth(this.el.nativeElement) - DomHandler.getOuterWidth(this.container)) / 2;
		const top = hostOffset.top + DomHandler.getOuterHeight(this.el.nativeElement);
		this.container.style.left = left + 'px';
		this.container.style.top = top + 'px';
	}

	preAlign(position: string) {
		this.container.style.left = -999 + 'px';
		this.container.style.top = -999 + 'px';

		const defaultClassName = 'p-tooltip p-component p-tooltip-' + position;
		this.container.className = this.tooltipStyleClass ? defaultClassName + ' ' + this.tooltipStyleClass : defaultClassName;
	}

	isOutOfBounds(): boolean {
		const offset = this.container.getBoundingClientRect();
		const targetTop = offset.top;
		const targetLeft = offset.left;
		const width = DomHandler.getOuterWidth(this.container);
		const height = DomHandler.getOuterHeight(this.container);
		const viewport = DomHandler.getViewport();

		return (targetLeft + width > viewport.width) || (targetLeft < 0) || (targetTop < 0) || (targetTop + height > viewport.height);
	}

	onWindowResize(e: Event) {
		this.hide();
	}

	bindDocumentResizeListener() {
		this.zone.runOutsideAngular(() => {
			this.resizeListener = this.onWindowResize.bind(this);
			window.addEventListener('resize', this.resizeListener);
		});
	}

	unbindDocumentResizeListener() {
		if (this.resizeListener) {
			window.removeEventListener('resize', this.resizeListener);
			this.resizeListener = null;
		}
	}

	unbindEvents() {
		if (this.tooltipEvent === 'hover') {
			this.el.nativeElement.removeEventListener('mouseenter', this.mouseEnterListener);
			this.el.nativeElement.removeEventListener('mouseleave', this.mouseLeaveListener);
			this.el.nativeElement.removeEventListener('click', this.clickListener);
		}
		else if (this.tooltipEvent === 'focus') {
			this.el.nativeElement.removeEventListener('focus', this.focusListener);
			this.el.nativeElement.removeEventListener('blur', this.blurListener);
		}

		this.unbindDocumentResizeListener();
	}

	remove() {
		if (this.container && this.container.parentElement) {
			if (this.appendTo === 'body')
				document.body.removeChild(this.container);
			else if (this.appendTo === 'target')
				this.el.nativeElement.removeChild(this.container);
			else
				DomHandler.removeChild(this.container, this.appendTo);
		}

		this.unbindDocumentResizeListener();
		this.clearTimeouts();
		this.container = null;
	}

	clearShowTimeout() {
		if (this.showTimeout) {
			clearTimeout(this.showTimeout);
			this.showTimeout = null;
		}
	}

	clearHideTimeout() {
		if (this.hideTimeout) {
			clearTimeout(this.hideTimeout);
			this.hideTimeout = null;
		}
	}

	clearTimeouts() {
		this.clearShowTimeout();
		this.clearHideTimeout();
	}

	ngOnDestroy() {
		this.unbindEvents();
		this.remove();
	}

}