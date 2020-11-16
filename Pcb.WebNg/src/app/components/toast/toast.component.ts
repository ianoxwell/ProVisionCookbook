import { Component,
	OnInit,
	AfterContentInit,
	OnDestroy,
	Input,
	Output,
	EventEmitter,
	ViewChild,
	ElementRef,
	TemplateRef } from '@angular/core';
import { trigger, transition, query, animateChild, AnimationEvent } from '@angular/animations';
import { Subscription } from 'rxjs';
import { MessageService } from '@services/message.service';
import { Message } from '@models/message.models';

@Component({
	selector: 'app-toast',
	templateUrl: './toast.component.html',
	styleUrls: ['./toast.component.scss'],
	animations: [
			trigger('toastAnimation', [
				transition(':enter, :leave', [
					query('@*', animateChild())
				])
			])
		]
})

// note - strongly based off of primeFaces - https://primefaces.org/primeng/showcase/#/toast
export class ToastComponent implements OnInit, AfterContentInit, OnDestroy {

	@Input() key: string;

	@Input() autoZIndex = true;

	@Input() baseZIndex = 0;

	@Input() style: any;

	@Input() styleClass: string;

	@Input() position = 'top-right';

	@Input() modal: boolean;

	@Input() showTransitionOptions = '300ms ease-out';

	@Input() hideTransitionOptions = '250ms ease-in';

	@Output() closeToast: EventEmitter<any> = new EventEmitter();

	@ViewChild('container', { static: false }) containerViewChild: ElementRef;

	messageSubscription: Subscription;

	clearSubscription: Subscription;

	messages: Message[];

	template: TemplateRef<any>;

	mask: HTMLDivElement;

	constructor(public messageService: MessageService) {}

	ngOnInit() {
		this.messageSubscription = this.messageService.messageObserver.subscribe((messages: Message | Message[]) => {
			if (messages) {
				if (messages instanceof Array) {
					const filteredMessages = messages.filter(m => this.key === m.key);
					this.messages = this.messages ? [...this.messages, ...filteredMessages] : [...filteredMessages];
				} else if (this.key === messages.key) {
					this.messages = this.messages ? [...this.messages, ...[messages]] : [messages];
				}

				if (this.modal && this.messages && this.messages.length) {
					this.enableModality();
				}
			}
		});

		this.clearSubscription = this.messageService.clearObserver.subscribe(key => {
			if (key) {
				if (this.key === key) {
					this.messages = null;
				}
			} else {
				this.messages = null;
			}

			if (this.modal) {
				this.disableModality();
			}
		});
	}

	ngAfterContentInit() {
		// this.templates.forEach((item) => {
		// 	switch (item.getType()) {
		// 		case 'message':
		// 			this.template = item.template;
		// 			break;

		// 		default:
		// 			this.template = item.template;
		// 			break;
		// 	}
		// });
	}

	onMessageClose(event) {
		this.messages.splice(event.index, 1);

		if (this.messages.length === 0) {
			this.disableModality();
		}

		this.closeToast.emit({
			message: event.message
		});
	}

	enableModality() {
		if (!this.mask) {
			this.mask = document.createElement('div');
			this.mask.style.zIndex = String(Number(this.containerViewChild.nativeElement.style.zIndex) - 1);
			if (this.mask.classList) {
				this.mask.classList.add('ui-widget-overlay');
				this.mask.classList.add('ui-dialog-mask');
			} else {
				this.mask.className = 'ui-widget-overlay ui-dialog-mask';
			}
			document.body.appendChild(this.mask);
		}
	}

	disableModality() {
		if (this.mask) {
			document.body.removeChild(this.mask);
			this.mask = null;
		}
	}

	onAnimationStart(event: AnimationEvent) {
		if (event.fromState === 'void' && this.autoZIndex) {
			this.containerViewChild.nativeElement.style.zIndex = String(this.baseZIndex + 1000);
		}
	}

	ngOnDestroy() {
		if (this.messageSubscription) {
			this.messageSubscription.unsubscribe();
		}

		if (this.clearSubscription) {
			this.clearSubscription.unsubscribe();
		}

		this.disableModality();
	}
}
