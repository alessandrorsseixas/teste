import { Component, OnInit } from '@angular/core';
import {Product} from './../shared/product'
import {ProductService} from './../shared/product.service'

@Component({
  selector: 'app-product-list',
  templateUrl: './product-list.component.html',
  styleUrls: ['./product-list.component.css']
})
export class ProductListComponent implements OnInit {

  products: Product[] = [];

  constructor(private productService: ProductService) { }

  ngOnInit() {
    this.productService.getAll().subscribe(products => { 
      this.products = products;
    });
  }

  onTaskDeleted(product: Product) {
    if (product) {
      const index = this.products.findIndex((productItem) => productItem.id == product.id);
      this.products.splice(index, 1);
    }
  }

}
