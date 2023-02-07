import { ChangeDetectionStrategy, Component, OnInit } from '@angular/core';
import { ChatMessage } from 'src/app/model/chatmessage.model';
import { ChatManagerService } from 'src/app/service/chat-manager.service';

@Component({
  selector: 'app-chat-viewport',
  templateUrl: './chat-viewport.component.html',
  styleUrls: ['./chat-viewport.component.css']
})
export class ChatViewportComponent implements OnInit {
  
  public userName:string="";
  public inputMessage:string="";
  public messageCollection:ChatMessage[] = [];

  constructor(private chatManager:ChatManagerService){}

  ngOnInit(){
    this.userName = this.chatManager.getUser();    
    
    this.messageCollection.push(new ChatMessage('Machine',`Welcome ${this.userName}`));

    this.chatManager.startChatService().then(_ => {

      console.log('Connection success!');
      this.chatManager.onMessageReceived(this,this.receiveMessage);

    }).catch(error => {
      console.error(error);
    });
  }

  public sendMessage():void{
    
    let chat:ChatMessage =new ChatMessage(this.userName,this.inputMessage);

    this.chatManager.sendMessage(chat);
    this.inputMessage = "";
  }

  public receiveMessage(chatMessage: ChatMessage):void{    
    this.messageCollection.push(chatMessage);
  }

}
