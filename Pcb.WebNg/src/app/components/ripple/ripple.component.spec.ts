/* tslint:disable:no-unused-variable */
import { waitForAsync, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { RippleComponent } from './ripple.component';

describe('RippleComponent', () => {
  let component: RippleComponent;
  let fixture: ComponentFixture<RippleComponent>;

  beforeEach(waitForAsync(() => {
	TestBed.configureTestingModule({
		declarations: [ RippleComponent ]
	})
	.compileComponents();
  }));

  beforeEach(() => {
	fixture = TestBed.createComponent(RippleComponent);
	component = fixture.componentInstance;
	fixture.detectChanges();
  });

  it('should create', () => {
	expect(component).toBeTruthy();
  });
});
