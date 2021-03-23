import { Component, OnInit, Input, EventEmitter, Output } from '@angular/core';
import {ProductService} from './../shared/product.service'
import {Product} from './../shared/product'
@Component({
  selector: 'app-product-table',
  templateUrl: './product-table.component.html',
  styleUrls: ['./product-table.component.css']
})
export class ProductTableComponent implements OnInit {
  
  @Input()
  product: Product;

  @Output()
  onDeleteProduct = new EventEmitter()
  constructor(private productService: ProductService) { }
  
  products: Product[] = [];  

  ngOnInit() {
    this.productService.getAll().subscribe(products => { 
      this.products = products;
    });
  }

  remove(product: Product) {
    this.productService.delete(product.id).subscribe(() => {
      this.onDeleteProduct.emit(product);
    });
  }

  onCompletedCheckChange(product: Product) {
    this.productService.save(product).subscribe(product => {
      console.log(product);
    });
  }
}
