/**
 * @notes
 * This spec file has been generated by oughtaTest
 * Based heavily upon the scuri work of Georgi Parlakov - https://github.com/gparlakov/scuri
 * Assuming that the app contains autoSpy and correct path declaration in tsconfig e.g. "autospy": ["src/app/tests/auto-spy"]
 * Also assuming package contains angularMaterial>8 and ng-mocks as a devDependencies - https://github.com/ike18t/ng-mocks#readme
 */
import { waitForAsync, ComponentFixture, TestBed, fakeAsync, tick } from '@angular/core/testing';


import { MatIconModule } from '@angular/material/icon';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatButtonModule } from '@angular/material/button';
import { MatDividerModule } from '@angular/material/divider';
import { MatMenuModule } from '@angular/material/menu';
import { NoopAnimationsModule } from '@angular/platform-browser/animations';

import { autoSpy } from 'autospy';
import { MockComponent } from 'ng-mocks';
import { of, Subject } from 'rxjs';
import { UserProfileService } from '../../services/user-profile.service';
import { AppHeaderComponent } from './app-header.component';

type Spy<T> = T & jasmine.SpyObj<T>;

describe('AppHeaderComponent', () => {
	let component: AppHeaderComponent;
	let fixture: ComponentFixture<AppHeaderComponent>;


	const userProfileServiceSpy: Spy<UserProfileService> = autoSpy(UserProfileService);
	// exampleServiceSpy.exampleMethod.and.returnValue(of(fakeItem)) - for all items that are called in ngOnInit

	beforeEach(waitForAsync(() => {
		TestBed.configureTestingModule({
			imports: [
				MatIconModule,
				MatToolbarModule,
				MatButtonModule,
				MatDividerModule,
				MatMenuModule,
				NoopAnimationsModule,

			],
			declarations: [
				AppHeaderComponent,
				// MockComponent(ComponentsUsedInTheHTML)
			],
			providers: [
				{ provide: UserProfileService, userValue: userProfileServiceSpy },
			]
		}).compileComponents();
	}));

	beforeEach(() => {

		fixture = TestBed.createComponent(AppHeaderComponent);
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


});