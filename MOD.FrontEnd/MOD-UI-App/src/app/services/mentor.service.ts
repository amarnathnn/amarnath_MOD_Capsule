import { Injectable } from '@angular/core';
import { ResponseMessage } from '../model/ResponseMessage';
import { AppConfig } from '../model/appconfig';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class MentorService {

  constructor(private http: HttpClient, private config: AppConfig) { }

  register(data): Observable<ResponseMessage> {
    let response = null;
    let url = this.config.mentorUrl + "/registermentor";

    return this.http.post<ResponseMessage>(url, data);
  }

  acceptTraining(id): Observable<ResponseMessage> {
    let url = this.config.trainingUrl + "/" + id + "/accept";
    console.log(url);
    return this.http.post<ResponseMessage>(url, null);
  }

  rejectTraining(id): Observable<ResponseMessage> {
    let url = this.config.trainingUrl + "/" + id + "/reject";
    console.log(url);
    return this.http.post<ResponseMessage>(url, null);
  }
}
