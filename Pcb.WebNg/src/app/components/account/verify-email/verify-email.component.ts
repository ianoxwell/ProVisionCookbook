	import { HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { MessageResult } from '@models/common.model';
import { MessageStatus } from '@models/message.models';
import { AccountService } from '@services/account.service';
import { MessageService } from '@services/message.service';
import { of } from 'rxjs';
import { catchError, first, tap } from 'rxjs/operators';

	enum EmailStatus {
		Verifying,
		Failed
	}
@Component({
	selector: 'app-verify-email',
	templateUrl: './verify-email.component.html',
	styleUrls: ['./verify-email.component.scss']
})
export class VerifyEmailComponent implements OnInit {
	EmailStatus = EmailStatus;
	emailStatus = EmailStatus.Verifying;
	constructor(
		private route: ActivatedRoute,
		private router: Router,
		private accountService: AccountService,
		private messageService: MessageService
	) { }

	ngOnInit() {
		// tslint:disable-next-line: no-string-literal
		const token = this.route.snapshot.queryParams['token'];

		// remove token from url to prevent http referer leakage
		this.router.navigate([], { relativeTo: this.route, replaceUrl: true });
		if (token === undefined) {
			this.emailStatus = EmailStatus.Failed;
			this.messageService.add({
				severity: MessageStatus.Error,
				summary: 'Invalid Token',
				detail: 'Please obtain a new verify token.',
				life: 8000
			});
		} else {
			this.accountService.verifyEmail(token).pipe(
				first(),
				tap((result: MessageResult) => {
					if (result.message === 'Verification Failed') {
						this.messageService.add({
							severity: MessageStatus.Error,
							summary: 'Invalid Token',
							detail: 'Please obtain a new password reset token.',
							life: 8000
						});
						this.emailStatus = EmailStatus.Failed
					} else {
						this.messageService.add({
							severity: MessageStatus.Success,
							summary: 'Email Verified',
							detail: 'Well done, email verified, please login to start making amazing recipes.',
							life: 8000
						});
						this.router.navigate(['/account/login']);
					}
				}),
				catchError((err: HttpErrorResponse) => {
					this.messageService.add({
						severity: MessageStatus.Error,
						summary: 'Invalid Token',
						detail: 'Please obtain a new password reset token.',
						life: 8000
					});
					this.emailStatus = EmailStatus.Failed
					return of();
				})
			).subscribe();
		}
	}

}
