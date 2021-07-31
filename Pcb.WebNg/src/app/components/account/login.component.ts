import { HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ComponentBase } from '@components/base/base.component.base';
import { MessageStatus } from '@models/message.model';
import { HttpStatusCode } from '@models/security.models';
import { DialogService } from '@services/dialog.service';
import { LoginService } from '@services/login.service';
import { MessageService } from '@services/message.service';
// import { AuthenticationService } from '../../services/authentication.service';
import { SocialAuthService, SocialUser } from 'angularx-social-login';
import { of } from 'rxjs';
import { catchError, takeUntil, tap } from 'rxjs/operators';

@Component({
	selector: 'app-login',
	templateUrl: './login.component.html',
	styleUrls: ['./login.component.scss']
})
export class LoginComponent extends ComponentBase implements OnInit {
	googleUserData: SocialUser;
	loggedIn: boolean;
	isGettingJwt = false;

	constructor(
		private authService: SocialAuthService,
		private dialogService: DialogService,
		private loginService: LoginService,
		private router: Router,
		private messageService: MessageService
	) {
		super();
	}

	ngOnInit() {
		if (localStorage.getItem('google-user')) {
			// attempt to verify the token against the api
			this.getGoogleJwtToken();
		}
		this.listenAuthState();
	}

	/** Listens to the authService for the Social AuthService from angularx-social-login */
	listenAuthState(): void {
		this.authService.authState
			.pipe(
				tap((user: SocialUser) => {
					this.messageService.add({
						severity: MessageStatus.Success,
						summary: 'Authentication Successful',
						detail: 'Google Account Authenticated, attempting to logon to app.'
					});
					if (user) {
						this.googleUserData = user;
						localStorage.setItem('google-user', JSON.stringify(this.googleUserData));
						JSON.parse(localStorage.getItem('user'));
						this.getGoogleJwtToken();
					} else {
						localStorage.setItem('google-user', null);
					}

					this.loggedIn = user != null;
				}),
				catchError((err: HttpErrorResponse) => this.dialogService.alert('Error on Google login attempt', err)),
				takeUntil(this.ngUnsubscribe)
			)
			.subscribe();
	}

	/** Gets the JWT from the API using the Google Token for authentication. */
	getGoogleJwtToken(): void {
		this.isGettingJwt = true;
		this.loginService
			.getTokenUsingGoogleToken(JSON.parse(localStorage.getItem('google-user')))
			.pipe(
				tap((response: boolean | string) => {
					if (!!response && typeof response === 'string') {
						this.messageService.add({
							severity: MessageStatus.Information,
							summary: 'Registration required',
							detail: `We currently don't have an account registered to that address.`
						});
						this.router.navigate(['/account/register']);
					} else {
						this.router.navigate(['/savoury/recipes']);
					}
				}),
				catchError((err: HttpErrorResponse) => {
					if (err.status === HttpStatusCode.Forbidden && err.statusText === 'OK') {
						this.dialogService.alert(
							'403 response',
							'Likely the cached google token has expired, try refreshing browser and logging in with your Google account again.'
						);
						this.googleClear();
					}
					this.dialogService.alert('Login Error', err.message);
					this.isGettingJwt = false;
					return of();
				}),
				takeUntil(this.ngUnsubscribe)
			)
			.subscribe();
	}
	/** sets the localStorage cache of the google-user to null */
	googleClear(): void {
		localStorage.setItem('google-user', null);
	}
}
