import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { WarehouseComponent } from './warehouse/warehouse.component';
import { HttpClientModule } from '@angular/common/http';
import { WarehouseService } from './services/warehouse.service';
import { FormsModule } from '@angular/forms';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ProductComponent } from './product/product.component';
import { TableModule } from 'primeng/table';
import { DialogModule } from 'primeng/dialog';
import { PanelModule, ButtonModule } from 'primeng/primeng';
import { InputTextModule } from 'primeng/inputtext';
import { DropdownModule } from 'primeng/dropdown';
import {CalendarModule} from 'primeng/calendar';



@NgModule({
   declarations: [
      AppComponent,
      WarehouseComponent,
      ProductComponent
   ],
   imports: [
      BrowserModule,
      AppRoutingModule,
      FormsModule,
      HttpClientModule,
      BrowserAnimationsModule,
      TableModule,
      DialogModule,
      ButtonModule,
      PanelModule,
      InputTextModule,
      DropdownModule,
      CalendarModule
   ],
   providers: [
      WarehouseService
   ],
   bootstrap: [
      AppComponent
   ]
})
export class AppModule { }
