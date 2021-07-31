import { HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ComponentBase } from '@components/base/base.component.base';
import { MessageResult } from '@models/common.model';
import { MessageStatus } from '@models/message.model';
import { ValidationMessages } from '@models/static-variables';
import { AccountService } from '@services/account.service';
import { MessageService } from '@services/message.service';
import { of } from 'rxjs';
import { catchError, first, tap } from 'rxjs/operators';

enum TokenStatus {
	Validating,
	Valid,
	Invalid
}
@Component({
  selector: 'app-reset-password-form',
  templateUrl: './reset-password-form.component.html',
  styleUrls: ['./reset-password-form.component.scss']
})
export class ResetPasswordFormComponent extends ComponentBase implements OnInit {
	form: FormGroup;
	validationMessages = ValidationMessages;

	TokenStatus = TokenStatus;
	tokenStatus = TokenStatus.Validating;
	token = null;
	isSubmitting = false;
	isLoading = false;

	constructor(
		private fb: FormBuilder,
		private route: ActivatedRoute,
		private router: Router,
		private accountService: AccountService,
		private messageService: MessageService
	) { super(); }

	ngOnInit() {
		this.form = this.createForm();
		// tslint:disable-next-line: no-string-literal
		const token = this.route.snapshot.queryParams['token'];

		// remove token from url to prevent http referer leakage
		this.router.navigate([], { relativeTo: this.route, replaceUrl: true });

		if (token === undefined) {
			this.tokenStatus = TokenStatus.Invalid;
		} else {
			this.accountService.validateResetToken(token).pipe(
				first(),
				tap((result: MessageResult) => {
					if (result.message === 'Invalid Token') {
						this.messageService.add({
							severity: MessageStatus.Error,
							summary: 'Invalid Token',
							detail: 'Please obtain a new password reset token.',
							life: 8000
						});
						this.tokenStatus = TokenStatus.Invalid;
					} else {
						this.token = token;
						this.tokenStatus = TokenStatus.Valid;
					}

					console.log('returned result', result, this.tokenStatus);
				}),
				catchError((err: HttpErrorResponse) => {
					this.tokenStatus = TokenStatus.Invalid;
					this.messageService.add({
						severity: MessageStatus.Error,
						summary: 'Reset Token Error',
						detail: 'The server did not receive a correctly formatted token.',
						life: 8000
					});
					return of();
				})
			).subscribe();
		}
	}

  	get f() { return this.form.controls; }
	createForm(): FormGroup {
		// Create the controls for the reactive forms
		return this.fb.group({
			password: ['', [Validators.required, Validators.minLength(6), Validators.maxLength(120)]]
		});
	}

	resetPassword(): void {
		if (this.form.invalid) {
			return;
		}
		this.isSubmitting = true;
		this.accountService.resetPassword(this.token, this.f.password.value, this.f.password.value).pipe(
			first(),
			tap((result: MessageResult) => {
				console.log('Message result from reset password attempt', result);
				if (result.message === 'Success') {
					this.messageService.add({
						severity: MessageStatus.Success,
						summary: 'Password reset',
						detail: 'Password reset you can now login with your new password.',
						life: 8000
					});
					this.router.navigate(['/account/login']);
				} else {
					this.messageService.add({
						severity: MessageStatus.Warning,
						summary: 'Password reset failed',
						detail: result.message,
						life: 8000
					});
					this.tokenStatus = TokenStatus.Invalid;
				}
			}),
			catchError((err: HttpErrorResponse) => {
				this.tokenStatus = TokenStatus.Invalid;
				this.messageService.add({
					severity: MessageStatus.Error,
					summary: 'Password reset Error',
					detail: err.message,
					life: 8000
				});
				return of();
			})
		).subscribe(() => {
			this.isSubmitting = false;
		});
	}

}
