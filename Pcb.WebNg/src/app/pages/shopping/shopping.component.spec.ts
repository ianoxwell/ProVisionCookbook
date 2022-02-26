import { ComponentFixture, TestBed, waitForAsync } from '@angular/core/testing';
import { MatToolbarModule } from '@angular/material/toolbar';
import { NoopAnimationsModule } from '@angular/platform-browser/animations';
import { ShoppingComponent } from './shopping.component';





describe('ShoppingComponent', () => {
	let component: ShoppingComponent;
	let fixture: ComponentFixture<ShoppingComponent>;


	beforeEach(waitForAsync(() => {
		TestBed.configureTestingModule({
			imports: [
				MatToolbarModule,
				NoopAnimationsModule,

			],
			declarations: [
				ShoppingComponent,
			],
			providers: []
		}).compileComponents();
	}));

	beforeEach(() => {

		fixture = TestBed.createComponent(ShoppingComponent);
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
	describe('when patchForm is called it should', () => {
		// remove what is not required
		beforeEach(() => {

		});

		it('should ...', () => {
			// arrange
			// act
			// component.patchForm();
			// assert
			// expect(c).toEqual
		});
	});
	describe('when onSubmit is called it should', () => {
		// remove what is not required
		beforeEach(() => {

		});

		it('should ...', () => {
			// arrange
			// act
			// component.onSubmit();
			// assert
			// expect(c).toEqual
		});
	});
	describe('when groupOrControl is called it should', () => {
		// remove what is not required
		beforeEach(() => {

		});

		it('should ...', () => {
			// arrange
			// act
			// component.groupOrControl();
			// assert
			// expect(c).toEqual
		});
	});


});
