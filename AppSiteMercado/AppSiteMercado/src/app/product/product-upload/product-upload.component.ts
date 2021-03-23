import {ProductService} from './../shared/product.service'
import { Component, OnInit } from '@angular/core';
import {Product} from './../shared/product'
import { ActivatedRoute, Router } from '@angular/router';


@Component({
  selector: 'app-product-upload',
  templateUrl: './product-upload.component.html',
  styleUrls: ['./product-upload.component.css']
})
export class ProductUploadComponent implements OnInit {
  product: Product = new Product();
 
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
      });
    }
  }
  inputEventChange(event){

      if(event.target.files && event.target.files[0]){
         const files = event.target.files[0];
         let formData: FormData = new FormData();
         
        let fileName =  this.product.name+'_'+this.product.id;
         formData.append('file'+this,files,fileName);
         formData.append('id', this.product.id.toString());
         this.productService.Upload(formData).subscribe();
         this.product.image = fileName;
         this.product.updatedUser='alessandro'
         this.productService.save(this.product);
      }

  }
  

}
