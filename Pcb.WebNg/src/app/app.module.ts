import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { CommonModule, TitleCasePipe } from '@angular/common';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { NgxMaterialTimepickerModule } from 'ngx-material-timepicker';
import { ChartsModule } from 'ng2-charts';
import { SocialLoginModule, SocialAuthServiceConfig, GoogleLoginProvider } from 'angularx-social-login';

import { CompleteMaterialModule } from './app-material.module';
import {MAT_DATE_LOCALE} from '@angular/material/core';
import { FullCalendarModule } from '@fullcalendar/angular';
import { LayoutModule } from '@angular/cdk/layout';

import { AppComponent } from './app.component';
import {AppRoutingModule} from './app-routing.module';


import { StoreModule, ActionReducerMap, ActionReducer, MetaReducer } from '@ngrx/store';
import { reducers } from './store/reducers';
import { StoreDevtoolsModule } from '@ngrx/store-devtools';
import { environment } from '../environments/environment';
import { AppEffects } from './store/effects/app.effects';
import { localStorageSync } from 'ngrx-store-localstorage';

import { FavouritesComponent } from './pages/user/favourites/favourites.component';
import { CalendarComponent } from './pages/calendar/calendar.component';
import { ShoppingComponent } from './pages/shopping/shopping.component';
import { IngredientsComponent } from './pages/ingredients/ingredients.component';
import { UserSettingsComponent } from './pages/user/user-settings/user-settings.component';
import { UserRecipesComponent } from './pages/user/user-recipes/user-recipes.component';
import { HomeComponent } from './pages/home/home.component';
import { HomeDashboardComponent } from './pages/home/home-dashboard/home-dashboard.component';
import { MainComponent } from './pages/main/main.component';
import { WelcomeComponent } from './pages/welcome/welcome.component';
import { RecipesComponent } from './pages/recipe/recipes.component';


import { DialogErrorComponent } from './dialogs/dialog-error/dialog-error.component';
import { ConfirmDialogComponent } from './dialogs/dialog-confirm/confirm.component';
import { DialogDeleteIngredientComponent } from './dialogs/dialog-delete-ingredient/dialog-delete-ingredient.component';
import { DialogRecipeComponent } from './dialogs/dialog-recipe/dialog-recipe.component';

import { RestService } from './services/rest-service.service';
import { UserProfileService } from './services/user-profile.service';
import { DialogService } from './services/dialog.service';
import { ComponentModule } from '@components/component.module';
import { PipesModule } from '@pipes/pipes.module';
import { MessageService } from '@services/message.service';
import { LoginService } from '@services/login.service';
import { StorageService } from '@services/storage';
import { SiteLogoComponent } from '@components/site-logo/site-logo.component';
import icons from '../assets/svg/svg-icons';
import { SvgIconsModule } from '@ngneat/svg-icon';
import { ReferenceService } from '@services/reference.service';
import { RefDataService } from '@services/ref-data.service';
import { LogService } from '@services/log.service';
import { SecurityService } from '@services/security.service';
import { UserService } from '@services/user.service';
import { AccountService } from '@services/account.service';
import { DialogNewIngredientComponent } from './dialogs/dialog-new-ingredient/dialog-new-ingredient.component';
import { SharedComponentModule } from '@components/shared-component.module';
import { AutoCompleteSearchComponent } from '@components/auto-complete-search/auto-complete-search.component';


export function localStorageSyncReducer(reducer: ActionReducer<any>): ActionReducer<any> {
  return localStorageSync({keys: ['filterPayload'],
  rehydrate: true})(reducer);
}
const metaReducers: Array<MetaReducer<any, any>> = [localStorageSyncReducer];

@NgModule({
  declarations: [
	AppComponent,

	FavouritesComponent,
	RecipesComponent,
	CalendarComponent,
	ShoppingComponent,
	IngredientsComponent,
	UserSettingsComponent,
	UserRecipesComponent,
	HomeComponent,
	HomeDashboardComponent,
	DialogErrorComponent,
	DialogDeleteIngredientComponent,
	DialogRecipeComponent,
	MainComponent,
	WelcomeComponent,
	ConfirmDialogComponent,
	DialogNewIngredientComponent,
	AutoCompleteSearchComponent,
	SiteLogoComponent,
  ],
  imports: [
	BrowserModule,
	BrowserAnimationsModule,
	CommonModule,
	FormsModule,
	AppRoutingModule,
	CompleteMaterialModule,
	HttpClientModule,
	ReactiveFormsModule,
	LayoutModule,
	ComponentModule,
	PipesModule,
	SharedComponentModule,
	FullCalendarModule,
	ChartsModule,
	NgxMaterialTimepickerModule,
	NgxMaterialTimepickerModule.setLocale('en-au'),
	SocialLoginModule,
	// EffectsModule.forRoot([AppEffects, FilterPayloadEffects]),
	StoreModule.forFeature('filterQuery', reducers),
	StoreModule.forRoot(reducers, {
		metaReducers,
		runtimeChecks: {
		strictStateImmutability: true,
		strictActionImmutability: true,
		}
	}),
	// https://netbasal.com/elegantly-manage-svg-icons-in-angular-applications-5adde68a5c46
	!environment.production ? StoreDevtoolsModule.instrument() : [], SvgIconsModule.forRoot({
		icons
	}),
	],
	providers: [
		{provide: MAT_DATE_LOCALE, useValue: 'en-AU'},
		AccountService,
		RestService,
		UserProfileService,
		ReferenceService,
		RefDataService,
		DialogService,
		LogService,
		LoginService,
		StorageService,
		SecurityService,
		MessageService,
		UserService,
		{ provide: 'SocialAuthServiceConfig', useValue: {
			autoLogin: false,
			providers: [
				{
					id: GoogleLoginProvider.PROVIDER_ID,
					provider: new GoogleLoginProvider(
					'74967204697-o4tb5b59r1ou0vig4eoks4lst8c4i7vc.apps.googleusercontent.com'
					),
				}
			]
		} as SocialAuthServiceConfig,
	}
	],
  bootstrap: [AppComponent]
})
export class AppModule { }

