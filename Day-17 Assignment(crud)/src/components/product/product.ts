import { Component } from '@angular/core';
import { RouterLink } from "@angular/router";

@Component({
  selector: 'app-product',
  imports: [RouterLink],
  templateUrl: './product.html',
  styleUrl: './product.css',
})
export class Product {
    products = [
    {id: 1, name: 'Laptop'},
    {id: 2, name: 'Mobile'},
    {id: 3, name: 'Tablet'}
  ];

}
