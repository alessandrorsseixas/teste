import {HomeComponent} from './layout/home/home.component'
import { TaskFormComponent } from './tasks/task-form/task-form.component';
import { TaskListComponent } from './tasks/task-list/task-list.component';
import {ProductFormComponent}from './product/product-form/product-form.component'
import {ProductListComponent} from './product/product-list/product-list.component'
import {ProductUploadComponent} from './product/product-upload/product-upload.component'
import {ProductTableComponent} from './product/product-table/product-table.component'
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AuthenticationComponent } from './layout/authentication/authentication.component';
import { LoginComponent } from './account/login/login.component';


const routes: Routes = [
 {
  path: '',
  component:HomeComponent,
  children:[
    { path: '', component: ProductTableComponent },
    { path: 'new', component: ProductFormComponent },
    { path: 'edit/:id', component: ProductFormComponent },
    { path: 'upload/:id', component: ProductUploadComponent}
  ],
  //canActivate:[AuthGuard]
 },
 {
    path:'login',
    component:AuthenticationComponent,
    children:[

      {path:'',component:LoginComponent}
    ]
 }
];
@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
