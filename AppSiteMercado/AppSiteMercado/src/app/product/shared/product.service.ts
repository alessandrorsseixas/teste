import {environment} from '../../../environments/environment'
import {Product} from './product'
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { map, catchError } from 'rxjs/operators';
import { of, throwError, Observable } from 'rxjs';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class ProductService {

  constructor(private http: HttpClient,private router:Router) { }
 
  getAll() {
    return this.http.get<Product[]>(`${environment.api}/${environment.version}/products`);
  }

  getById(id: string) {
    return this.http.get<Product>(`${environment.api}/${environment.version}/products/${id}`);
  }

  save(product: Product) {
    const productViewModel = {
      id:0,
      name: product.name,
      active: product.active,
      value:product.value,
      image:product.image,
      createdUser:'',
      updatedUser:''
      };

    if (product.id) {
      productViewModel.updatedUser = product.updatedUser
      productViewModel.id = product.id;
      return this.http.put<Product>(`${environment.api}/${environment.version}/products`, productViewModel)
      .pipe(catchError(err => {
        if(err.status == 404) return of(false);
        throwError(err);
    }));
    } else {
      productViewModel.createdUser = product.createdUser
      return this.http.post<Product>(`${environment.api}/${environment.version}/products`, productViewModel)
            .pipe(map(res => true))
            .pipe(catchError(err => {
              if(err.status == 404) return of(false);
              throwError(err);
          }));
    }
    this.router.navigate(['']);

  }

  

  Upload(file:FormData) {


     return this.http.post<Product>(`${environment.api}/${environment.version}/products/upload?`, file)
     
  }

  delete(id: number) {
    return this.http.delete(`${environment.api}/${environment.version}/products/${id}`);
  }
}
