import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { UserserviceService } from "../../Services/userservice.service";
import { AdminServiceService } from "../../../Admin/Services/admin-service.service"
import { Flight } from 'src/app/Models/Flight';
import { Booking } from 'src/app/Models/Booking';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-userbooking',
  templateUrl: './userbooking.component.html',
  styleUrls: ['./userbooking.component.scss']
})
export class UserbookingComponent implements OnInit {
  ID: string;
  Status: string;
  flightData: Flight;
  bookingInput : Booking = new Booking();
  constructor(private route: ActivatedRoute, private api: UserserviceService, private adminApi: AdminServiceService, private router: Router) { }

  ngOnInit() {
    debugger;
    this.route.queryParams.subscribe(params => {
      // Defaults to 0 if no query param provided.
      this.ID = params['ID'] || '';
      this.Status = params['Status'] || '';
    });
    this.getFlightDetail();
  }

  goToUserHome() {
    this.router.navigateByUrl('/home');
  }
  goToFlightList() {
    this.router.navigateByUrl('/userflightlist');
  }
  goToSearchBooking() {
    this.router.navigateByUrl('/usersearchbooking');
  }
  goToCheckAvailability() {
    this.router.navigateByUrl('/usercheckavailability');
  }
  goToLogin() {
    this.router.navigateByUrl('/login');
  }

  getFlightDetail() {
    this.adminApi.GetFlightDetailById(this.ID).subscribe(m => {
      this.flightData = m;
    });
  }

  addPassengers(form: NgForm) {
    if (form.valid) {
      debugger;
      this.bookingInput.FlightID = this.flightData.ID;
      this.bookingInput.BArrivalCity = this.flightData.ArrivalCity;
      this.bookingInput.BDepartCity = this.flightData.DepartCity;
      this.bookingInput.UserID = parseInt(localStorage.getItem('currentUser'));
      this.bookingInput.BookID = "";
      this.bookingInput.Status = this.Status;
      this.api.addPassengers(this.bookingInput).subscribe(response => {
          debugger;
          if (response) {
            alert("Flight booked successfully");
            console.log("Flight booked successfully");
            this.goToFlightList();
          } else {
            console.log("Flight booking failed");
            alert("Flight booking failed");
          }
        },
        error => {
          console.log('Error : Flight Booking Error');
        });
    } else {
      alert("Form is not valid");
    }
  }

}
