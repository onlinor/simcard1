import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { TableModule } from 'primeng/table';
import { DialogModule } from 'primeng/dialog';
import { InputMaskModule } from 'primeng/inputmask';
import { InputTextModule } from 'primeng/inputtext';
import { CheckboxModule } from 'primeng/checkbox';
import { ToastModule } from 'primeng/toast';
import { DropdownModule } from 'primeng/dropdown';
import { CalendarModule } from 'primeng/calendar';
import { PanelModule } from 'primeng/panel';
import { ButtonModule } from 'primeng/button';
import { TabViewModule } from 'primeng/tabview';
import { FileUploadModule } from 'primeng/fileupload';
import { MultiSelectModule } from 'primeng/multiselect';
import { CoreModule } from './core/core.module';
import { SharedModule } from './shared/shared.module';
import { AdministrationModule } from './administration/administration.module';
import { PublicModule } from './public/public.module';
import { AngularFontAwesomeModule } from 'angular-font-awesome';

// Component
import { AppComponent } from './app.component';
import { HomeComponent } from './public/home/home.component';
import { CustomerComponent } from '././pages/customer/customer.component';
import { DateInputComponent } from './shared/date-input/date-input.component';
import { TableConfigurationComponent } from '././pages/customer/table-configuration/table-configuration.component';
import { SearchBoxComponent } from '././pages/customer/search-box/search-box.component';
import { ConfigurationComponent } from './pages/configColumn/configuration.component';
import { EventsComponent } from './pages/events/events.component';
import { ProductComponent } from './pages/product/product.component';
import { WarehouseComponent } from './pages/warehouse/warehouse.component';
import { CashbookComponent } from './pages/cashbook/cashbook.component';
import { BankbookComponent } from './pages/bankbook/bankbook.component';
import { FormphieuchiComponent } from './public/formphieuchi/formphieuchi.component';
import { FormphieuthuComponent } from './public/formphieuthu/formphieuthu.component';
import { FooterComponent } from './shared/footer/footer.component';
import { HeaderComponent } from './shared/header/header.component';
import { FormphieuchibankbookComponent } from './public/formphieuchibankbook/formphieuchibankbook.component';
import { FormphieuthubankbookComponent } from './public/formphieuthubankbook/formphieuthubankbook.component';
import { NhaphangComponent } from './pages/nhaphang/nhaphang.component';
import { NetworkComponent } from './pages/network/network.component';

// Service
import { MessageService } from 'primeng/api';
import { LogService } from './shared/logging-services/log.service';
import { LogPublishersService } from './shared/logging-services/log-publishers.service';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    CustomerComponent,
    DateInputComponent,
    TableConfigurationComponent,
    SearchBoxComponent,
    ConfigurationComponent,
    EventsComponent,
    ProductComponent,
    WarehouseComponent,
    CashbookComponent,
    BankbookComponent,
    FormphieuchiComponent,
    FormphieuthuComponent,
    FooterComponent,
    HeaderComponent,
    FormphieuchibankbookComponent,
    FormphieuthubankbookComponent,
    NhaphangComponent,
    NetworkComponent
  ],
  imports: [
    CoreModule,
    SharedModule,
    AdministrationModule,
    PublicModule,
    ReactiveFormsModule,
    CalendarModule,
    InputMaskModule,
    DropdownModule,
    ToastModule,
    InputTextModule,
    DialogModule,
    CheckboxModule,
    BrowserAnimationsModule,
    TableModule,
    BrowserModule,
    ButtonModule,
    PanelModule,
    HttpClientModule,
    FormsModule,
    TabViewModule,
    MultiSelectModule,
    FileUploadModule,
    AngularFontAwesomeModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'customer', component: CustomerComponent },
      { path: 'event', component: EventsComponent },
      { path: 'config', component: ConfigurationComponent },
      { path: 'product', component: ProductComponent },
      { path: 'warehouse', component: WarehouseComponent },
      { path: 'cashbook', component: CashbookComponent },
      { path: 'bankbook', component: BankbookComponent },
      { path: 'nhaphang', component: NhaphangComponent },
      { path: 'network', component: NetworkComponent }
    ])
  ],
  providers: [MessageService, LogService, LogPublishersService],
  bootstrap: [AppComponent]
})
export class AppModule {}
