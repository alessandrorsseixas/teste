import {ProductService} from './../product/shared/product.service'
import { Component, OnInit } from '@angular/core';
import {Product} from './shared/product'
import { ActivatedRoute, Router } from '@angular/router';


@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.css']
})
export class ProductComponent implements OnInit {
 
  constructor(
  ) { }
  ngOnInit() {
    
  }
 
}
