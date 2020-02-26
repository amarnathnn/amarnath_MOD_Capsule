import { Component, OnInit } from '@angular/core';
import { UserService } from 'src/app/services/user.service';
import { Mentor } from 'src/app/model/mentor';

@Component({
  selector: 'app-mentorprofile',
  templateUrl: './mentorprofile.component.html',
  styleUrls: ['./mentorprofile.component.css']
})
export class MentorprofileComponent implements OnInit {
  public mentorData: Mentor;
  
  constructor(private user:UserService) { 
    let username = localStorage.getItem('username');
    console.log(username);
    debugger;
    this.user.getMentorById(username).subscribe((value: Mentor) => {
      console.log(value);
      this.mentorData = value;
      console.log(this.mentorData);
    });
  }

  ngOnInit() {
  }

}
