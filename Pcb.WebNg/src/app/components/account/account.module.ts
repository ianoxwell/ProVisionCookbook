import { NgModule } from '@angular/core';
import { ReactiveFormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';

import { AccountRoutingModule } from './account-routing.module';
import { LoginComponent } from './login.component';
import { LoginFormComponent } from './login-form/login-form.component';
import { RegisterFormComponent } from './register-form/register-form.component';
import { ResetPasswordFormComponent } from './reset-password-form/reset-password-form.component';
import { VerifyEmailComponent } from './verify-email/verify-email.component';
import { ForgotPasswordComponent } from './forgot-password/forgot-password.component';
import { MatIconModule } from '@angular/material/icon';
import { MatCardModule } from '@angular/material/card';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatDividerModule } from '@angular/material/divider';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { environment } from 'src/environments/environment';
import icons from '../../../assets/svg/svg-icons';
import { SvgIconsModule } from '@ngneat/svg-icon';
import { StoreDevtoolsModule } from '@ngrx/store-devtools';
import { AccountService } from '@services/account.service';
import { SharedComponentModule } from '@components/shared-component.module';


@NgModule({
	imports: [
		CommonModule,
		ReactiveFormsModule,
		AccountRoutingModule,
		MatIconModule,
		MatCardModule,
		MatFormFieldModule,
		MatDividerModule,
		MatInputModule,
		MatButtonModule,
		MatCheckboxModule,
		SharedComponentModule,
		!environment.production ? StoreDevtoolsModule.instrument() : [], SvgIconsModule.forRoot({
			icons
		}),
	],
	declarations: [
		LoginFormComponent,
		RegisterFormComponent,
		ResetPasswordFormComponent,
		ForgotPasswordComponent,
		LoginComponent,
		VerifyEmailComponent,
	],
	providers: [
		AccountService
	]
})
export class AccountModule { }