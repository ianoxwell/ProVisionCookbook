import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Router } from '@angular/router';
import {Observable, of} from 'rxjs';

import { User } from '../models/user';
import { UserProfileService } from './user-profile.service';
import { takeUntil, tap, switchMap } from 'rxjs/operators';
import { ComponentBase } from '../components/base/base.component.base';
import { PagedResult } from '@models/common.model';
import { environment } from 'src/environments/environment';

@Injectable({
	providedIn: 'root'
})
export class UserService extends ComponentBase {
	private defaultHeader = new HttpHeaders()
		.set('Content-Type', 'application/json;odata=verbose')
		.set('Accept', 'application/json;odata=verbose');
	private apiURL = environment.apiUrl + environment.apiVersion;
	cookBookUserProfile: User;

	constructor(
		private router: Router,
		private userProfileService: UserProfileService,
		private httpClient: HttpClient
	) {
			super();
			// subscribe to any changes in the CookBookUserProfile
			this.userProfileService.currentData.pipe(
				tap(profile => this.cookBookUserProfile = profile),
				takeUntil(this.ngUnsubscribe),
			).subscribe();
	}
	newUser(newUser, user: any): User {
		newUser.email = user.email;
		newUser.picture = user.picture;
		newUser.email_verified = user.email_verified;
		newUser.firstLogon = true;
		newUser.dateFirstLogon = new Date();
		newUser.dateLastLogon = new Date();
		newUser.role = 'Student';
		// if user has signed onto Auth0 through social provider Google
		if (user.hasOwnProperty('sub') && user.sub.includes('google')) {
			newUser.firstName = user.given_name;
			newUser.lastName = user.family_name;
			newUser.fullName = user.name;
		} else {
			newUser.firstName = user.nickname;
		}
		return newUser;
	}
	// *
	// User Items - split out?
	// *
	// TODO add the query filters
	public getUsers(queryString: string | null): Observable<Array<User>> {
		return this.httpClient.get<Array<User>>(this.apiURL + 'admin/users' + queryString, {headers: this.defaultHeader});
	}
	public createUser(user: User): Observable<User> {
		return this.httpClient.post<User>(this.apiURL + 'admin/users/save', user,
		{headers: this.defaultHeader});
	}

	// TODO does this need its own end point and update process?
	public updateUser(userID: string, update: any): Observable<User> {
		return this.httpClient.put<User>(this.apiURL + 'admin/users/save' + userID, update,
			{headers: this.defaultHeader});
	}

	// TODO implement the API
	public deleteUser(userID: string): Observable<User> {
		return this.httpClient.delete<User>(this.apiURL + 'admin/users/' + userID, {headers: this.defaultHeader});
	}

	// TODO implement the API
	public getUserByEmail(emailString: string): Observable<PagedResult<User>> {
		return this.httpClient.get<PagedResult<User>>(this.apiURL + `user?filter=email%3D${emailString}`, {headers: this.defaultHeader});
	}

	public getUserById(userID: string): Observable<User> {
		return this.httpClient.get<User>(this.apiURL + 'admin/users/' + userID, {headers: this.defaultHeader});
	}



}
