import { NgModule, Injector } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule } from '@angular/forms';

import { CoreComponent } from './core.component';

// Core
import { ServiceLocator } from '../core/service-locator';

// Ex-Modules
import {ToastrModule} from 'ngx-toastr';

// Services
import { ApiService } from './services/api.service';
import { BaseService } from './services/base.service';
import { LocalStorageService } from './services/local-storage.service';
import { WarehouseService } from './services/warehouse.service';
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



@NgModule({
  imports: [CommonModule,
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
    WarehouseService,
    ProductService,
    CrudService,
    CommonService,
    SubscribeService,
    FileService,
    PermissionService,
    ConfigurationService,
    CustomerService,
    EventsService,
    MessageService
  ]
})
export class CoreModule {
  constructor(private injector: Injector) {
    ServiceLocator.injecttor = this.injector;
  }
}
