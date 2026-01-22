import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class Products {
    products = [
    {id:1, name:'Laptop', price:50000},
    {id:2, name:'Mobile', price:20000}
  ];

    getProductById(id: number) {
    return this.products.find(p => p.id === id);
  }

  
}
