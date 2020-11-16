import { Injectable } from '@angular/core';
import { Router, CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, UrlTree } from '@angular/router';
import { LoginService } from '@services/login.service';
import { Observable } from 'rxjs';
import { tap } from 'rxjs/operators';


@Injectable({
  	providedIn: 'root'
})
export class AuthGuard implements CanActivate {
	// local reference to where the token is stored
	tokenKey = 'token';
	constructor(
		private loginService: LoginService
	) { }

	canActivate(
		next: ActivatedRouteSnapshot,
		state: RouterStateSnapshot): Observable<boolean | UrlTree> | Promise<boolean | UrlTree> | boolean | UrlTree {
			// if there is a local JWT and if it has not expired
			return this.loginService.checkJwtExpiry(this.loginService.getJwt());
	}


}
