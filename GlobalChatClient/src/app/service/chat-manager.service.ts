import { Injectable, OnInit } from '@angular/core';
import { HubConnection } from '@microsoft/signalr';
import { HubConnectionBuilder } from '@microsoft/signalr/dist/esm/HubConnectionBuilder';
import { environment } from '../environments/environment';
import { ChatMessage } from '../model/chatmessage.model';

@Injectable({
  providedIn: 'root'
})
export class ChatManagerService{

  private connection: HubConnection;
  private user:string="";
  private isServiceInitialize:boolean = false;

  constructor() { 

    this.connection = new HubConnectionBuilder().withUrl(environment.urlChatServer)
                                                .build();
  }

  public registerUser(userName:string):void{
     this.user = userName;
  }

  public getUser():string{
    return this.user;
  }

  public sendMessage(message:ChatMessage):void{
    this.connection.invoke("SendMessage",message);
  }

  public onMessageReceived(componentInstance:any,eventListener:(msg:ChatMessage)=>void){
    this.connection.on("ReceiveNewMessage", message => eventListener.call(componentInstance,message));
  }

  public startChatService():Promise<any>{

    if(!this.isServiceInitialize){
        this.isServiceInitialize = true;
        return this.connection.start();
    }
    throw new Error("Service is already initialized");
  }

}
