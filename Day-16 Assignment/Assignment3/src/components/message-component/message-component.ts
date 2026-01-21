import { Component, inject } from '@angular/core';
import { Message } from '../../app/services/message';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-message-component',
  imports: [FormsModule],
  templateUrl: './message-component.html',
  styleUrl: './message-component.css',
})
export class MessageComponent {
  messages:string[]=[];
  messageText:string='';
  
private msgService = inject(Message);

  addMessage(): void {
    this.msgService.addData(this.messageText);
    this.messages=this.msgService.getData();
    this.messageText=''
  } 

}
