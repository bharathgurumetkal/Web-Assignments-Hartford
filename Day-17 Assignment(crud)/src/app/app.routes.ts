import { Routes } from '@angular/router';
import { Home } from '../components/home/home';
import { About } from '../components/about/about';
import { Login } from '../components/login/login';
import { Product } from '../components/product/product';
import { ProductDetails } from '../components/product-details/product-details';

export const routes: Routes = 
[
    {path:'',component:Home},
    {path:'products',component:Product},
    {path:'product/:id',component:ProductDetails},
    {path:'about',component:About},
    {path:'login',component:Login}
];
