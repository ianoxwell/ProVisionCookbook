import { Directive, ElementRef, Renderer2 } from '@angular/core';

@Directive({
	// tslint:disable-next-line: directive-selector
	selector: 'form'
})
export class FormAutocompleteDirective {

	constructor(
		private elRef: ElementRef,
		private renderer: Renderer2
	) {
		this.renderer.setAttribute(this.elRef.nativeElement, 'autocomplete', 'off');
	}

}
