 import { Component, OnInit } from '@angular/core';
 import { Store } from '@ngrx/store';
 import * as fromRoot from './store/reducers';
 import * as FilterPayloadActions from './store/action/filter-payload.actions';
import { PageTitleService } from '@services/page-title.service';
import { SvgIconRegistry } from '@ngneat/svg-icon';

 @Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})

export class AppComponent implements OnInit {
	title = 'CookBook';
	constructor(
		private store: Store<fromRoot.State>,
		private pageTitleService: PageTitleService,
		registry: SvgIconRegistry) {
			registry.register({ settings: `<svg>...</svg>`});
			registry.getAll();
		  }

	ngOnInit() {
		this.store.dispatch(new FilterPayloadActions.LoadFilterPayloads());
		this.pageTitleService.listen();
	}
}
