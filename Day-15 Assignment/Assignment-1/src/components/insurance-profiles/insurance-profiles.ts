import { Component } from '@angular/core';

@Component({
  selector: 'app-insurance-profiles',
  imports: [],
  templateUrl: './insurance-profiles.html',
  styleUrl: './insurance-profiles.css',
})
export class InsuranceProfiles {
   profiles = [
    { name: 'Auto Insurance', img: '../../assets/car.png' },
    { name: 'Home Insurance', img: '../../assets/home.png' },
    { name: 'Business Insurance', img: '../../assets/business.png' },
    { name: 'Life Insurance', img: '../../assets/life.jpg' }
  ];
}
