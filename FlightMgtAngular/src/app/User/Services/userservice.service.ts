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
export class UserserviceService {

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

  addPassengers(obj: Booking) {
    debugger;
    var url = `${this.apiUrl}BookingInsert?BookID=${obj.BookID}&FlightID=${obj.FlightID}&UserID=${obj.UserID}&PassengerName=${obj.PassengerName}&BDate=${obj.BDate}&BArrivalCity=${obj.BArrivalCity}&BDepartCity=${obj.BDepartCity}&Status=${obj.Status}`;
    return this.http.post(url, null);
  }

  getAllBokking(userId: string): Observable<Booking[]> {
    debugger;
    return this.http.post<Booking[]>(this.apiUrl + `BookingAll?userId=${userId}`, null)
      .pipe(
        tap(heroes => console.log('Get Booking')),
        catchError(this.handleError('getBooking', []))
      );
  }

  getSearchBooking(PassengerName: string, BDate: string, BArrivalCity: string, BDepartCity: string, FlightNo: string, UserId: string): Observable<Booking[]> {
    return this.http.post<Booking[]>(this.apiUrl + `BookingFilter?PassName=${PassengerName}&BDate=${BDate}&BArrivalCity=${BArrivalCity}&BDepartCity=${BDepartCity}&FlightNo=${FlightNo}&UserID=${UserId}`, null)
      .pipe(
        tap(heroes => console.log('Get Booking')),
        catchError(this.handleError('getBooking', []))
      );
  }

  getAvailability(StartDate: string, EndDate: string, NoOfPassenger: number) {
    return this.http.post<Flight[]>(this.apiUrl + `FlightAvailability?StartDate=${StartDate}&EndDate=${EndDate}&NoOfPassenger=${NoOfPassenger}`, null)
      .pipe(
        tap(heroes => console.log('Get Booking')),
        catchError(this.handleError('getBooking', []))
      );
  }
}
