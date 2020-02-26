import { Component, OnInit } from '@angular/core';
import { UserService } from 'src/app/services/user.service';
import { Skill } from 'src/app/model/skill';
import { Mentor } from 'src/app/model/mentor';
import { Router } from '@angular/router';

@Component({
  selector: 'app-searchtechnology',
  templateUrl: './searchtechnology.component.html',
  styleUrls: ['./searchtechnology.component.css']
})
export class SearchtechnologyComponent implements OnInit {
  private skills: Skill[]=[];
  private skillId: number;
  private mentors: Mentor[]=[];

  constructor(private user: UserService, private router: Router) {
    user.getSkills().subscribe((value: Skill[]) => {
      this.skills = value;
      console.log(this.skills);
    });
  }

  haveSkills():boolean {
    var count = this.mentors.length;
    console.log(count);
    var val = (count > 0) ? true : false;
    //alert(val);
    return (val);
  }

  changeSkill(skillId) {
    //console.log(skillId);
    this.skillId = skillId;
  }

  getMentorBySkill() {
    this.user.getMentorBySkill(this.skillId).subscribe((value: Mentor[]) => {
      this.mentors = value;
      console.log(this.mentors);
    });
  }

  sendRequest(mentorId,name,email) {
    let userId = localStorage.getItem('userid');
    console.log(mentorId);
    this.router.navigate(['sendrequest', { mentorId: mentorId,name:name, skillId: this.skillId, userId: userId,email:email }]);
  }

  ngOnInit() {
  }

}
