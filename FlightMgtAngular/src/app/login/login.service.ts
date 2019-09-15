import { Injectable } from '@angular/core';
import { Observable, of, throwError } from 'rxjs';
import { HttpClient, HttpHeaders, HttpErrorResponse } from '@angular/common/http';
import { catchError, tap, map } from 'rxjs/operators';
import { User } from "./user";
import { Configuration } from '../../environments/environment.configuration';

//const httpOptions = {
//  headers: new HttpHeaders({ 'Content-Type': 'application/json' })
//};
//const apiUrl = 'http://localhost:44373/api/';

@Injectable({
  providedIn: 'root'
})
export class LoginService {
  //Setting up api url from environment configuration
  apiUrl: string = Configuration.apiUrl;

  constructor(private http: HttpClient) { }

  private handleError<T>(operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {
      // TODO: send the error to remote logging infrastructure
      console.error(error); // log to console instead
      // Let the app keep running by returning an empty result.
      return of(result as T);
    };
  }

  //Get all users
  getUsers(): Observable<User[]> {
    return this.http.get<User[]>(this.apiUrl)
      .pipe(
        tap(heroes => console.log('Get Users')),
        catchError(this.handleError('getUsers', []))
      );
  }

  //Get specific user
  //getSelectedUser(username: string, password: string): Observable<User> {
  //  const url = `${this.apiUrl}/Login?username=${username}&password=${password}`;
  //  return this.http.get<User>(url).pipe(
  //    tap(_ => console.log(`Get Selected User`)),
  //    catchError(this.handleError<User>(`getSelectedUser username=${username}`))
  //  );
  //}
  getSelectedUser(username: string, password: string): Observable<User> {
    debugger;
    console.log(username);
    console.log(password);
    var url = `${this.apiUrl}Users/Login?UserName=${username}&Password=${password}`;
    return this.http.post<User>(url, null);
  }

}
