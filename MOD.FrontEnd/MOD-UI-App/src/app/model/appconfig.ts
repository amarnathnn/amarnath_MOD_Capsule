import { Injectable } from '@angular/core';

@Injectable()
export class AppConfig {
    public authentication: string = "http://localhost:7000/authentication";
    public searchUrl: string = "http://localhost:7000/search/";
    public technologyUrl: string = "http://localhost:7000/technology";
    public trainingUrl: string = "http://localhost:7000/training";
    public userUrl: string = "http://localhost:7000/user/";
    public mentorUrl: string = "http://localhost:7000/user";
    public paymentUrl: string = "http://localhost:7000/payment";
}