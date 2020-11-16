import { Component, AfterViewInit, OnDestroy, ElementRef, NgZone, NgModule } from '@angular/core';
import { DomHandler } from '@components/dom/domhandler';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-ripple',
  template: '',
  styleUrls: ['./ripple.component.scss']
})
export class RippleComponent implements AfterViewInit, OnDestroy {

		constructor(
			public el: ElementRef,
			public zone: NgZone,
		) { }

		animationListener: any;

		mouseDownListener: any;

		ngAfterViewInit() {
			this.zone.runOutsideAngular(() => {
				this.create();

				this.mouseDownListener = this.onMouseDown.bind(this);
				this.el.nativeElement.addEventListener('mousedown', this.mouseDownListener);
			});
		}

		onMouseDown(event: MouseEvent) {
			const ink = this.getInk();
			if (!ink || getComputedStyle(ink, null).display === 'none') {
				return;
			}

			DomHandler.removeClass(ink, 'p-ink-active');
			if (!DomHandler.getHeight(ink) && !DomHandler.getWidth(ink)) {
				const d = Math.max(DomHandler.getOuterWidth(this.el.nativeElement), DomHandler.getOuterHeight(this.el.nativeElement));
				ink.style.height = d + 'px';
				ink.style.width = d + 'px';
			}

			const offset = DomHandler.getOffset(this.el.nativeElement);
			const x = event.pageX - offset.left + document.body.scrollTop - DomHandler.getWidth(ink) / 2;
			const y = event.pageY - offset.top + document.body.scrollLeft - DomHandler.getHeight(ink) / 2;

			ink.style.top = y + 'px';
			ink.style.left = x + 'px';
			DomHandler.addClass(ink, 'p-ink-active');
		}

		getInk() {
			const children = this.el.nativeElement.children;
			if (!!children) {
				return children.find((child) => child.className.indexOf('p-ink') !== -1);
			}
			return null;
		}

		resetInk() {
			const ink = this.getInk();
			if (ink) {
				DomHandler.removeClass(ink, 'p-ink-active');
			}
		}

		onAnimationEnd(event) {
			DomHandler.removeClass(event.currentTarget, 'p-ink-active');
		}

		create() {
			const ink = document.createElement('span');
			ink.className = 'p-ink';
			this.el.nativeElement.appendChild(ink);

			this.animationListener = this.onAnimationEnd.bind(this);
			ink.addEventListener('animationend', this.animationListener);
		}

		remove() {
			const ink = this.getInk();
			if (ink) {
				this.el.nativeElement.removeEventListener('mousedown', this.mouseDownListener);
				ink.removeEventListener('animationend', this.animationListener);
				ink.remove();
			}
		}

		ngOnDestroy() {
			this.remove();
		}
	}

	@NgModule({
		imports: [CommonModule],
		exports: [RippleComponent],
		declarations: [RippleComponent]
	})
	export class RippleModule { }

