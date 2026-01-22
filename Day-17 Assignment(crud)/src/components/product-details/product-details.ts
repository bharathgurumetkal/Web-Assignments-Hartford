import { Component, inject } from '@angular/core';
import { ActivatedRoute, RouterLink } from '@angular/router';
import { Products as ProductService } from '../../services/products';

@Component({
  selector: 'app-product-details',
  imports: [RouterLink],
  templateUrl: './product-details.html',
  styleUrl: './product-details.css',
})
export class ProductDetails {
  private route=inject(ActivatedRoute)
  private productService=inject(ProductService)
  productId!:number;
  product:any;
  ngOnInit(){
    this.productId=Number(this.route.snapshot.paramMap.get('id'))
    this.product=this.productService.getProductById(this.productId)
  }

}
