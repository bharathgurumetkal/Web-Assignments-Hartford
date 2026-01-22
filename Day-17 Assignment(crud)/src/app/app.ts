import { Component, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { Navbar } from "../components/navbar/navbar";
import { TodoListComponent } from "../components/todo-list-component/todo-list-component";
import { Product } from "../components/product/product";

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, Navbar, TodoListComponent, Product],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {
  protected readonly title = signal('secondapp');
}
