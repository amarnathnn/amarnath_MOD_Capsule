import { Component, OnInit } from '@angular/core';
import { UserService } from 'src/app/services/user.service';
import { Training } from 'src/app/model/Training';
import { Router } from '@angular/router';

@Component({
  selector: 'app-notification',
  templateUrl: './notification.component.html',
  styleUrls: ['./notification.component.css']
})
export class NotificationComponent implements OnInit {
  public inprogressTrainings: Training[] = [];
  public confirmedTrainings: Training[] = [];
  public rejectedTrainings: Training[] = [];
  public filteredTrainings:Training[] = [];
  constructor(private user: UserService, private router: Router) {
    
  }

  makePayment(trainingId, mentorId, userId, technology) {
    console.log(`${trainingId},${mentorId},${userId}`);
    // this.router.navigate(['sendrequest', { mentorId: mentorId,name:name, skillId: this.skillId, userId: userId,email:email }]);
    this.router.navigate(['makepayment', {
      trainingId: trainingId, mentorId: mentorId,
      userId: userId, technology: technology
    }]);
  }

  ngOnInit() {
    let userid = localStorage.getItem('userid');
    this.user.getTrainings().subscribe((value: Training[]) => {
      console.log(value);
      this.filteredTrainings = value.filter(x => x.userId.toString() == userid);
      this.inprogressTrainings = this.filteredTrainings.filter(x => x.status == "pending");
      this.confirmedTrainings = this.filteredTrainings.filter(x => x.status == "accepted");
      this.rejectedTrainings = this.filteredTrainings.filter(x => x.status == "rejected");
      console.log(this.inprogressTrainings);
    });
  }



}
