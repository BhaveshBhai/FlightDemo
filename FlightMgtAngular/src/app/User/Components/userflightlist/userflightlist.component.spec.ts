import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { UserflightlistComponent } from './userflightlist.component';

describe('UserflightlistComponent', () => {
  let component: UserflightlistComponent;
  let fixture: ComponentFixture<UserflightlistComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ UserflightlistComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(UserflightlistComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
