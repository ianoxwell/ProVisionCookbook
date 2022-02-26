import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AdminRights } from '@models/common.model';
import { User } from '@models/user';
import { LoginService } from '@services/login.service';
import { of } from 'rxjs';
import { debounceTime, filter, map, switchMap, takeUntil, tap } from 'rxjs/operators';
import { filterNullish } from 'src/app/utils/filter-nullish';
import { UserProfileService } from '../../services/user-profile.service';
import { ComponentBase } from '../base/base.component.base';

@Component({
	selector: 'app-header',
	templateUrl: './app-header.component.html',
	styleUrls: ['./app-header.component.scss']
})
export class AppHeaderComponent extends ComponentBase implements OnInit {
	profile: any = null;

	mainMenuItems = [
		// commented out to improve completeness in the short term - add back in as features become available.
		// { link: '/savoury/shopping', icon: 'shopping_cart', text: 'Shopping List' },
		// { link: '/savoury/calendar', icon: 'book', text: 'Recipe Calendar' },
		{ link: '/savoury/recipes/browse', icon: 'assignment', text: 'Recipes' },
		{ link: '/savoury/ingredients', icon: 'list_alt', text: 'Ingredients' }
	];

	adminRights: AdminRights = {
		globalAdmin: false,
		schoolAdmin: []
	};

	constructor(public userProfileService: UserProfileService, private loginService: LoginService, private router: Router) {
		super();
	}

	ngOnInit(): void {
		this.userProfileService.isLoggedIn
			.pipe(
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
				switchMap((profile: User | null) => {
					this.profile = profile;
					if (profile === null) {
						return this.loginService.getSingleUserProfile();
					}
					return of(profile);
				}),
				// On logout - profile is reverted to null - no need to keep going.
				filterNullish(),
				tap((profile: User) => {
					this.adminRights = this.userProfileService.checkAdminRights(profile);
				}),
				takeUntil(this.ngUnsubscribe)
			)
			.subscribe();
	}

	/**
	 * Signs current user out.
	 */
	signOut(): void {
		this.loginService.hardLogout(true);
		// ensure that the jwt and social auth have enough time to clear
		setTimeout(() => {
			console.log('log out route');
			this.router.navigate(['/account/login']);
		}, 1200);
	}
}
