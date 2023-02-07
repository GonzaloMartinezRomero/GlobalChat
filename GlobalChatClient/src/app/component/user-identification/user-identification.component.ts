import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { ChatManagerService } from 'src/app/service/chat-manager.service';

@Component({
  selector: 'app-user-identification',
  templateUrl: './user-identification.component.html',
  styleUrls: ['./user-identification.component.css']
})
export class UserIdentificationComponent {

  public userName:string = "";

  constructor(private router:Router, private chatManager:ChatManagerService){}

  public submitUser(){    
    
    this.chatManager.registerUser(this.userName);
    this.router.navigate(['chatviewport']);
  }
}
