import { NgModule, Component } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { RegisteruserComponent } from './components/registeruser/registeruser.component';
import { LoginComponent } from './components/login/login.component';
import { AuthGuard } from './services/auth.guard';
import { UserhomeComponent } from './components/userhome/userhome.component';
import { SearchtechnologyComponent } from './components/userhome/searchtechnology/searchtechnology.component';
import { SendrequestComponent } from './components/userhome/sendrequest/sendrequest.component';
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
import { MentortrainingComponent } from './components/mentorhome/mentortraining/mentortraining.component';

const routes: Routes = [
  { path: '', component: LoginComponent },
  { path: 'login', component: LoginComponent },  
  { path: 'registeruser', component: RegisteruserComponent },
  { path: 'registermentor', component: RegistermentorComponent },
  { path: 'userhome', component: UserhomeComponent, canActivate: [AuthGuard] },
  { path: 'searchtechnology', component: SearchtechnologyComponent, canActivate: [AuthGuard] },
  { path: 'sendrequest', component: SendrequestComponent, pathMatch: 'full', canActivate: [AuthGuard] },
  { path: 'notification', component: NotificationComponent, canActivate: [AuthGuard] },
  { path: 'currenttraining', component: CurrenttrainingComponent, canActivate: [AuthGuard] },
  { path: 'completedtraining', component: CompletedtrainingComponent, canActivate: [AuthGuard] },
  { path: 'userprofile', component: UserprofileComponent, canActivate: [AuthGuard] },
  { path: 'mentorhome', component: MentorhomeComponent, canActivate: [AuthGuard] },
  { path: 'mentornotification', component: MentornotificatonComponent, canActivate: [AuthGuard] },
  { path: 'mentorProfile', component: MentorprofileComponent, canActivate: [AuthGuard] },
  { path:'mentortraining',component:MentortrainingComponent, canActivate:[AuthGuard]},
  { path: 'makepayment', component: MakepaymentComponent, canActivate: [AuthGuard] },
  { path: 'userPayments', component: PaymentComponent, canActivate: [AuthGuard] },  
];

@NgModule({
  imports: [RouterModule.forRoot(routes,{ useHash: true })],
  exports: [RouterModule]
})
export class AppRoutingModule { }
