import { Component, OnInit } from '@angular/core';
import {  debounceTime, filter, map, switchMap, takeUntil, tap } from 'rxjs/operators';
import { ComponentBase } from '../base/base.component.base';
import { UserProfileService } from '../../services/user-profile.service';
import { LoginService } from '@services/login.service';
import { User } from '@models/user';
import { Router } from '@angular/router';
import { of } from 'rxjs';
import { AdminRights } from '@models/common.model';


@Component({
  selector: 'app-header',
  templateUrl: './app-header.component.html',
  styleUrls: ['./app-header.component.scss']
})
export class AppHeaderComponent extends ComponentBase implements OnInit {
	profile: any = null;

	mainMenuItems = [
		{ link: '/savoury/shopping', icon: 'shopping_cart', text: 'Shopping List' },
		{ link: '/savoury/calendar', icon: 'book', text: 'Recipe Calendar' },
		{ link: '/savoury/recipes/browse', icon: 'assignment', text: 'Recipes' },
		{ link: '/savoury/ingredients', icon: 'list_alt', text: 'Ingredients' },
	];

	adminRights: AdminRights = {
		globalAdmin: false,
		schoolAdmin: []
	}

	constructor(
		public userProfileService: UserProfileService,
		private loginService: LoginService,
		private router: Router
	) { super(); }

	ngOnInit() {
		this.userProfileService.isLoggedIn.pipe(
			// allow for UserProfile states to settle
			debounceTime(250),
			map((isLoggedIn: boolean) => {
				let actuallyLoggedIn = isLoggedIn;
				// on a refresh the isLoggedIn state is null - check the jwt and update the status
				if (isLoggedIn === null) {
					actuallyLoggedIn = this.loginService.isAuthenticated();
					this.userProfileService.setLoggedIn(actuallyLoggedIn);
				}
				return actuallyLoggedIn;
			}),
			// if not logged in, leave the userProfile alone
			filter((actuallyLoggedIn: boolean) => actuallyLoggedIn),
			switchMap(() => this.userProfileService.currentData),
			switchMap((profile: User) => {
				if (profile === null) {
					return this.loginService.getSingleUserProfile();
				}
				return of(profile);
			}),
			tap(profile => {
				this.profile = profile;
				this.adminRights = this.userProfileService.checkAdminRights(profile);
			}),
			takeUntil(this.ngUnsubscribe),
		).subscribe();
	}

	signOut(): void {
		this.loginService.hardLogout(true);
		// ensure that the jwt and social auth have enough time to clear
		setTimeout(() => this.router.navigate(['/account/login']), 750);
	}

}
