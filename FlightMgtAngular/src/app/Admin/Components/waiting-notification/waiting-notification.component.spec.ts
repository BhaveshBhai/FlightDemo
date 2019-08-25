import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { WaitingNotificationComponent } from './waiting-notification.component';

describe('WaitingNotificationComponent', () => {
  let component: WaitingNotificationComponent;
  let fixture: ComponentFixture<WaitingNotificationComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ WaitingNotificationComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(WaitingNotificationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
