import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { UsercheckavailabilityComponent } from './usercheckavailability.component';

describe('UsercheckavailabilityComponent', () => {
  let component: UsercheckavailabilityComponent;
  let fixture: ComponentFixture<UsercheckavailabilityComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ UsercheckavailabilityComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(UsercheckavailabilityComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
