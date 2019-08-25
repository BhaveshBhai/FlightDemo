import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { UsersearchbookingComponent } from './usersearchbooking.component';

describe('UsersearchbookingComponent', () => {
  let component: UsersearchbookingComponent;
  let fixture: ComponentFixture<UsersearchbookingComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ UsersearchbookingComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(UsersearchbookingComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
