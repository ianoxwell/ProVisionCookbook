import { NgModule } from '@angular/core';
import { HTTP_INTERCEPTORS } from '@angular/common/http';
import { PreloadAllModules, RouterModule, Routes } from '@angular/router';

import { WelcomeComponent } from './pages/welcome/welcome.component';
import { RecipesComponent } from './pages/recipe/recipes.component';
import { FavouritesComponent } from './pages/user/favourites/favourites.component';
import { UserRecipesComponent } from './pages/user/user-recipes/user-recipes.component';
import { UserSettingsComponent } from './pages/user/user-settings/user-settings.component';
import { MainComponent } from './pages/main/main.component';
import { HomeComponent } from './pages/home/home.component';
import { CalendarComponent } from './pages/calendar/calendar.component';
import { IngredientsComponent } from './pages/ingredients/ingredients.component';
import { ShoppingComponent } from './pages/shopping/shopping.component';

import { ScriptsComponent } from './settings/scripts/scripts.component';
import { AuthGuard } from './guards/auth.guard';
import { InterceptorService } from './services/interceptor.service';

const accountModule = () => import('@components/account/account.module').then(x => x.AccountModule);


const routes: Routes = [
	{
		path: '',
		component: WelcomeComponent,
		children: [
			{
				path: 'account',
				loadChildren: accountModule
			}
		],
	},
	{
		path: 'savoury', component: MainComponent,
		children: [
			{
				path: '',
				component: HomeComponent,
				data: { title: `Provisioner's Cookbook` }
			},
			{
				path: 'calendar/:calView/:calDate/:room',
				component: CalendarComponent,
				data: { title: `Book Recipe` }
			},
			{
				path: 'calendar/:calView/:calDate',
				component: CalendarComponent,
				data: { title: `Book Recipe` }
			},
			{
				path: 'calendar/:calView',
				component: CalendarComponent,
				data: { title: `Book Recipe` }
			},
			{
				path: 'calendar',
				component: CalendarComponent,
				data: { title: `Book Recipe` }
			},
			{
				path: 'ingredients',
				component: IngredientsComponent,
				data: { title: `Ingredients` }
			},
			{
				path: 'ingredients/item/:ingredientId',
				component: IngredientsComponent,
				data: { title: `Ingredient Edit` }
			},
			{
				path: 'recipes/browse',
				component: RecipesComponent,
				data: { title: `Recipes` }
			},
			{
				path: 'recipes/item/:recipeId',
				component: RecipesComponent,
				data: { title: `Recipe` }
			},
			{
				path: 'recipes', redirectTo: 'recipes/browse', pathMatch: 'full' },
			{
				path: 'shopping',
				component: ShoppingComponent,
				data: { title: `Shopping list` }
			},
			{
				path: 'user/favourites',
				component: FavouritesComponent,
				data: { title: `Favourites list` }
			},
			{
				path: 'user/recipes',
				component: UserRecipesComponent,
				data: { title: `My Recipes` }
			},
			{
				path: 'user/settings',
				component: UserSettingsComponent,
				data: { title: `My Settings` }
			},
			{
				path: 'app/settings',
				component: ScriptsComponent,
				data: { title: `App Settings` }
			},
		],
		canActivate: [AuthGuard]
	},
  { path: '**', redirectTo: '' }
];

@NgModule({
  imports: [ RouterModule.forRoot(routes, {
	initialNavigation: 'enabled',
	paramsInheritanceStrategy: 'always'
  }) ],
  exports: [ RouterModule ],
  providers: [
	{
		provide: HTTP_INTERCEPTORS,
		useClass: InterceptorService,
		multi: true
	}
  ]
})
export class AppRoutingModule {}