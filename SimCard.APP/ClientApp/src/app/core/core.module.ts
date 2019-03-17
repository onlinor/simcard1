import { NgModule, Injector } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule } from '@angular/forms';

import { CoreComponent } from './core.component';

// Core
import { ServiceLocator } from '../core/service-locator';

// Ex-Modules
import { ToastrModule } from 'ngx-toastr';

// Services
import { ApiService } from './services/api.service';
import { BaseService } from './services/base.service';
import { LocalStorageService } from './services/local-storage.service';
import { SupplierService } from './services/supplier.service';
import { ProductService } from './services/product.service';
import { FileService } from './services/file.service';
import { ConfigurationService } from './services/configuration.service';
import { CustomerService } from './services/customer.service';
import { EventsService } from './services/events.service';
import { MessageService } from './services/message.service';
import { SubscribeService } from './services/subscribe.service';
import { PermissionService } from './services/permission.service';
import { CrudService } from './services/crud.service';
import { CommonService } from './services/common.service';
import { CashbookService } from './services/cashbook.service';
import { BankbookService } from './services/bankbook.service';
import { ReportService, ShopService, DocExportingService } from './services';
import { NetworkService } from './services/network.service';
import { PhieunhapService } from './services/phieunhap.service';

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
    PhieunhapService
  ]
})
export class CoreModule {
  constructor(private injector: Injector) {
    ServiceLocator.injecttor = this.injector;
  }
}
