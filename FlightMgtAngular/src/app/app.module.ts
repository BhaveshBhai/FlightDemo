import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

import { FlightAddComponent } from './Admin/Components/flight-add/flight-add.component';
import { LoginComponent } from './login/login.component';
import { appRoutes } from './app.routes';
import { RouterModule } from '@angular/router';

import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { HomeComponent } from './home/home.component';
import { AdminhomeComponent } from './adminhome/adminhome.component';
import { FlightListComponent } from './Admin/Components/flight-list/flight-list.component';
import { WaitingNotificationComponent } from './Admin/Components/waiting-notification/waiting-notification.component';
import { UserflightlistComponent } from './User/Components/userflightlist/userflightlist.component';
import { UserbookingComponent } from './User/Components/userbooking/userbooking.component';
import { UsersearchbookingComponent } from './User/Components/usersearchbooking/usersearchbooking.component';
import { UsercheckavailabilityComponent } from './User/Components/usercheckavailability/usercheckavailability.component';
import { FlightEditComponent } from './Admin/Components/flight-edit/flight-edit.component';

@NgModule({
  declarations: [
    AppComponent,
    FlightAddComponent,
    LoginComponent,
    HomeComponent,
    AdminhomeComponent,
    FlightListComponent,
    WaitingNotificationComponent,
    UserflightlistComponent,
    UserbookingComponent,
    UsersearchbookingComponent,
    UsercheckavailabilityComponent,
    FlightEditComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    RouterModule.forRoot(appRoutes),
    FormsModule,
    HttpClientModule,
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
