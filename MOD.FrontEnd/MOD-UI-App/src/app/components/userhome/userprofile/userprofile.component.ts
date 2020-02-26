import { Component, OnInit } from '@angular/core';
import { UserService } from 'src/app/services/user.service';
import { User } from 'src/app/model/User';

@Component({
  selector: 'app-userprofile',
  templateUrl: './userprofile.component.html',
  styleUrls: ['./userprofile.component.css']
})
export class UserprofileComponent implements OnInit {
  public userData: User;
  constructor(private user: UserService) {
    let username = localStorage.getItem('username');
    console.log(username);
    debugger;
    this.user.getUserById(username).subscribe((value: User) => {
      console.log(value);
      this.userData = value;
      console.log(this.userData);
    });
   }

  ngOnInit() {
  }

}
