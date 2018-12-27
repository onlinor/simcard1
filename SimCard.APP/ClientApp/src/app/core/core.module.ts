import { NgModule, Injector } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CoreComponent } from './core.component';

// Core
import { ServiceLocator } from '../core/service-locator';

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

@NgModule({
  imports: [CommonModule],
  declarations: [CoreComponent],
  providers: [
    ApiService,
    BaseService,
    LocalStorageService,
    WarehouseService,
    ProductService,
    FileService,
    ConfigurationService,
    CustomerService,
    EventsService
  ]
})
export class CoreModule {
  constructor(private injector: Injector) {
    ServiceLocator.injecttor = this.injector;
  }
}
