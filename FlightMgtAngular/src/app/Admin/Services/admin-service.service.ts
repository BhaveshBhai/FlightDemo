import { Injectable } from '@angular/core';
import { Observable, of, throwError } from 'rxjs';
import { HttpClient, HttpHeaders, HttpErrorResponse } from '@angular/common/http';
import { catchError, tap, map } from 'rxjs/operators';
import { Configuration } from "../../../environments/environment.configuration";
import { Flight } from "../../Models/Flight";
import { Booking } from 'src/app/Models/Booking';

@Injectable({
  providedIn: 'root'
})
export class AdminServiceService {

  //Setting up api url from environment configuration
  apiUrl: string = Configuration.apiUrl + "flight/";

  constructor(private http: HttpClient) { }

  //Error handling
  private handleError<T>(operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {
      // TODO: send the error to remote logging infrastructure
      console.error(error); // log to console instead
      // Let the app keep running by returning an empty result.
      return of(result as T);
    };
  }

  //Get all flights
  getAllFlights(): Observable<Flight[]> {
    debugger;
    return this.http.post<Flight[]>(this.apiUrl + 'FlightSelectAll', null)
      .pipe(
        tap(heroes => console.log('Get Flights')),
        catchError(this.handleError('getFlights', []))
      );
  }

  GetFlightDetailById(id: string): Observable<any> {
    var url = `${this.apiUrl}FlightSelectOne/${id}`;
    return this.http.post<Flight>(url, null)
      .pipe(
        tap(heroes => console.log('Get Flights')),
        catchError(this.handleError('getFlights', []))
      );
  }

  addFlight(obj: Flight) {
    debugger;
    var url = `${this.apiUrl}FlightInsert?ArrivalCity=${obj.ArrivalCity}&DepartCity=${obj.DepartCity}&EndDate=${obj.EndDate}&FlightNo=${obj.FlightNo}&PassCapacity=${obj.PassCapacity}&StartDate=${obj.StartDate}`;
    return this.http.post(url, null);
  }

  deleteFlight(id: number) {
    debugger;
    var url = `${this.apiUrl}FlightDelete/${id}`;
    return this.http.post(url, null);
  }

  editFlight(obj: Flight) {
    debugger;
    var url = `${this.apiUrl}FlightUpdate?ID=${obj.ID}&ArrivalCity=${obj.ArrivalCity}&DepartCity=${obj.DepartCity}&EndDate=${obj.EndDate}&FlightNo=${obj.FlightNo}&PassCapacity=${obj.PassCapacity}&StartDate=${obj.StartDate}`;
    return this.http.post(url, null);
  }

  getAllWaitBook(): Observable<Booking[]> {
    debugger;
    return this.http.post<Booking[]>(this.apiUrl + 'BookingWaitingAll', null)
      .pipe(
        tap(heroes => console.log('Get Wait List')),
        catchError(this.handleError('getWaitList', []))
      );
  }
}
