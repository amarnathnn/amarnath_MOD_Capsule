import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { UserService } from 'src/app/services/user.service';
import { ResponseMessage } from 'src/app/model/ResponseMessage';

@Component({
  selector: 'app-makepayment',
  templateUrl: './makepayment.component.html',
  styleUrls: ['./makepayment.component.css']
})
export class MakepaymentComponent implements OnInit {
  private mentorId: number;
  private userId: number;
  private trainingId: number;
  private technology: string;
  public makePaymentResponse: ResponseMessage;


  constructor(private activatedRoute: ActivatedRoute, private user: UserService) {
    this.makePaymentResponse = { errorMessage: "", successMessage: "" };

    this.activatedRoute.params.subscribe((params) => {
      console.log(params);
      this.mentorId = params["mentorId"];
      this.userId = params["userId"];
      this.trainingId = params["trainingId"];
      this.technology = params["technology"];
    });
  }

  ngOnInit() {
  }

  onSubmit(data) {
    // console.log(data);
    data.MentorId = this.mentorId;
    data.UserId = this.userId;
    data.TrainingId = this.trainingId;
    console.log(data);
    this.user.makePayment(data).subscribe((data) => {
      console.log(data);
      this.makePaymentResponse = data;
      this.user.updateTraining(this.trainingId).subscribe((value: ResponseMessage) => {
        console.log(value);
      });

    });
  }

}
