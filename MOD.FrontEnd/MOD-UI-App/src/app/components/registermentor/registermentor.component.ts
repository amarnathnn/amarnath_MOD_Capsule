import { Component, OnInit } from '@angular/core';
import { UserService } from 'src/app/services/user.service';
import { Router } from '@angular/router';
import { Skill } from 'src/app/model/skill';
import { ResponseMessage } from 'src/app/model/ResponseMessage';
import { MentorService } from 'src/app/services/mentor.service';

@Component({
  selector: 'app-registermentor',
  templateUrl: './registermentor.component.html',
  styleUrls: ['./registermentor.component.css']
})
export class RegistermentorComponent implements OnInit {
  public registerResponse: ResponseMessage = { errorMessage: "", successMessage: "" };
  private skills: Skill[] = [];
  selectedTime:string;
  selectedSkill:string;
  constructor(private user: UserService, private router: Router,
    private mentor: MentorService) {
    user.getSkills().subscribe((value: Skill[]) => {
      this.skills = value;
      console.log(this.skills);
    });
  }

  ngOnInit() {
  }
  onSubmit(data) {
    debugger;
    //  console.log(data);
    let status = this.validate(data);
    // alert(status);
    if (!status) {
      return;
    }
    data.active = true;
    data.ForceResetPassword = true;
    data.MentorSkills = [{"SkillId": data.technology }];
    data.MentorCalendars = [{ "Timing": data.timing }];
    console.log(data);
    this.mentor.register(data).subscribe((value: ResponseMessage) => {
      console.log(value);
      this.registerResponse = value;
      console.log("component: " + this.registerResponse);
      console.log(this.registerResponse.errorMessage);
    }
    );
  }

  changeSkill(value){
    this.selectedSkill = value;
  }
  changeScheduleTimings(selectedValue:string)
  {
    debugger;
    console.log(selectedValue);
    this.selectedTime = selectedValue;
  }

  validate(data) {
    this.registerResponse = {
      errorMessage: ""
    };
    if (!data.mentorname || !data.firstname || !data.lastname
      || !data.password || !data.confirmpassword || !data.contactnumber || !data.email
      || !data.linkedinurl || data.technology == 0 || data.timings == 0
    ) {
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
