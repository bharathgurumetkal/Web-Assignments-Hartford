import { Component, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { MessageComponent } from "../components/message-component/message-component";
import { CalculatorComponent } from "../components/calculator-component/calculator-component";

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, MessageComponent, CalculatorComponent],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {
  protected readonly title = signal('Assignment3');
}
