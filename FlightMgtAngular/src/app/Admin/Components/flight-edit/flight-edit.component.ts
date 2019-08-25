import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { AdminServiceService } from "../../Services/admin-service.service";
import { Flight } from 'src/app/Models/Flight';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-flight-edit',
  templateUrl: './flight-edit.component.html',
  styleUrls: ['./flight-edit.component.scss']
})
export class FlightEditComponent implements OnInit {
  ID: string;
  flightData: Flight;
  flightInput: Flight = new Flight();
  constructor(private route: ActivatedRoute, private api: AdminServiceService, private router: Router) { }

  ngOnInit() {
    debugger;
    this.route.queryParams.subscribe(params => {
      // Defaults to 0 if no query param provided.
      this.ID = params['ID'] || '';
    });
    this.getFlightDetail();
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
  getFlightDetail() {
    this.api.GetFlightDetailById(this.ID).subscribe(m => {
      this.flightData = m;
    });
  }

  updateFlight(form: NgForm) {
    debugger;
    if (form.valid) {
      if (this.flightInput.ID == undefined)
        this.flightInput.ID = this.flightData.ID;
      if (this.flightInput.FlightNo == undefined)
        this.flightInput.FlightNo = this.flightData.FlightNo;
      if (this.flightInput.StartDate == undefined)
        this.flightInput.StartDate = this.flightData.StartDate;
      if (this.flightInput.EndDate == undefined)
        this.flightInput.EndDate = this.flightData.EndDate;
      if (this.flightInput.PassCapacity == undefined)
        this.flightInput.PassCapacity = this.flightData.PassCapacity;
      if (this.flightInput.DepartCity == undefined)
        this.flightInput.DepartCity = this.flightData.DepartCity;
      if (this.flightInput.ArrivalCity == undefined)
        this.flightInput.ArrivalCity = this.flightData.ArrivalCity;

      this.api.editFlight(this.flightInput).subscribe(
        response => {
          debugger;
          if (response) {
            alert("Flight updated successfully");
            console.log("Flight updated successfully");
            this.goToFlightList();
          } else {
            console.log("Flight updation is failed");
            alert("Flight updation is failed");
          }
        },
        error => {
          console.log('Error : Update Flight Error');
        });
    } else {
      alert("Form is not valid");
    }
  }

}
