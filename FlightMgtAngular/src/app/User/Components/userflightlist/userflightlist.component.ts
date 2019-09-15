import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { UserserviceService } from "../../Services/userservice.service";
import { Flight } from 'src/app/Models/Flight';

@Component({
  selector: 'app-userflightlist',
  templateUrl: './userflightlist.component.html',
  styleUrls: ['./userflightlist.component.scss']
})
export class UserflightlistComponent implements OnInit {
  flightList: Array<Flight>;

  constructor(private route: ActivatedRoute, private api: UserserviceService, private router: Router) { }

  ngOnInit() {
    debugger;
    this.getFlightList();
    debugger;
    console.log(this.flightList);
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

  getFlightList() {
    debugger;
    this.api.getAllFlights().subscribe(m => {
      this.flightList = m;
      debugger;
      console.log(this.flightList);
    });
  }

  getBooking(flight: Flight) {
    this.router.navigate(['/userbooking'], { queryParams: { ID: flight.id , Status : flight.Status} });
  }
}
