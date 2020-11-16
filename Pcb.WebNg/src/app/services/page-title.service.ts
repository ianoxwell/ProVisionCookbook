import { Injectable } from '@angular/core';
import { Router, ActivatedRoute, NavigationEnd } from '@angular/router';
import { Title } from '@angular/platform-browser';
import { filter, map, switchMap } from 'rxjs/operators';
import { LiveAnnouncer } from '@angular/cdk/a11y';
import { BehaviorSubject } from 'rxjs';

@Injectable({
	providedIn: 'root',
})
export class PageTitleService {
	defaultTitle = `Provisioner's Cookbook`;
	pageTitleSubject$ = new BehaviorSubject<string>(null);

	pageTitle$ = this.pageTitleSubject$.asObservable();

	constructor(
		private router: Router,
		private activeRoute: ActivatedRoute,
		private title: Title,
		private liveAnnouncer: LiveAnnouncer
	) { }

	listen() {
		this.router.events
			.pipe(
				filter(event => event instanceof NavigationEnd),
				map(() => this.activeRoute),
				map(route => {
					while (route.firstChild) {
						route = route.firstChild;
					}
					return route;
				}),
				switchMap(route => route.data),
				map(data => (data && data.title) ? data.title : this.defaultTitle)
			)
			.subscribe(title => this.setTitle(title));
	}

	setTitle(title: string) {
		if (title) {
			const fullTitle = `${title}`;
			this.title.setTitle(fullTitle);
			this.pageTitleSubject$.next(fullTitle);
			this.liveAnnouncer.announce(fullTitle);
		}
	}

	// action to announce for screen reader the page title
	announceTitle(): void {
		this.liveAnnouncer.announce(this.title.getTitle());
	}

	// return the current page title
	getTitle(): string {
		return this.title.getTitle();
	}
}
