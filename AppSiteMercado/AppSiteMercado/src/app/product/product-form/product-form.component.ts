import {ProductService} from './../shared/product.service'
import { Component, OnInit } from '@angular/core';
import {Product} from './../shared/product'
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-product-form',
  templateUrl: './product-form.component.html',
  styleUrls: ['./product-form.component.css']
})
export class ProductFormComponent implements OnInit {
  product: Product = new Product();
  title: string = 'Novo Produto';

  constructor(
    private activatedRoute: ActivatedRoute,
    private router: Router,
    private productService: ProductService
  ) { }

  ngOnInit() {
    const id = this.activatedRoute.snapshot.paramMap.get('id');
    if (id) {
      this.productService.getById(id).subscribe(product => {
        this.product = product;
        this.title = 'Alterando Produto';
      });
    }
  }
  onSubmit() {
    this.product.image= "teste";
    this.product.createdUser="alessandro"
    this.productService.save(this.product).subscribe(product => {
      console.log(product);
      this.router.navigate(['']);
    });
  }
}
