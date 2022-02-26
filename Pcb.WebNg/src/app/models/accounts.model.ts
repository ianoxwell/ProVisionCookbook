import { SocialUser } from 'angularx-social-login';

export interface NewUser {
	firstName: string;
	lastName: string;
	email: string;
	password?: string;
	photoUrl?: string;
	loginProvider: 'Local' | 'Social';
	loginProviderId?: string;
	verified: Date;
}
export interface AccurateSocialUser extends SocialUser {
	providerId: string;
}