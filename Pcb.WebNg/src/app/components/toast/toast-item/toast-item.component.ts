import { Component,  AfterViewInit, OnDestroy, Input, TemplateRef, Output, EventEmitter, ViewChild, ElementRef } from '@angular/core';
import { trigger, state, style, transition, animate } from '@angular/animations';
import { Message, MessageStatus } from '@models/message.models';


@Component({
	selector: 'app-toast-item',
	templateUrl: './toast-item.component.html',
	styleUrls: ['../toast.component.scss'],
	animations: [
			trigger('messageState', [
				state('visible', style({
					transform: 'translateY(0)',
					opacity: 1
				})),
				transition('void => *', [
					style({transform: 'translateY(100%)', opacity: 0}),
					animate('{{showTransitionParams}}')
				]),
				transition('* => void', [
					animate(('{{hideTransitionParams}}'), style({
						height: 0,
						opacity: 0,
						transform: 'translateY(-100%)'
					}))
				])
			])
		]
})
export class ToastItemComponent implements AfterViewInit, OnDestroy {
	@Input() message: Message;

	@Input() index: number;

	@Input() template: TemplateRef<any>;

	@Input() showTransitionOptions: string;

	@Input() hideTransitionOptions: string;

	@Output() closeToast: EventEmitter<any> = new EventEmitter();

	@ViewChild('container', { static: false }) containerViewChild: ElementRef;

	messageStatus = MessageStatus;

	timeout: any;

	ngAfterViewInit() {
		this.initTimeout();
		console.log('message', this.message);
	}

	initTimeout() {
		if (!this.message.sticky) {
			this.timeout = setTimeout(() => {
				this.closeToast.emit({
					index: this.index,
					message: this.message
				});
			}, this.message.life || 3000);
		}
	}

	clearTimeout() {
		if (this.timeout) {
			clearTimeout(this.timeout);
			this.timeout = null;
		}
	}

	onMouseEnter() {
		this.clearTimeout();
	}

	onMouseLeave() {
		this.initTimeout();
	}

	onCloseIconClick(event) {
		this.clearTimeout();

		this.closeToast.emit({
			index: this.index,
			message: this.message
		});

		event.preventDefault();
	}

	ngOnDestroy() {
		this.clearTimeout();
	}

	getIconName(severity: string): string {
		switch (severity) {
			case 'error': return 'error_outline'; break;
			case 'warning': return 'warning'; break;
			case 'alert': return 'add_alert'; break;
			case 'critical': return 'error'; break;
			case 'success': return 'done'; break;
			default: return ''; break;
		}
	}

}
