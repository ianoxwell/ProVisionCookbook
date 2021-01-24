import { LayoutModule } from '@angular/cdk/layout';
import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MAT_DATE_LOCALE } from '@angular/material/core';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { AutoCompleteSearchComponent } from '@components/auto-complete-search/auto-complete-search.component';
import { ComponentModule } from '@components/component.module';
import { SharedComponentModule } from '@components/shared-component.module';
import { SiteLogoComponent } from '@components/site-logo/site-logo.component';
import { FullCalendarModule } from '@fullcalendar/angular';
import { SvgIconsModule } from '@ngneat/svg-icon';
import { PipesModule } from '@pipes/pipes.module';
import { AccountService } from '@services/account.service';
import { LogService } from '@services/log.service';
import { LoginService } from '@services/login.service';
import { MessageService } from '@services/message.service';
import { RefDataService } from '@services/ref-data.service';
import { ReferenceService } from '@services/reference.service';
import { SecurityService } from '@services/security.service';
import { StateService } from '@services/state.service';
import { StorageService } from '@services/storage';
import { UserService } from '@services/user.service';
import { GoogleLoginProvider, SocialAuthServiceConfig, SocialLoginModule } from 'angularx-social-login';
import { ChartsModule } from 'ng2-charts';
import { NgxMaterialTimepickerModule } from 'ngx-material-timepicker';
import icons from '../assets/svg/svg-icons';
import { CompleteMaterialModule } from './app-material.module';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ConfirmDialogComponent } from './dialogs/dialog-confirm/confirm.component';
import { DialogDeleteIngredientComponent } from './dialogs/dialog-delete-ingredient/dialog-delete-ingredient.component';
import { DialogErrorComponent } from './dialogs/dialog-error/dialog-error.component';
import { DialogNewIngredientComponent } from './dialogs/dialog-new-ingredient/dialog-new-ingredient.component';
import { DialogRecipeComponent } from './dialogs/dialog-recipe/dialog-recipe.component';
import { CalendarComponent } from './pages/calendar/calendar.component';
import { HomeDashboardComponent } from './pages/home/home-dashboard/home-dashboard.component';
import { HomeComponent } from './pages/home/home.component';
import { IngredientsComponent } from './pages/ingredients/ingredients.component';
import { MainComponent } from './pages/main/main.component';
import { RecipesComponent } from './pages/recipe/recipes.component';
import { ShoppingComponent } from './pages/shopping/shopping.component';
import { FavouritesComponent } from './pages/user/favourites/favourites.component';
import { UserRecipesComponent } from './pages/user/user-recipes/user-recipes.component';
import { UserSettingsComponent } from './pages/user/user-settings/user-settings.component';
import { WelcomeComponent } from './pages/welcome/welcome.component';
import { DialogService } from './services/dialog.service';
import { RestService } from './services/rest-service.service';
import { UserProfileService } from './services/user-profile.service';







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
	// https://netbasal.com/elegantly-manage-svg-icons-in-angular-applications-5adde68a5c46
	SvgIconsModule.forRoot({
		icons
	  })
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
		StateService,
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

