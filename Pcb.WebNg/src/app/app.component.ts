import { Component, OnInit } from '@angular/core';
import { ComponentBase } from '@components/base/base.component.base';
import { SvgIconRegistry } from '@ngneat/svg-icon';
import { PageTitleService } from '@services/page-title.service';
import { takeUntil } from 'rxjs/operators';

 @Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})

export class AppComponent extends ComponentBase implements OnInit {
	constructor(
		private pageTitleService: PageTitleService,
		registry: SvgIconRegistry) {
			super();
			registry.register({ settings: `<svg>...</svg>`});
			registry.getAll();
		  }

	ngOnInit() {
		this.pageTitleService.listen().pipe(
			takeUntil(this.ngUnsubscribe)
		).subscribe();
	}
}
