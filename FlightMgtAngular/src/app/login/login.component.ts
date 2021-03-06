import { Component, OnInit } from '@angular/core';
import { LoginService } from '../login/login.service';
import { User } from "./user";
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {
  public username: string;
  public password: string;
  constructor(private route: ActivatedRoute, private loginApi: LoginService, private router: Router) { }

  ngOnInit() {

  }

  isUserExist() {
    console.log("test");
    //this.loginApi.getSelectedUser(username, password);
    this.loginApi.getSelectedUser(this.username, this.password)
      .subscribe(
        response => {
          debugger;
          console.log(response);
          if (response != null && response != undefined) {
            localStorage.setItem('currentUser', response.id.toString());
            if (response.roleName == "Admin") {
              this.router.navigateByUrl('/adminhome');
              console.log("Admin Login Success");
            } else if (response.roleName == "User") {
              console.log("User Login Success");
              this.router.navigateByUrl('/home');
            } else {
              alert("User is not exist in system");
            }
          }
          else
            console.log("Login Failed");
        },
        error => {
          console.log('Error : Login Error');
        });
  }

}
