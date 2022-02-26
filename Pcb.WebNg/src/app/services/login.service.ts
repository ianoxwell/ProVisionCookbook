import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { JwtHelperService } from '@auth0/angular-jwt';
import { MessageResult } from '@models/common.model';
import { ITokenState } from '@models/logout.models';
import { IClaims, IResponseToken, IToken } from '@models/security.models';
import { User } from '@models/user';
import { SocialAuthService, SocialUser } from 'angularx-social-login';
import { BehaviorSubject, Observable, of } from 'rxjs';
import { catchError, distinctUntilChanged, filter, first, map, tap } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { StorageService } from './storage.service';
import { UserProfileService } from './user-profile.service';

@Injectable({
	providedIn: 'root'
})
export class LoginService {

	private authentication$ = new BehaviorSubject<ITokenState | null>(null);

	// JWT token string obtained at login.
	private jwt: IToken = this.initNewJwt();

	// Decoded token containing the authenticated user's claims.
	private claims: IClaims | null = null;

	// Key used for storing the token in local storage.
	// Must match token name used in auth.module.ts
	// tslint:disable-next-line: variable-name
	private token_key = 'token';
	// tslint:disable-next-line: variable-name
	private refresh_key = 'refreshToken';
	// tslint:disable-next-line: variable-name
	private expiry_key = 'PCb.Logout.ExpiryMillisec';

	// State to do with the login timeout.
	private isTokenRefreshInProgress = false;

	// JWT helper service for decoding tokens into something we can use .i.e claims.
	private jwtHelper: JwtHelperService = new JwtHelperService();

	constructor(
		private http: HttpClient,
		private storageService: StorageService,
		private userProfileService: UserProfileService,
		private authService: SocialAuthService
	) {
		this.getSetJwtInitial();
	}

	getAuthentication(): Observable<ITokenState | null> {
		return this.authentication$.asObservable();
	}

	getClaims(): IClaims | null {
		return this.claims;
	}

	isAuthenticated(): boolean {
		const jwtToken = this.getJwt();
		return !!jwtToken && jwtToken.length > 8 && this.checkJwtExpiry(jwtToken) && !!this.jwt.token && !!this.claims;
	}

	/** Checks the JWT Token from local storage and compares the expiry to current time */
	public checkJwtExpiry(jwt: any): boolean {
		if (!jwt) {
			return false;
		}
		jwt = this.decode(jwt);
		const currentTime = new Date().getTime();
		const expiresAt = jwt.exp * 1000;
		return expiresAt > currentTime;
	}

	// Clears login state.
	hardLogout(includeSocial = false): void {
		this.jwt = this.initNewJwt();
		this.claims = null;
		this.storageService.removeItem(this.token_key);
		if (includeSocial) {
			this.authService.authState
				.pipe(
					first(),
					filter((signedIn: SocialUser) => !!signedIn),
					tap(() => this.authService.signOut())
				)
				.subscribe();
			this.storageService.removeItem('google-user');
		}
		this.userProfileService.setLoggedIn(false);
		this.userProfileService.setData(null);
	}

	/**
	 * Login Method - Gets both an access token and a refresh token
	 * @param email the provided username
	 * @param password the provided password
	 */
	public login(email: string, password: string, social = false): Observable<MessageResult> {
		// Clear and current session
		this.hardLogout();

		// Construct the http request
		const body = social ? { email } : { email, password };
		const loginUrl = social
			? `${environment.apiUrl}/token/google?email=${email}`
			: `${environment.apiUrl}${environment.apiVersion}token/create`;

		return this.http.post<IResponseToken | MessageResult>(loginUrl, body).pipe(
			map((response: any) => {
				if (!!response.message) {
					return response;
				} else {
					const jwt = this.processJwtResponse(response);
					this.userProfileService.setLoggedIn(true);
					const success = this.setJwt(jwt);
					return new MessageResult(success ? 'Successful login' : 'Login failure');
				}
			})
		);
	}

	getSingleUserProfile(): Observable<User | null> {
		const jwtToken = this.getJwt();
		if (jwtToken === null) {
			return of(null);
		}
		
		const userId = this.decode(this.getJwt())?.sub;
		return this.http.get<User>(`${environment.apiUrl}${environment.apiVersion}account/get-account?id=${userId}`).pipe(
			tap((user: User) => {
				console.log('logged in user', user);
				this.userProfileService.setData(user);
			})
		);
	}

	/* Refreshes the JWT if we're more than halfway through the token lifetime */
	sessionKeepAlive(): void {
		// If the refreshesAt is in the future, don't refresh.
		const tokenState = this.authentication$.value;

		if (!tokenState || tokenState.refreshesAt > Date.now()) {
			return;
		}

		this.refreshSession();
	}

	/**
	 * Quick try parse string to JSON.
	 * @param str to check.
	 * @returns try if able to parse the string.
	 */
	private isJsonString(str: string): boolean {
		try {
			JSON.parse(str);
		} catch (e) {
			return false;
		}
		return true;
	}

	/**
	 * Uses the Google User JWK as authorisation to attempt to sign username onto app.
	 * @param googleUser can be SocialUser or string to parse (from the localStorage)
	 * @returns boolean if successful or string message of 'register' if fail.
	 */
	getTokenUsingGoogleToken(googleUser: SocialUser | string): Observable<boolean | string> {
		// check for string or Social User. Parse and cast to SocialUser.
		let gUser: SocialUser;
		if (typeof googleUser === 'string') {
			if (!this.isJsonString(googleUser)) {
				return of(false);
			} else {
				gUser = JSON.parse(googleUser) as SocialUser;
			}
		} else {
			gUser = googleUser;
		}
		let googleSignInUrl = `${environment.apiUrl}/token/google`;
		let newHeaders = new HttpHeaders();
		newHeaders = newHeaders.append('Content-Type', 'application/json');
		if (googleUser !== null) {
			newHeaders = newHeaders.append('Authorization', 'Bearer ' + gUser.idToken);
			googleSignInUrl += `?email=${gUser.email}`;
		}
		return this.http.get<IResponseToken>(googleSignInUrl, { headers: newHeaders }).pipe(
			map((response: any) => {
				// if the response is a message to register the user
				if (!!response && !!response.message) {
					return 'register';
				}
				const jwt = this.processJwtResponse(response);
				this.userProfileService.setLoggedIn(true);
				return this.setJwt(jwt);
			})
		);
	}

	/**
	 * Access point for Reissuing the Jwt token
	 */
	private refreshSession(): void {
		if (this.isTokenRefreshInProgress) {
			// Currently refreshing the token, don't want to do a double hit.
			return;
		}

		this.isTokenRefreshInProgress = true;

		// Retrieve the most current Jwt
		this.jwt.refreshToken = this.getJwtRefresh();

		// No Refresh Token?
		if (!this.jwt.refreshToken) {
			return;
		}

		// Posts the reissuing request
		this.postRefresh(this.jwt.refreshToken).subscribe(
			() => (this.isTokenRefreshInProgress = false),
			() => (this.isTokenRefreshInProgress = false)
		);
	}

	/**
	 * Common method for getting access and refresh tokens
	 */
	private postRefresh(rToken: string): Observable<boolean> {
		// Construct the http request
		const username = this.getClaims()?.name;
		const body = { refreshToken: rToken, username };
		const loginUrl = `${environment.apiUrl}${environment.apiVersion}token/refresh`;

		return this.http.post<IResponseToken>(loginUrl, body).pipe(
			map((response) => {
				const jwt = this.processJwtResponse(response);
				this.userProfileService.setLoggedIn(true);
				return this.setJwt(jwt);
			}),
			catchError((err) => {
				console.log(err);
				return of<boolean>(false);
			})
		);
	}

	/**
	 * The common method for processing the new JWT (login and refresh)
	 */
	private processJwtResponse(response: IResponseToken): IToken {
		let newJwt = this.initNewJwt();

		// Successful if there is a JWT Response
		if (!!response) {
			const expiresIn = response.expiresIn || 0;
			const lifetime = expiresIn * 1000; // Convert to millisecons.
			const expiresAt = Date.now() + lifetime;
			newJwt = {
				token: !!response.token ? response.token : '',
				refreshToken: !!response.refreshToken ? response.refreshToken : '',
				lifetime,
				expiresAt
			};
		}

		return newJwt;
	}

	/** Decodes the JWT Token */
	public decode(token: string): IClaims | null {
		if (token === null || token.length < 8) {
			return null;
		}

		// Decode encrypted token
		const d = this.jwtHelper.decodeToken(token);

		// Parse permissions and roles JSON
		d.roles = JSON.parse(d.roles);
		return d;
	}

	/** 'Installs' a new JWT */
	private setJwt(newJwt: IToken): boolean {
		// Default
		if (!newJwt.token || !newJwt.refreshToken || !newJwt.expiresAt) {
			this.claims = null;

			this.jwt = this.initNewJwt();

			this.storeJwt(this.jwt);

			// Trigger Activity Change.
			this.authentication$.next(null);

			return false;
		}

		// Set token properties
		this.jwt = newJwt;

		this.storeJwt(this.jwt);

		const expiresAt = newJwt.expiresAt;
		const lifetime = newJwt.lifetime;

		const refreshesAt = expiresAt - Math.floor(lifetime / 2);
		const warnsAt = expiresAt - Math.floor(lifetime / 4);

		this.authentication$.next({ expiresAt, refreshesAt, warnsAt });

		this.claims = this.decode(this.jwt.token);

		// Google Analytics - Requires UserId
		// (window as any).ga('set', 'userId', this.claims.sub);

		return true;
	}

	/**
	 * Initialises a new Jwt Object
	 */
	private initNewJwt(): IToken {
		return {
			token: '',
			refreshToken: '',
			expiresAt: 0,
			lifetime: 0
		};
	}

	private getSetJwtInitial(): void {
		this.restoreJwt();

		// Observe the session for expiry changes from other tabs.
		this.storageService.observeStorageEventItem(this.expiry_key).pipe(
			distinctUntilChanged(),
			tap(() => this.restoreJwt())
		).subscribe();
	}

	/** Restores the JWT from session storage. */
	private restoreJwt(): void {
		this.setJwt({
			token: this.getJwt(),
			refreshToken: this.getJwtRefresh(),
			expiresAt: this.getJwtExpiry(),
			lifetime: this.getJwtExpiry() - Date.now()
		});
	}

	// #region Storage Setters/Getters
	/** Saves the JWT token details in storage */
	private storeJwt(jwt: IToken): void {
		this.storageService.setItem(this.token_key, jwt.token);
		this.storageService.setItem(this.refresh_key, jwt.refreshToken);
		this.storageService.setItem(this.expiry_key, jwt.expiresAt.toString());
	}

	/** Gets the JWT Token from storage */
	public getJwt(): string {
		return this.storageService.getItem<string>(this.token_key) as string;
	}

	/** Gets the JWT refresh token from storage */
	private getJwtRefresh(): string {
		return this.storageService.getItem(this.refresh_key) as string;
	}

	/** Gets the JWT expiry time from storage */
	private getJwtExpiry(): number {
		return parseInt(this.storageService.getItem(this.expiry_key) as string, 10);
	}
}
