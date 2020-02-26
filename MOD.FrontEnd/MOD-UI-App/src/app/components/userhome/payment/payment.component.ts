import { Component, OnInit } from '@angular/core';
import { UserService } from 'src/app/services/user.service';
import { Payment } from 'src/app/model/Payment';

@Component({
  selector: 'app-payment',
  templateUrl: './payment.component.html',
  styleUrls: ['./payment.component.css']
})
export class PaymentComponent implements OnInit {
  public payments: Payment[];
  userId:string;
  role:string;
  constructor(private user: UserService) {
     
   
   }
  getRole()
  {
    return localStorage.getItem('role');
  }

  ngOnInit() {
    this.userId = localStorage.getItem('userid');
    this.role = localStorage.getItem('role');
    this.user.getPayments(this.userId,this.role).subscribe((value: Payment[]) => {
      this.payments = value;
      console.log(value);
    })
  }

}
