import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { UserserviceService } from '../../Services/userservice.service';
import { Booking } from 'src/app/Models/Booking';

@Component({
  selector: 'app-usersearchbooking',
  templateUrl: './usersearchbooking.component.html',
  styleUrls: ['./usersearchbooking.component.scss']
})
export class UsersearchbookingComponent implements OnInit {
  bookingList: Array<Booking>;
  search: Booking = new Booking();
  constructor(private route: ActivatedRoute, private api: UserserviceService, private router: Router) { }

  ngOnInit() {
    //this.getBookingList();
    this.getSearchBooking();
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

  getSearchBooking() {
    debugger;
    var userid = localStorage.getItem('currentUser');
    this.search.PassengerName = this.search.PassengerName == undefined ? "" : this.search.PassengerName;
    this.search.BDate = this.search.BDate == undefined ? "" : this.search.BDate;
    this.search.BArrivalCity = this.search.BArrivalCity == undefined ? "" : this.search.BArrivalCity;
    this.search.BDepartCity = this.search.BDepartCity == undefined ? "" : this.search.BDepartCity;
    this.search.FlightNo = this.search.FlightNo == undefined ? "" : this.search.FlightNo;
    this.api.getSearchBooking(this.search.PassengerName, this.search.BDate, this.search.BArrivalCity, this.search.BDepartCity, this.search.FlightNo, userid).subscribe(m => {
      this.bookingList = m;
    });
  }

}
