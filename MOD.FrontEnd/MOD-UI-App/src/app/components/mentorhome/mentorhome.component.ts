import { Component, OnInit } from '@angular/core';
import { UserService } from 'src/app/services/user.service';
import { Training } from 'src/app/model/Training';
import { MentorService } from 'src/app/services/mentor.service';
import { ResponseMessage } from 'src/app/model/ResponseMessage';

@Component({
  selector: 'app-mentorhome',
  templateUrl: './mentorhome.component.html',
  styleUrls: ['./mentorhome.component.css']
})
export class MentorhomeComponent implements OnInit {
  ngOnInit() {
  }

  getUserName(){
    return localStorage.getItem('username');
  }
}
