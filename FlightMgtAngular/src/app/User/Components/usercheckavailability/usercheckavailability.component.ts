import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { UserserviceService } from '../../Services/userservice.service';
import { Flight } from 'src/app/Models/Flight';

@Component({
  selector: 'app-usercheckavailability',
  templateUrl: './usercheckavailability.component.html',
  styleUrls: ['./usercheckavailability.component.scss']
})
export class UsercheckavailabilityComponent implements OnInit {
  flightList: Array<Flight>;
  search: Flight = new Flight();
  constructor(private route: ActivatedRoute, private api: UserserviceService, private router: Router) { }

  ngOnInit() {
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

  getCheckAvailability() {
    debugger;
    this.search.startDate = this.search.startDate == undefined ? "" : this.search.startDate;
    this.search.endDate = this.search.endDate == undefined ? "" : this.search.endDate;
    this.search.NoOfPassenger = this.search.NoOfPassenger == undefined ? 0 : this.search.NoOfPassenger;
    this.api.getAvailability(this.search.startDate, this.search.endDate, this.search.NoOfPassenger).subscribe(m => {
      this.flightList = m;
    });
  }

}
