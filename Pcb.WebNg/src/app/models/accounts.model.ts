import { SocialUser } from 'angularx-social-login';

export class NewUser {
	firstName: string;
	lastName: string;
	email: string;
	password?: string;
	photoUrl?: string;
	loginProvider = 'Local';
	loginProviderId?: string;
	verified: Date;
}
export interface AccurateSocialUser extends SocialUser {
	providerId: string;
}