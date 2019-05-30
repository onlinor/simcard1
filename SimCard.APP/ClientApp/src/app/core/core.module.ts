import { NgModule, Injector } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule } from '@angular/forms';

import { CoreComponent } from './core.component';

// Core
import { ServiceLocator } from '../core/service-locator';

// Ex-Modules
import { ToastrModule } from 'ngx-toastr';

// Services
import {
  ApiService,
  BaseService,
  LocalStorageService,
  SupplierService,
  CommonService,
  ProductService,
  ReportService,
  ShopService,
  CashbookService,
  FileService,
  CustomerService,
  BankbookService,
  EventsService,
  MessageService,
  SubscribeService,
  PermissionService,
  ConfigurationService,
  CrudService,
  DocExportingService,
  AuthService,
  NetworkService,
  NetworkRangeService,
  PhieunhapService,
  PhieuxuatService,
  DebtbookService
} from './services';

@NgModule({
  imports: [
    CommonModule,
    ReactiveFormsModule,
    ToastrModule.forRoot({
      positionClass: 'toast-bottom-right'
    })
  ],
  declarations: [CoreComponent],
  providers: [
    ApiService,
    BaseService,
    LocalStorageService,
    SupplierService,
    ProductService,
    CrudService,
    CommonService,
    SubscribeService,
    FileService,
    PermissionService,
    ConfigurationService,
    CustomerService,
    EventsService,
    MessageService,
    CashbookService,
    BankbookService,
    ReportService,
    DocExportingService,
    ShopService,
    NetworkService,
    NetworkRangeService,
    PhieunhapService,
    AuthService,
    PhieuxuatService,
    DebtbookService
  ]
})
export class CoreModule {
  constructor(private injector: Injector) {
    ServiceLocator.injector = this.injector;
  }
}
