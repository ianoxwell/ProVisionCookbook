import { ComponentFixture, TestBed, waitForAsync } from '@angular/core/testing';
import { PaginatorComponent } from './paginator.component';


describe('PaginatorComponent', () => {
	let component: PaginatorComponent;
	let fixture: ComponentFixture<PaginatorComponent>;

	beforeEach(waitForAsync(() => {
		TestBed.configureTestingModule({
			declarations: [ PaginatorComponent ]
		}).compileComponents();
	}));

	beforeEach(() => {
		fixture = TestBed.createComponent(PaginatorComponent);
		component = fixture.componentInstance;
		fixture.detectChanges();
	});

	it('should create', () => {
		expect(component).toBeTruthy();
	});
});
