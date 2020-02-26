import { Component, OnInit } from '@angular/core';
import { Training } from 'src/app/model/Training';
import { ResponseMessage } from 'src/app/model/ResponseMessage';
import { UserService } from 'src/app/services/user.service';
import { MentorService } from 'src/app/services/mentor.service';

@Component({
  selector: 'app-mentornotificaton',
  templateUrl: './mentornotificaton.component.html',
  styleUrls: ['./mentornotificaton.component.css']
})
export class MentornotificatonComponent implements OnInit {

  public pendingTrainings: Training[] = [];
  public confirmedTrainings: Training[] = [];
  public rejectedTrainings: Training[] = [];
  public filteredTrainings: Training[] = [];
  public responseMessage: ResponseMessage = { errorMessage: "" };

  constructor(private user: UserService, private mentor: MentorService) {
    this.loadTraining();
  }

  loadTraining() {
    debugger;
    let userid  = localStorage.getItem('userid') ;
    this.user.getTrainings().subscribe((value: Training[]) => {
      console.log(value);
      debugger;
      this.filteredTrainings = value.filter(x => x.mentorId.toString() == userid )
      this.pendingTrainings = this.filteredTrainings.filter(x => x.status == "pending" );
      this.confirmedTrainings = this.filteredTrainings.filter(x => x.status == "confirmed");
      this.rejectedTrainings = this.filteredTrainings.filter(x => x.status == "rejected");
      console.log(this.pendingTrainings);
    });
  }

  acceptTraining(trainingId) {
    this.mentor.acceptTraining(trainingId).subscribe((value: ResponseMessage) => {
      this.responseMessage = value;
      this.loadTraining();

    });
  }

  rejectTraining(trainingId) {
    this.mentor.rejectTraining(trainingId).subscribe((value: ResponseMessage) => {
      this.responseMessage = value;
      this.loadTraining();

    });
  }

  ngOnInit() {
    this.loadTraining();
  }

}
