import { Component, OnInit } from '@angular/core';
import { PageTitleService } from '@services/page-title.service';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-page-title',
  templateUrl: './page-title.component.html',
  styleUrls: ['./page-title.component.scss']
})
export class PageTitleComponent implements OnInit {

	pageTitle$: Observable<string>;

  constructor(
	  private pageTitleService: PageTitleService
  ) { }

  ngOnInit() {
	this.pageTitle$ = this.pageTitleService.pageTitle$;
  }

}
