import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import {HttpClientModule} from '@angular/common/http';
import {FormsModule} from '@angular/forms';

import { AppComponent } from './app.component';
import { ShopService } from '../../Services/Shop.service';
import { ProductComponent } from './product/product.component';
import { AddproductComponent } from './product/addproduct/addproduct.component';


@NgModule({
   declarations: [
      AppComponent,
      ProductComponent,
      AddproductComponent
   ],
   imports: [
      BrowserModule,
      HttpClientModule,
      FormsModule
   ],
   providers: [
      ShopService
   ],
   bootstrap: [
      AppComponent
   ]
})
export class AppModule { }
