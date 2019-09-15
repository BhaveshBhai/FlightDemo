import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { AdminServiceService } from "../../Services/admin-service.service";
import { Flight } from 'src/app/Models/Flight';

@Component({
  selector: 'app-flight-list',
  templateUrl: './flight-list.component.html',
  styleUrls: ['./flight-list.component.scss']
})
export class FlightListComponent implements OnInit {
  flightList: Array<Flight>;

  constructor(private route: ActivatedRoute, private api: AdminServiceService, private router: Router) { }

  ngOnInit() {
    debugger;
    this.getFlightList();
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

  getFlightList() {
    debugger;
    this.api.getAllFlights().subscribe(m => {
      this.flightList = m;
      console.log(this.flightList);
      debugger;
    })
  }

  getFlightDetail(flight: Flight) {
    debugger;
    this.router.navigate(['/adminflightedit'], { queryParams: { ID: flight.id} });
  }

  deleteFlight(flight: Flight) {
    debugger;
    this.api.deleteFlight(flight.id).subscribe(
      response => {
        debugger;
        if (response) {
          alert("Flight deleted successfully");
          console.log("Flight deleted successfully");
          window.location.reload();
          //this.goToFlightList();
        } else {
          console.log("Flight deletion is failed");
          alert("Flight deletion is failed");
        }
      },
      error => {
        console.log('Error : Delete Flight Error');
      });
  }

}
