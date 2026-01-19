import { Component, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { Navbar } from "../components/navbar/navbar";
import { Description } from "../components/description/description";
import { WelcomeBanner } from "../components/welcome-banner/welcome-banner";
import { InsuranceProfiles } from '../components/insurance-profiles/insurance-profiles';
import { Footer } from "../components/footer/footer";
import { Header } from "../components/header/header";

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, Navbar, Description, WelcomeBanner, InsuranceProfiles, Footer, Header],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {
  protected readonly title = signal('Assignment-1');
}
