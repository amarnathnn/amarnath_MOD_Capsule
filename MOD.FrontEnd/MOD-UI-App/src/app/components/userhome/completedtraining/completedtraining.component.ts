import { Component, OnInit } from '@angular/core';
import { UserService } from 'src/app/services/user.service';
import { Training } from 'src/app/model/Training';

@Component({
  selector: 'app-completedtraining',
  templateUrl: './completedtraining.component.html',
  styleUrls: ['./completedtraining.component.css']
})
export class CompletedtrainingComponent implements OnInit {
  public completedTrainings: Training[] = [];
  constructor(private user:UserService) { 
    this.user.getTrainings().subscribe((value: Training[]) => {
      console.log(value);
      let userrole = localStorage.getItem('role');
      let userid = localStorage.getItem('userid');
      if(userrole == 'mentor')
      {
      this.completedTrainings = value.filter(x => x.mentorId.toString() == userid && x.status == "completed");
      }
      else 
      {
        this.completedTrainings = value.filter(x =>x.userId.toString() == userid && x.status == "completed");
      }

      console.log(this.completedTrainings);
    });
  }

  ngOnInit() {
  }

}
