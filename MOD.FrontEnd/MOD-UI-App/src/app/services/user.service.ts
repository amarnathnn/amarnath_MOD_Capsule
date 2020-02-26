import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ResponseMessage } from '../model/ResponseMessage';
import { Skill } from '../model/skill';
import { Mentor } from '../model/mentor';
import { AppConfig } from '../model/appconfig';
import { Training } from '../model/Training';
import { User } from '../model/User';
import { Payment } from '../model/Payment';


@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private http: HttpClient, private config: AppConfig) { }

  register(data): Observable<ResponseMessage> {
    let response = null;
    let url = this.config.userUrl + "/register";

    return this.http.post<ResponseMessage>(url, data);
  }

  getSkills() {    
    let url = this.config.technologyUrl;
    return this.http.get<Skill[]>(url);
  }

  getSkillById(skillId) {
    let url = this.config.technologyUrl + "/" + skillId;
    return this.http.get<Skill>(url);

  }


  getMentorBySkill(skillId) {
    // let url=`http://localhost:7000/search/${skillId}`;
    let url = this.config.searchUrl + skillId;
    console.log(url);
    return this.http.get<Mentor[]>(url);
  }

  sendRequest(data): Observable<ResponseMessage> {
    let url = this.config.trainingUrl + "/addTraining";
    return this.http.post<ResponseMessage>(url, data);
  }

  makePayment(data): Observable<ResponseMessage> {
    let url = this.config.paymentUrl;
    return this.http.post<ResponseMessage>(url, data);
  }

  getPayments(userId, role) {
    let url = this.config.paymentUrl + "/" + userId + "/" + role;
    return this.http.get<Payment[]>(url);
  }


  updateTraining(id): Observable<ResponseMessage> {
    let url = this.config.trainingUrl + "/" + id + "/paymentdone";
    console.log(url);
    return this.http.post<ResponseMessage>(url, null);
  }

  getTrainings() {
    let url = this.config.trainingUrl + "/getTraining";
    return this.http.get<Training[]>(url);
  }

  getUserById(userId) {
    let url = this.config.userUrl + "/getuser?username=" + userId;
    return this.http.get<User>(url);
  }

  getMentorById(mentorName) {
    let url = this.config.userUrl + "/mentorDetails?mentorname=" + mentorName;
    console.log(url);
    return this.http.get<Mentor>(url);
  }
}
