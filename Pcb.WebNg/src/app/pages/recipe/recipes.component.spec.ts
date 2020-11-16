/**
 * @notes
 * This spec file has been generated by oughtaTest
 * Based heavily upon the scuri work of Georgi Parlakov - https://github.com/gparlakov/scuri
 * Assuming that the app contains autoSpy and correct path declaration in tsconfig e.g. "autospy": ["src/app/tests/auto-spy"]
 * Also assuming package contains angularMaterial>8 and ng-mocks as a devDependencies - https://github.com/ike18t/ng-mocks#readme
 */
import { waitForAsync, ComponentFixture, TestBed, fakeAsync, tick } from '@angular/core/testing';
import { Store } from '@ngrx/store';
import * as fromStore from '@store/reducers';
import { TestStore } from '@tests/test-store';

import { MatIconModule } from '@angular/material/icon';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatTabsModule } from '@angular/material/tabs';
import { MatButtonModule } from '@angular/material/button';
import { NoopAnimationsModule } from '@angular/platform-browser/animations';

import { autoSpy } from 'autospy';
import { MockComponent } from 'ng-mocks';
import { of, Subject } from 'rxjs';
import { RecipeRestService } from '@services/recipe-rest.service';
import { ActivatedRoute, ActivatedRouteSnapshot } from '@angular/router';
import { RestService } from '@services/rest-service.service';
import { Location } from '@angular/common';
import { UserProfileService } from '@services/user-profile.service';
import { ToTitleCasePipe } from '@pipes/title-case.pipe';
import { MessageService } from '@services/message.service';
import { RecipesComponent } from './recipes.component';
import { fakeRecipeReturn } from '@tests/fake-recipe.model';
import { RecipeViewComponent } from '@components/recipe-view/recipe-view.component';
import { SearchBarComponent } from '@components/search-bar/search-bar.component';

type Spy<T> = T & jasmine.SpyObj<T>;

fdescribe('RecipesComponent', () => {
	let component: RecipesComponent;
	let fixture: ComponentFixture<RecipesComponent>;


	const recipeRestServiceSpy: Spy<RecipeRestService> = autoSpy(RecipeRestService);
	const activatedRouteSpy: Spy<ActivatedRoute> = autoSpy(ActivatedRoute);
	activatedRouteSpy.snapshot = {routeConfig: {url: '', path: ''}} as unknown as ActivatedRouteSnapshot;
	activatedRouteSpy.params = of({});
	const fakeActivatedRoute = {
		snapshot: {
				paramMap: {
					get(): string {
						return '123';
					},
				},
				routeConfig: {url: '', path: ''}
		}
	 } as unknown as ActivatedRoute;

	const restServiceSpy: Spy<RestService> = autoSpy(RestService);
	const locationSpy: Spy<Location> = autoSpy(Location);
	// const store<fromStore.State>Spy: Spy<Store<fromStore.State>> = autoSpy(Store<fromStore.State>);
	const userProfileServiceSpy: Spy<UserProfileService> = autoSpy(UserProfileService);
	userProfileServiceSpy.currentData = of({});
	const toTitleCasePipeSpy: Spy<ToTitleCasePipe> = autoSpy(ToTitleCasePipe);
	const messageServiceSpy: Spy<MessageService> = autoSpy(MessageService);


	beforeEach(waitForAsync(() => {
		TestBed.configureTestingModule({
			imports: [
				MatIconModule,
				MatToolbarModule,
				MatTabsModule,
				MatButtonModule,
				NoopAnimationsModule,
			],
			declarations: [
				RecipesComponent,
				MockComponent(RecipeViewComponent),
				MockComponent(SearchBarComponent)
			],
			providers: [
				{ provide: RecipeRestService, useValue: recipeRestServiceSpy },
				{ provide: ActivatedRoute, useValue: fakeActivatedRoute },
				{ provide: RestService, useValue: restServiceSpy },
				{ provide: Location, useValue: locationSpy },
				{ provide: Store, useValue: TestStore },
				{ provide: UserProfileService, useValue: userProfileServiceSpy },
				{ provide: ToTitleCasePipe, useValue: toTitleCasePipeSpy },
				{ provide: MessageService, useValue: messageServiceSpy },
			]
		}).compileComponents();
	}));

	beforeEach(() => {

		fixture = TestBed.createComponent(RecipesComponent);
		component = fixture.componentInstance;
		fixture.detectChanges();
	});

	it('should create', () => {
		expect(component).toBeTruthy();
	});

	describe('when ngOnInit is called it should', () => {
		// remove what is not required
		beforeEach(() => {

		});

		it('should ...', () => {
			// arrange
			// act
			// component.ngOnInit();
			// assert
			// expect(c).toEqual
		});
	});
	describe('when showToast is called it should', () => {
		// remove what is not required
		beforeEach(() => {

		});

		it('should ...', () => {
			// arrange
			// act
			// component.showToast();
			// assert
			// expect(c).toEqual
		});
	});
	describe('when routeParamSubscribe is called it should', () => {
		// remove what is not required
		beforeEach(() => {

		});

		it('should ...', () => {
			// arrange
			// act
			// component.routeParamSubscribe();
			// assert
			// expect(c).toEqual
		});
	});
	describe('when loadRecipeSelect is called it should', () => {
		// remove what is not required
		beforeEach(() => {

		});

		it('should ...', () => {
			// arrange
			// act
			// component.loadRecipeSelect();
			// assert
			// expect(c).toEqual
		});
	});
	describe('when changeRecipe is called it should', () => {
		// remove what is not required
		beforeEach(() => {

		});

		it('should ...', () => {
			// arrange
			// act
			// component.changeRecipe();
			// assert
			// expect(c).toEqual
		});
	});
	describe('when onFilterChange is called it should', () => {
		// remove what is not required
		beforeEach(() => {

		});

		it('should ...', () => {
			// arrange
			// act
			// component.onFilterChange();
			// assert
			// expect(c).toEqual
		});
	});
	describe('Get Recipes', () => {
		let subject: Subject<any>;
		beforeEach(() => {
			subject = new Subject<any>();
			recipeRestServiceSpy.getRecipe.and.returnValue(subject.asObservable());
		});
		it('will probably complain about something here', () => {
			const steve = true;
			expect(steve).toBeTrue();
		});
		it('should return something good today', () => {
			component.getRecipes().subscribe();
			subject.next(fakeRecipeReturn);
			expect(component.recipes).toEqual(fakeRecipeReturn.items);
		});


	});
	describe('when createOrEdit is called it should', () => {
		// remove what is not required
		beforeEach(() => {

		});

		it('should ...', () => {
			// arrange
			// act
			// component.createOrEdit();
			// assert
			// expect(c).toEqual
		});
	});
	describe('when selectThisRecipe is called it should', () => {
		// remove what is not required
		beforeEach(() => {

		});

		it('should ...', () => {
			// arrange
			// act
			// component.selectThisRecipe();
			// assert
			// expect(c).toEqual
		});
	});
	describe('when changeTab is called it should', () => {
		// remove what is not required
		beforeEach(() => {

		});

		it('should ...', () => {
			// arrange
			// act
			// component.changeTab();
			// assert
			// expect(c).toEqual
		});
	});
	describe('when getSpoonAcularRecipe is called it should', () => {
		// remove what is not required
		beforeEach(() => {

		});

		it('should ...', () => {
			// arrange
			// act
			// component.getSpoonAcularRecipe();
			// assert
			// expect(c).toEqual
		});
	});


});