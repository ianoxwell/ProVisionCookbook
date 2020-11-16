import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor,
  HttpErrorResponse,
  HttpResponse
} from '@angular/common/http';
import { Observable, of, throwError } from 'rxjs';
import { mergeMap, catchError, map } from 'rxjs/operators';

import { HttpStatusCode } from '../models/security.models';
import { environment } from 'src/environments/environment';
import { LoginService } from './login.service';

@Injectable({
  providedIn: 'root'
})
export class InterceptorService implements HttpInterceptor {
	private apiURL = environment.apiUrl + environment.apiVersion;
	tokenKey = 'token';

	constructor(
		private loginService: LoginService,
		) { }

	intercept(
		req: HttpRequest<any>,
		next: HttpHandler
	): Observable<HttpEvent<any>> {

	// if the token exists and the connections file has been read and the url being accessed is the api - add the Token
	if ((req.url.startsWith(this.apiURL) && req.url.indexOf('account') === -1) || req.url.indexOf('/api/v1/account/get-account') > -1) {
		if (this.loginService.getJwt()) {
		req = req.clone({ headers: req.headers.set('Authorization', `Bearer ${this.loginService.getJwt()}`) });
	}

		return next.handle(req).pipe(
			map((event: HttpEvent<any>) => {
				// Check for a Response
				// Continue the cycle
				return event;
			}),
			catchError(error => {
				// Check for an actual error
				if (error instanceof HttpErrorResponse) {

					// Refresh token expiry first attempt
					if (error.status === HttpStatusCode.AuthorizationRequired  || error.status === HttpStatusCode.Forbidden) {
						console.log('attempting to re-authenticate', error);
						// Attempt to refresh the session
					}
				}
				console.log('Caught Http Error!');
				console.log(error);
				return throwError(error);
			})
		);
	} else {
		return next.handle(req);
	}
  }
}
