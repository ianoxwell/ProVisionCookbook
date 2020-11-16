import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
// import { AuthenticationService } from '../../services/authentication.service';
import { GoogleLoginProvider, SocialAuthService, SocialUser } from 'angularx-social-login';
import { ComponentBase } from '@components/base/base.component.base';
import { DialogService } from '@services/dialog.service';
import { HttpErrorResponse } from '@angular/common/http';
import { catchError, switchMap, takeUntil, tap } from 'rxjs/operators';
import { LoginService } from '@services/login.service';
import { of } from 'rxjs';
import { Router } from '@angular/router';
import { HttpStatusCode } from '@models/security.models';


@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent extends ComponentBase implements OnInit {
	googleUserData: SocialUser;
	loggedIn: boolean;

	constructor(
		// public auth: AuthenticationService,
		private authService: SocialAuthService,
		private dialogService: DialogService,
		private loginService: LoginService,
		private router: Router
	) { super(); }

	ngOnInit() {
		if (localStorage.getItem('google-user')){
			console.log('yep, google already authenticated', JSON.parse(localStorage.getItem('google-user')));
			// attempt to verify the token against the api
			this.getGoogleJwtToken();
		}
		this.authService.authState.pipe(
			tap((user) => {
				console.log('auth state Google change', user);
				if (user) {
					this.googleUserData = user;
					localStorage.setItem('google-user', JSON.stringify(this.googleUserData));
					JSON.parse(localStorage.getItem('user'));
					this.getGoogleJwtToken();
				} else {
					localStorage.setItem('google-user', null);
				}

				this.loggedIn = (user != null);
			}),
			catchError((err: HttpErrorResponse) => this.dialogService.alert('Error on Google login attempt', err)),
			takeUntil(this.ngUnsubscribe)
		).subscribe();
  	}

	  getGoogleJwtToken(){
		this.loginService.getTokenUsingGoogleToken(JSON.parse(localStorage.getItem('google-user'))).pipe(
			tap((response: boolean | string) => {
				if (!!response && typeof response === 'string') {
					console.log('user is not registered, redirecting');
					this.router.navigate(['/account/register']);
				} else {
					this.router.navigate(['/savoury/recipes']);
				}
			}),
			catchError((err: HttpErrorResponse) => {
				if (err.status === HttpStatusCode.Forbidden && err.statusText === 'OK') {
					console.log('403 response as likely the cached google token has expired');
					this.googleClear();
				}
				console.log('LoginError', err);
				return of();
			}),
			takeUntil(this.ngUnsubscribe)
		).subscribe();
	}
	googleClear(): void {
		localStorage.setItem('google-user', null);
	}

}
