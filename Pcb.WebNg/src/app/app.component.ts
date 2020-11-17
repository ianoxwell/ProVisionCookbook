 import { Component, OnInit } from '@angular/core';
 import { Store } from '@ngrx/store';
 import * as fromRoot from './store/reducers';
 import * as FilterPayloadActions from './store/action/filter-payload.actions';
import { PageTitleService } from '@services/page-title.service';
import { SvgIconRegistry } from '@ngneat/svg-icon';
import { takeUntil } from 'rxjs/operators';
import { ComponentBase } from '@components/base/base.component.base';

 @Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})

export class AppComponent extends ComponentBase implements OnInit {
	constructor(
		private store: Store<fromRoot.State>,
		private pageTitleService: PageTitleService,
		registry: SvgIconRegistry) {
			super();
			registry.register({ settings: `<svg>...</svg>`});
			registry.getAll();
		  }

	ngOnInit() {
		this.store.dispatch(new FilterPayloadActions.LoadFilterPayloads());
		this.pageTitleService.listen().pipe(
			takeUntil(this.ngUnsubscribe)
		).subscribe();
	}
}
