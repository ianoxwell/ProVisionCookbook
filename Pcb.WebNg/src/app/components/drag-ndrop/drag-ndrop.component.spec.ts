import { DragDropModule } from '@angular/cdk/drag-drop';
import { waitForAsync, ComponentFixture, TestBed } from '@angular/core/testing';
import { NoopAnimationsModule } from '@angular/platform-browser/animations';
import { DragNDropComponent } from './drag-ndrop.component';

describe('DragNDropComponent', () => {
	let component: DragNDropComponent;
	let fixture: ComponentFixture<DragNDropComponent>;

	beforeEach(waitForAsync(() => {
		TestBed.configureTestingModule({
		declarations: [ DragNDropComponent ],
		imports: [
			NoopAnimationsModule,
			DragDropModule,
		]
		}).compileComponents();
	}));

	beforeEach(() => {
		fixture = TestBed.createComponent(DragNDropComponent);
		component = fixture.componentInstance;
		fixture.detectChanges();
	});

	it('should compile', () => {
		expect(component).toBeTruthy();
	});
});
