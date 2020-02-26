import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { UserService } from 'src/app/services/user.service';
import { Skill } from 'src/app/model/skill';
import { ResponseMessage } from 'src/app/model/ResponseMessage';

@Component({
  selector: 'app-sendrequest',
  templateUrl: './sendrequest.component.html',
  styleUrls: ['./sendrequest.component.css']
})
export class SendrequestComponent implements OnInit {
  private mentorId: string;
  private skillId: string;
  private userId: string;
  public mentorName: string;
  public mentorEmail: string;
  public skill: Skill;
  public responseMessage: ResponseMessage

  constructor(private activatedRoute: ActivatedRoute, private router: Router, private user: UserService) {
    this.responseMessage = { errorMessage: "", successMessage: "" };
    this.activatedRoute.params.subscribe((params) => {
      console.log(params);
      this.mentorId = params['mentorId'];
      this.skillId = params['skillId'];
      this.userId = params['userId'];
      this.mentorEmail = params['email'];
      this.mentorName = params['name'];
      console.log(this.mentorEmail);
      console.log(this.mentorName);
    });

    this.user.getSkillById(this.skillId).subscribe((value: Skill) => {
      this.skill = value;
      console.log(this.skill);
    });
  }

  onSubmit(data) {
    console.log(data);
    data.UserId = this.userId;
    data.MentorId = this.mentorId;
    data.SkillId = this.skillId;
    data.Status = "pending";
    console.log(data);
    this.user.sendRequest(data).subscribe((data) => {
      console.log(data)
      this.responseMessage = data;
    });

  }

  ngOnInit() {
  }

}
