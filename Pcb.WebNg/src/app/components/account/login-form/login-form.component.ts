import { HttpErrorResponse } from '@angular/common/http';
import { ChangeDetectorRef, Component, ElementRef, EventEmitter, OnInit, Output, ViewChild } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ComponentBase } from '@components/base/base.component.base';
import { MessageResult } from '@models/common.model';
import { MessageStatus } from '@models/message.models';
import { HttpStatusCode } from '@models/security.models';
import { ValidationMessages } from '@models/static-variables';
import { User } from '@models/user';
import { LoginService } from '@services/login.service';
import { MessageService } from '@services/message.service';
import { UserProfileService } from '@services/user-profile.service';
import { GoogleLoginProvider, SocialAuthService } from 'angularx-social-login';
import { of } from 'rxjs';
import { catchError, takeUntil, tap } from 'rxjs/operators';


@Component({
  selector: 'app-login-form',
  templateUrl: './login-form.component.html',
  styleUrls: ['./login-form.component.scss']
})
export class LoginFormComponent extends ComponentBase implements OnInit {
	@ViewChild('passwordInput', {static: false}) passwordInput: ElementRef;
	loginForm: FormGroup;
	validationMessages = ValidationMessages;
	isSubmitting = false;
	constructor(
		private fb: FormBuilder,
		private authService: SocialAuthService,
		private loginService: LoginService,
		private router: Router,
		private messageService: MessageService,
		private userProfileService: UserProfileService,
		private cdr: ChangeDetectorRef
	) { super(); }

	ngOnInit(): void {
		this.createForm();
	}

	// convenience getter for easy access to form fields
	get f() { return this.loginForm.controls; }
	createForm() {
		// Create the controls for the reactive forms
		this.loginForm = this.fb.group({
			usernameControl: ['', [Validators.required, Validators.minLength(2), Validators.maxLength(120), Validators.email]],
			passwordControl: ['', [Validators.required, Validators.minLength(2)]],
			rememberControl: false
		});
	}
	rememberChange() {
		console.log('Im not going to remember you, terrible with names');
	}

	login() {
		this.isSubmitting = true;
		if (this.loginForm.invalid) { return null; }
		this.passwordInput.nativeElement.blur();
		const form = this.loginForm.getRawValue();
		this.loginService.login(form.usernameControl, form.passwordControl, false).pipe(
			tap((result: MessageResult) => {
				this.isSubmitting = false;
				if (result.message === 'Successful login') {
					this.router.navigate(['/savoury/recipes/browse']);

				} else if (result.message.indexOf('Lockout') > -1) {
					const lockOutAttempts: number = Number(result.message.substring(9));
					if (!!lockOutAttempts && lockOutAttempts > 4) {
						console.log('here we locking routing,', lockOutAttempts, `/account/forgot-password?email=${form.usernameControl}`);
						this.router.navigate(['/account/forgot-password'], {queryParams: {email: form.usernameControl} });
						this.messageService.add({
							severity: MessageStatus.Warning,
							summary: 'Lockout',
							detail: 'Please wait 20 minutes to try again or reset password.',
							life: 12000
						});
					}
				} else {
					this.messageService.add({
						severity: MessageStatus.Warning,
						summary: 'Login problem',
						detail: result.message,
						life: 12000
					});
				}
			}),
			catchError((err: HttpErrorResponse) => {
				this.isSubmitting = false;
				if (err.status === HttpStatusCode.BadRequest) {
					this.f.passwordControl.setErrors({wrongPassword: true}, {emitEvent: true});
					this.cdr.markForCheck();
					this.messageService.add({
						severity: MessageStatus.Warning,
						summary: 'Password error',
						detail: 'You can reset your password through "Forgot Password"',
						life: 12000
					});
				} else if (err.status === HttpStatusCode.Forbidden) {
					this.messageService.add({
						severity: MessageStatus.Warning,
						summary: 'Account Issue',
						detail: 'Your Account has been deactivated, please email support for more info."',
						life: 12000
					});
				} else {
					this.messageService.add({
						severity: MessageStatus.Error,
						summary: 'Major Error',
						detail: err.message,
						life: 12000
					});
				}
				return of();
			}),
			takeUntil(this.ngUnsubscribe)
		).subscribe();
	}

	googleSignIn() {
		this.authService.signIn(GoogleLoginProvider.PROVIDER_ID);
	}

}
