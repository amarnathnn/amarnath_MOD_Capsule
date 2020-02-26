import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { SidemenuComponent } from '../app/components/core/sidemenu/sidemenu.component';
import { NavigationComponent} from '../app/components/core/navigation/navigation.component';
@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'MOD-UI-App';
  isLogin :boolean =  false;  
  userDisplayName:string;
  constructor(private router: Router) {

  }
  ngOnInit() {
    debugger;    
    console.log(this.router.url);
    this.isLogin = localStorage.getItem('role') != undefined ? true:false;
  }

  getRole() {
    this.userDisplayName =  localStorage.getItem('userDisplayName');
    console.log(this.userDisplayName);
    return localStorage.getItem('role');
  }

  onSearchTechClick() {
    this.router.navigateByUrl("/searchtechnology");
  }

  onPaymentsClick() {
    this.router.navigateByUrl("/userPayments")
  }

  onNotificationClick() {
    if (this.getRole() == "user") {
      this.router.navigateByUrl("/notification");
    }
    if (this.getRole() == "mentor") {
      this.router.navigateByUrl("/mentornotification");
    }
  }

  onCurrentTrainingClick() {
    this.router.navigateByUrl("/currenttraining");
  }

  onCompletedTrainingClick() {
    this.router.navigateByUrl("/completedtraining");
  }

  onUserProfileClick() {
    this.router.navigateByUrl("/userprofile");
  }

  onMentorProfileClick() {
    this.router.navigateByUrl("/mentorProfile");
  }

  logOut() {
    localStorage.clear();
    this.isLogin = false;    
    this.router.navigate(['/login']);
    //this.router.navigateByUrl("/");
  }
}
