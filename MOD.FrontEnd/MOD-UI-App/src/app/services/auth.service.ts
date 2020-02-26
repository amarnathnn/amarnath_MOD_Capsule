import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { LoginInfo } from '../model/LoginInfo';
import { Router } from '@angular/router';
import {AppConfig} from '../model/appconfig'

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor(private http: HttpClient, private router: Router, private _config: AppConfig) { }

  register() {

  }

  login(data) {
    debugger;
    let username = data.username == undefined ? "":data.username;
    let password = data.password  == undefined ? "" :data.password;
    let url = this._config.authentication + "/authenticate?username="+username + "&password=" + password;
    console.log(url);
    return this.http.get<LoginInfo>(url);    
  }

  logout() {
    localStorage.clear();
  }

  getToken() {
    return localStorage.getItem('token');
  }
}
