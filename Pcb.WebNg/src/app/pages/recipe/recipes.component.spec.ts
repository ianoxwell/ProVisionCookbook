/**
 * @notes
 * This spec file has been generated by oughtaTest
 * Based heavily upon the scuri work of Georgi Parlakov - https://github.com/gparlakov/scuri
 * Assuming that the app contains autoSpy and correct path declaration in tsconfig e.g. "autospy": ["src/app/tests/auto-spy"]
 * Also assuming package contains angularMaterial>8 and ng-mocks as a devDependencies - https://github.com/ike18t/ng-mocks#readme
 */
import { Location } from '@angular/common';
import { ComponentFixture, TestBed, waitForAsync } from '@angular/core/testing';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { MatTabsModule } from '@angular/material/tabs';
import { MatToolbarModule } from '@angular/material/toolbar';
import { NoopAnimationsModule } from '@angular/platform-browser/animations';
import { ActivatedRoute, ActivatedRouteSnapshot } from '@angular/router';
import { RecipeViewComponent } from '@components/recipe/recipe-view/recipe-view.component';
import { SearchBarComponent } from '@components/recipe/search-bar/search-bar.component';
import { User } from '@models/user';
import { ToTitleCasePipe } from '@pipes/title-case.pipe';
import { MessageService } from '@services/message.service';
import { RestIngredientService } from '@services/rest-ingredient.service';
import { RestRecipeService } from '@services/rest-recipe.service';
import { UserProfileService } from '@services/user-profile.service';
import { fakeRecipeReturn } from '@tests/fake-recipe.model';
import { autoSpy } from 'autospy';
import { MockComponent } from 'ng-mocks';
import { of, Subject } from 'rxjs';
import { RecipesComponent } from './recipes.component';



type Spy<T> = T & jasmine.SpyObj<T>;

fdescribe('RecipesComponent', () => {
	let component: RecipesComponent;
	let fixture: ComponentFixture<RecipesComponent>;


	const restRecipeServiceSpy: Spy<RestRecipeService> = autoSpy(RestRecipeService);
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

	const restIngredientServiceSpy: Spy<RestIngredientService> = autoSpy(RestIngredientService);
	const locationSpy: Spy<Location> = autoSpy(Location);
	// const store<fromStore.State>Spy: Spy<Store<fromStore.State>> = autoSpy(Store<fromStore.State>);
	const userProfileServiceSpy: Spy<UserProfileService> = autoSpy(UserProfileService);
	userProfileServiceSpy.currentData = of({} as User);
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
				{ provide: RestRecipeService, useValue: restRecipeServiceSpy },
				{ provide: ActivatedRoute, useValue: fakeActivatedRoute },
				{ provide: RestIngredientService, useValue: restIngredientServiceSpy },
				{ provide: Location, useValue: locationSpy },
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
			restRecipeServiceSpy.getRecipe.and.returnValue(subject.asObservable());
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
