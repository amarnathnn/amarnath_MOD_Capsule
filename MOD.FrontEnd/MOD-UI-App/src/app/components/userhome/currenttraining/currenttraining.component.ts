import { Component, OnInit } from '@angular/core';
import { UserService } from 'src/app/services/user.service';
import { Training } from 'src/app/model/Training';

@Component({
  selector: 'app-currenttraining',
  templateUrl: './currenttraining.component.html',
  styleUrls: ['./currenttraining.component.css']
})
export class CurrenttrainingComponent implements OnInit {
  public inprogressTrainings: Training[] = [];
  constructor(private user:UserService) {
    
   }

  ngOnInit() {
    let userid = localStorage.getItem('userid');
    this.user.getTrainings().subscribe((value: Training[]) => {
      console.log(value);
      this.inprogressTrainings = value.filter(x => x.userId.toString() == userid && (x.status == "inprogress" || x.status=="accepted"));
      console.log(this.inprogressTrainings);
    });
  }

}
