import { Injectable } from '@angular/core';
import { AdminRights, IdTitlePair } from '@models/common.model';
import { BehaviorSubject, Observable } from 'rxjs';
import { User, UserRole } from '../models/user';

@Injectable({
		providedIn: 'root'
})
// example similar to https://angularfirebase.com/lessons/sharing-data-between-angular-components-four-methods/
// - Unrelated Components: Sharing Data with a Service
// example subscribe to any changes in the CookBookUserProfile
// this.userProfileService.currentData.subscribe(profile => this.cookBookUserProfile = profile);
// example to setData
// this.userProfileService.setData(usersCookBookProfile[0]);

export class UserProfileService {
	private userProfile$ = new BehaviorSubject<User>(null);
	private isLoggedIn$ = new BehaviorSubject<boolean>(null);


	currentData = this.userProfile$.asObservable();
	isLoggedIn = this.isLoggedIn$.asObservable();

	setData(userProfile: User) {
		this.userProfile$.next(userProfile);
	}

	setLoggedIn(isLoggedIn: boolean) {
		this.isLoggedIn$.next(isLoggedIn);
	}

	checkAdminRights(user: User): AdminRights {
		const schoolAdmin: IdTitlePair[] = [];
		let globalAdmin = false;
		user.userRole.forEach((roleItem: UserRole) => {
			if (roleItem.role.isAdmin && roleItem.isCountryWide) {
				globalAdmin = true;
			} else if (roleItem.role.isAdmin && !!roleItem.schoolId && !!roleItem.school) {
				schoolAdmin.push({id: roleItem.schoolId, title: roleItem.school.title});
			}
		});
		return {
			globalAdmin,
			schoolAdmin
		}
	}

}
