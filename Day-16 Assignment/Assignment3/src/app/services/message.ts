import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class Message {
  private data:string[]=[];
  getData(){
    return this.data;
  }
  addData(msg:string){
    this.data.push(msg);
  }
  
}
