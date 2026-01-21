import { Component, inject } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Calculator as CalculatorService } from '../../app/services/calculator';

@Component({
  selector: 'app-calculator-component',
  imports: [FormsModule],
  templateUrl: './calculator-component.html',
  styleUrl: './calculator-component.css',
})
export class CalculatorComponent {
   num1: number = 0;
  num2: number = 0;
  result: number = 0;

  // 👇 Inject service
  private calcService = inject(CalculatorService);

  add() {
    this.result = this.calcService.add(this.num1, this.num2);
  }

  subtract() {
    this.result = this.calcService.subtract(this.num1, this.num2);
  }

  multiply() {
    this.result = this.calcService.multiply(this.num1, this.num2);
  }

  divide() {
    this.result = this.calcService.divide(this.num1, this.num2);
  }


}
