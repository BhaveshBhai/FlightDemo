import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {

  constructor(private route: ActivatedRoute, private router: Router) { }

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

}
