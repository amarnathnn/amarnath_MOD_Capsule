import { Component, OnInit } from '@angular/core';
import { AuthService } from '../../services/auth.service';
import { LoginInfo } from '../../model/LoginInfo';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  public errorMessage: string = "";
  constructor(private auth: AuthService, private router: Router) {
    localStorage.clear();
  }

  ngOnInit() {
  }

  onSubmit(data) {
    console.log(data);
    this.errorMessage = "";
    this.auth.login(data).subscribe((value: LoginInfo) => {
      console.log(value);
      if (value) {
        this.errorMessage = value.errorMessage;
        // console.log(value.errorMessage);
        if (!value.errorMessage) {
          localStorage.setItem('token', value.token)
          localStorage.setItem('role', value.role);
          localStorage.setItem('username', value.username);
          localStorage.setItem('userid', value.userId)
          localStorage.setItem('userDisplayName', value.userDisplayName)
          console.log(value.role);
          if (value.role === "user") {
            this.router.navigateByUrl("/userhome");
          }
          else if (value.role === "mentor") {
            this.router.navigateByUrl("/mentorhome");
          }
        }
      }
      else {
        this.errorMessage = "Error loggin in";
      }
    });
  }

}
