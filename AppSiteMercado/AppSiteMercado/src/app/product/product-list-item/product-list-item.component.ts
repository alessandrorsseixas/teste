import { Component, OnInit, Input, EventEmitter, Output } from '@angular/core';
import {ProductService } from './../shared/product.service'
import {Product} from './../shared/product'

@Component({
  selector: 'app-product-list-item',
  templateUrl: './product-list-item.component.html',
  styleUrls: ['./product-list-item.component.css']
})
export class ProductListItemComponent implements OnInit {
  @Input()
  product: Product;

  @Output()
  onDeleteProduct = new EventEmitter()
  constructor(private productService: ProductService) { }
  
  ngOnInit() {

    
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
