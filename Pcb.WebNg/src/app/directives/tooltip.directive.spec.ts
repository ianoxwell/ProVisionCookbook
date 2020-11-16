/* tslint:disable:no-unused-variable */

import { TestBed, waitForAsync, ComponentFixture } from '@angular/core/testing';
import { TooltipDirective } from './tooltip.directive';
import { Component } from '@angular/core';
import { NoopAnimationsModule } from '@angular/platform-browser/animations';
import { TooltipComponent } from '@angular/material/tooltip';

@Component({
	template: `
        <div style="margin:50px;">
            <input type="text" appTooltip="Enter your username" [positionStyle]="positionStyle" [appendTo]="appendTo" [tooltipDisabled]="disabled" [tooltipEvent]="event" [tooltipPosition]="position">
        </div>
        `
})
class TestTooltipComponent {
	position ='right';

	event = 'hover';

	positionStyle = 'absolute';

	disabled = false;

	appendTo: any = 'body';
}


describe('Directive: Tooltip', () => {
	let tooltip: TooltipComponent;
	let component: TestTooltipComponent;
	let fixture: ComponentFixture<TestTooltipComponent>;

	beforeEach(() => {
		TestBed.configureTestingModule({
			imports: [
				NoopAnimationsModule
			],
			declarations: [
				TooltipComponent,
				TestTooltipComponent
			]
		});

		fixture = TestBed.createComponent(TestTooltipComponent);
		tooltip = fixture.debugElement.children[0].componentInstance;
		component = fixture.componentInstance;
	});
});
