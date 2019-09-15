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
    debugger;

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
      debugger;
      console.log(this.flightData);
    });
  }

  updateFlight(form: NgForm) {
    debugger;
    if (form.valid) {
      if (this.flightInput.id == undefined)
        this.flightInput.id = this.flightData.id;
      if (this.flightInput.flightNo == undefined)
        this.flightInput.flightNo = this.flightData.flightNo;
      if (this.flightInput.startDate == undefined)
        this.flightInput.startDate = this.flightData.startDate;
      if (this.flightInput.endDate == undefined)
        this.flightInput.endDate = this.flightData.endDate;
      if (this.flightInput.passCapacity == undefined)
        this.flightInput.passCapacity = this.flightData.passCapacity;
      if (this.flightInput.departCity == undefined)
        this.flightInput.departCity = this.flightData.departCity;
      if (this.flightInput.arrivalCity == undefined)
        this.flightInput.arrivalCity = this.flightData.arrivalCity;
      
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
