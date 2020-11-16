import { OnDestroy, Component } from '@angular/core';
import { Subject } from 'rxjs';

@Component({
	template: ''
})
// tslint:disable-next-line: component-class-suffix
export class ComponentBase implements OnDestroy {
	ngUnsubscribe: Subject<any> = new Subject();

	ngOnDestroy(): void {
		this.destroySubscriptions();
	}

	destroySubscriptions(): void {
		this.ngUnsubscribe.next();
		this.ngUnsubscribe.complete();
	}
}
