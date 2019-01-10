import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

// In-Modules
import {CoreModule} from '../core/core.module';
import {SharedModule} from '../shared/shared.module';

// components
import { WarehouseModalComponent } from './modals';
import { AdministrationComponent } from './administration.component';

@NgModule({
  imports: [
    CommonModule,
    CoreModule,
    SharedModule,
    FormsModule,
    ReactiveFormsModule,
    BrowserAnimationsModule
  ],
  declarations: [
    AdministrationComponent,
    WarehouseModalComponent
  ],
  entryComponents: [
    WarehouseModalComponent
  ]
})
export class AdministrationModule { }
