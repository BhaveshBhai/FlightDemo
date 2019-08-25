import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-adminhome',
  templateUrl: './adminhome.component.html',
  styleUrls: ['./adminhome.component.scss']
})
export class AdminhomeComponent implements OnInit {

  constructor(private route: ActivatedRoute, private router: Router) { }

  ngOnInit() {
  }

  goToFlightList() {
    this.router.navigateByUrl('/adminflightlist');
  }
  goToAddFlight() {
    this.router.navigateByUrl('/adminflightadd');
  }
  goToWaitingNotification() {
    this.router.navigateByUrl('/adminwaitingnotification');
  }
  goToAdminHome() {
    this.router.navigateByUrl('/adminhome');
  }
  goToLogin() {
    this.router.navigateByUrl('/login');
  }

}
