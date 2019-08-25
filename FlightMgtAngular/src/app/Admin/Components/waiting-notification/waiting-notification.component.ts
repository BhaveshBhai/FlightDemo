import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Booking } from 'src/app/Models/Booking';
import { AdminServiceService } from "../../Services/admin-service.service";

@Component({
  selector: 'app-waiting-notification',
  templateUrl: './waiting-notification.component.html',
  styleUrls: ['./waiting-notification.component.scss']
})
export class WaitingNotificationComponent implements OnInit {
  waitList: Array<Booking>;
  constructor(private route: ActivatedRoute, private api: AdminServiceService, private router: Router) { }

  ngOnInit() {
    debugger;
    this.getWaitingList();
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
  getWaitingList() {
    debugger;
    this.api.getAllWaitBook().subscribe(m => {
      this.waitList = m;
    })
  }
}
