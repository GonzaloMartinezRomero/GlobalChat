export class ChatMessage{
    public user:string = "";
    public message:string = "";

    constructor(user: string, message: string) {
        this.user = user;
        this.message = message;
      }
}