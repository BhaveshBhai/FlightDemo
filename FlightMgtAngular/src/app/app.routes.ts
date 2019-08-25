import { Routes } from '@angular/router';

import { LoginComponent } from './login/login.component';

import { FlightEditComponent } from './Admin/Components/flight-edit/flight-edit.component';
import { FlightAddComponent } from './Admin/Components/flight-add/flight-add.component';
import { AdminhomeComponent } from './adminhome/adminhome.component';
import { FlightListComponent } from './Admin/Components/flight-list/flight-list.component';
import { WaitingNotificationComponent } from './Admin/Components/waiting-notification/waiting-notification.component';

import { HomeComponent } from './home/home.component';
import { UserflightlistComponent } from "./User/Components/userflightlist/userflightlist.component";
import { UserbookingComponent } from "./User/Components/userbooking/userbooking.component";
import { UsersearchbookingComponent } from "./User/Components/usersearchbooking/usersearchbooking.component";
import { UsercheckavailabilityComponent } from "./User/Components/usercheckavailability/usercheckavailability.component";

export const appRoutes: Routes = [
  {
    path: '',
    component: LoginComponent,
    data: { title: 'Login' }
  },
  {
    path: 'login',
    component: LoginComponent,
    data: { title: 'Login' }
  },
  {
    path: 'adminhome',
    component: AdminhomeComponent,
    data: { title: 'Admin Home' }
  },
  {
    path: 'adminflightlist',
    component: FlightListComponent,
    data: { title: 'Flight Listing' }
  },
  {
    path: 'adminwaitingnotification',
    component: WaitingNotificationComponent,
    data: { title: 'User Waiting Notification' }
  },
  {
    path: 'adminflightadd',
    component: FlightAddComponent,
    data: { title: 'Add Flight' }
  },
  {
    path: 'adminflightedit',
    component: FlightEditComponent,
    data: { title: 'Edit Flight' }
  },
  {
    path: 'home',
    component: HomeComponent,
    data: { title: 'Home' }
  },
  {
    path: 'userflightlist',
    component: UserflightlistComponent,
    data: { title: 'Flight List' }
  },
  {
    path: 'userbooking',
    component: UserbookingComponent,
    data: { title: 'User Booking' }
  },
  {
    path: 'usersearchbooking',
    component: UsersearchbookingComponent,
    data: { title: 'Search Booking' }
  },
  {
    path: 'usercheckavailability',
    component: UsercheckavailabilityComponent,
    data: { title: 'Check Availability' }
  }
];
