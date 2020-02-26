import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';


import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginComponent } from './components/login/login.component';
import { RegisteruserComponent } from './components/registeruser/registeruser.component';
import { TokenInterceptorService } from './services/token-interceptor.service';
import { UserhomeComponent } from './components/userhome/userhome.component';
import { SearchtechnologyComponent } from './components/userhome/searchtechnology/searchtechnology.component';
import { SendrequestComponent } from './components/userhome/sendrequest/sendrequest.component';
import { AppConfig } from './model/appconfig';
import { NotificationComponent } from './components/userhome/notification/notification.component';
import { CurrenttrainingComponent } from './components/userhome/currenttraining/currenttraining.component';
import { CompletedtrainingComponent } from './components/userhome/completedtraining/completedtraining.component';
import { UserprofileComponent } from './components/userhome/userprofile/userprofile.component';
import { RegistermentorComponent } from './components/registermentor/registermentor.component';
import { MentorhomeComponent } from './components/mentorhome/mentorhome.component';
import { MentornotificatonComponent } from './components/mentorhome/mentornotificaton/mentornotificaton.component';
import { MakepaymentComponent } from './components/userhome/makepayment/makepayment.component';
import { PaymentComponent } from './components/userhome/payment/payment.component';
import { MentorprofileComponent } from './components/mentorhome/mentorprofile/mentorprofile.component';
import { NavigationComponent } from './components/core/navigation/navigation.component';
import { SidemenuComponent } from './components/core/sidemenu/sidemenu.component';
import { MentortrainingComponent } from './components/mentorhome/mentortraining/mentortraining.component';

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    RegisteruserComponent,
    UserhomeComponent,
    SearchtechnologyComponent,
    SendrequestComponent,
    NotificationComponent,
    CurrenttrainingComponent,
    CompletedtrainingComponent,
    UserprofileComponent,
    RegistermentorComponent,
    MentorhomeComponent,
    MentornotificatonComponent,
    MakepaymentComponent,
    PaymentComponent,
    MentorprofileComponent,
    NavigationComponent,
    SidemenuComponent,
    MentortrainingComponent,
    
    
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule
  ],
  providers: [{
    provide: HTTP_INTERCEPTORS,
    useClass: TokenInterceptorService,
    multi: true
  },
    AppConfig
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
