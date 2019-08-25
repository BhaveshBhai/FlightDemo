import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { NgForm } from '@angular/forms';
import { Flight } from "../../../Models/Flight";
import { AdminServiceService } from "../../Services/admin-service.service";

@Component({
  selector: 'app-flight-add',
  templateUrl: './flight-add.component.html',
  styleUrls: ['./flight-add.component.scss']
})
export class FlightAddComponent implements OnInit {
  flightModel: Flight = new Flight();

  constructor(private route: ActivatedRoute, private api: AdminServiceService, private router: Router) { }

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

  addNewFlight(form: NgForm) {
    debugger;
    if (form.valid) {
      this.api.addFlight(this.flightModel).subscribe(
        response => {
          debugger;
          if (response) {
            alert("Flight saved successfully");
            console.log("Flight saved successfully");
            this.goToFlightList();
          } else {
            console.log("Flight saving is failed");
            alert("Flight saving is failed");
          }
        },
        error => {
          console.log('Error : Add Flight Error');
        });
    } else {
      alert("Form is not valid");
    }
  }
}
