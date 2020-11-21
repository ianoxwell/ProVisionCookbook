import { waitForAsync, ComponentFixture, TestBed } from '@angular/core/testing';

import { GraphDoughnutComponent } from './graph-doughnut.component';

describe('GraphDoughnutComponent', () => {
	let component: GraphDoughnutComponent;
	let fixture: ComponentFixture<GraphDoughnutComponent>;

	beforeEach(waitForAsync(() => {
		TestBed.configureTestingModule({
			declarations: [ GraphDoughnutComponent ]
		}).compileComponents();
	}));

	beforeEach(() => {
		fixture = TestBed.createComponent(EditCommonMineralsComponent);
		component = fixture.componentInstance;
		fixture.detectChanges();
	});

	it('should create', () => {
		expect(component).toBeTruthy();
	});
});
