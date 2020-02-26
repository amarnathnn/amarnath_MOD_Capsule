import { Component, OnInit } from '@angular/core';
import { AuthService } from 'src/app/services/auth.service';
import { UserService } from 'src/app/services/user.service';
import { ResponseMessage } from "src/app/model/ResponseMessage";

@Component({
  selector: 'app-registeruser',
  templateUrl: './registeruser.component.html',
  styleUrls: ['./registeruser.component.css']
})
export class RegisteruserComponent implements OnInit {
  public registerResponse: ResponseMessage = { errorMessage: "", successMessage: "" };

  constructor(private user: UserService) { }

  ngOnInit() {
  }

  onSubmit(data) {
    let status = this.validate(data);
   // alert(status);
    if (!status) {
      return;
    }
    data.active = true;
    data.ForceResetPassword = true;
    this.user.register(data).subscribe((value: ResponseMessage) => {
      console.log(value);
      this.registerResponse = value;
      console.log("component: " + this.registerResponse);
      console.log(this.registerResponse.errorMessage);
    }
    );
  }

  validate(data) {
    this.registerResponse = {
      errorMessage: ""
    };
    if (!data.username || !data.firstname || !data.lastname
      || !data.password || !data.confirmpassword || !data.contactnumber || !data.email) {
      this.registerResponse = {
        errorMessage: "Please input data in all fields."
      }
      return false;
    }
    if (data.password !== data.confirmpassword) {
      this.registerResponse = {
        errorMessage: "Passwords has to match."
      }
      return false;
    }
    return true;
  }

}
