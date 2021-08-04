import { Component, OnInit } from '@angular/core';
import { ComponentBase } from '@components/base/base.component.base';
import { PageTitleService } from '@services/page-title.service';
import { takeUntil } from 'rxjs/operators';

@Component({
	selector: 'app-root',
	templateUrl: './app.component.html',
	styleUrls: ['./app.component.scss']
})
export class AppComponent extends ComponentBase implements OnInit {
	constructor(private pageTitleService: PageTitleService) {
		super();
	}
	ngOnInit(): void {
		this.pageTitleService.listen().pipe(takeUntil(this.ngUnsubscribe)).subscribe();
	}
}
