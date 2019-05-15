import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
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
import { PublicModule } from './public/public.module';
import { AngularFontAwesomeModule } from 'angular-font-awesome';
import { NgxPrintModule } from 'ngx-print';


// Component
import { AppComponent } from './app.component';
import { HomeComponent } from './public/home/home.component';
import { CustomerComponent } from '././pages/customer/customer.component';
import { DateInputComponent } from './shared/date-input/date-input.component';
import { TableConfigurationComponent } from '././pages/customer/table-configuration/table-configuration.component';
import { SearchBoxComponent } from '././pages/customer/search-box/search-box.component';
import { ConfigurationComponent } from './pages/configColumn/configuration.component';
import { EventsComponent } from './pages/events/events.component';
import { ExportProductComponent } from './pages/exportproduct/exportproduct.component';
import { SupplierComponent } from './pages/supplier/supplier.component';
import { CashbookComponent } from './pages/cashbook/cashbook.component';
import { BankbookComponent } from './pages/bankbook/bankbook.component';
import { FormphieuchiComponent } from './public/formphieuchi/formphieuchi.component';
import { FormphieuthuComponent } from './public/formphieuthu/formphieuthu.component';
import { FooterComponent } from './shared/footer/footer.component';
import { HeaderComponent } from './shared/header/header.component';
import { FormphieuchibankbookComponent } from './public/formphieuchibankbook/formphieuchibankbook.component';
import { FormphieuthubankbookComponent } from './public/formphieuthubankbook/formphieuthubankbook.component';
import { ImportProductComponent } from './pages/importproduct/importproduct.component';
import { NetworkComponent } from './pages/network/network.component';
import { DebtbookComponent } from './pages/debtbook/debtbook.component';

// Service
import { MessageService } from 'primeng/api';
import { LogService } from './shared/logging-services/log.service';
import { LogPublishersService } from './shared/logging-services/log-publishers.service';
import { ProductExchangeService } from './core/services';
import { ReportHomeComponent } from './pages/report-home/report-home.component';
import { LoginComponent } from './pages/login/login.component';
import { JwtInterceptor, ErrorInterceptor } from './core/interceptors';
import { AuthGuard } from './core/guards/auth.guard';
import { ListproductComponent } from './pages/listproduct/listproduct.component';


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
    ExportProductComponent,
    SupplierComponent,
    CashbookComponent,
    BankbookComponent,
    FormphieuchiComponent,
    FormphieuthuComponent,
    FooterComponent,
    HeaderComponent,
    FormphieuchibankbookComponent,
    FormphieuthubankbookComponent,
    ReportHomeComponent,
    ImportProductComponent,
    NetworkComponent,
    LoginComponent,
    ListproductComponent,
    DebtbookComponent
  ],
  imports: [
    CoreModule,
    SharedModule,
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
    NgxPrintModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'customer', component: CustomerComponent, canActivate: [AuthGuard]},
      { path: 'event', component: EventsComponent, canActivate: [AuthGuard] },
      { path: 'config', component: ConfigurationComponent, canActivate: [AuthGuard] },
      { path: 'exportproduct', component: ExportProductComponent, canActivate: [AuthGuard] },
      { path: 'supplier', component: SupplierComponent, canActivate: [AuthGuard] },
      { path: 'cashbook', component: CashbookComponent, canActivate: [AuthGuard]},
      { path: 'bankbook', component: BankbookComponent, canActivate: [AuthGuard]},
      { path: 'importproduct', component: ImportProductComponent, canActivate: [AuthGuard] },
      { path: 'network', component: NetworkComponent, canActivate: [AuthGuard] },
      { path: 'report-home', component: ReportHomeComponent, canActivate: [AuthGuard] },
      { path: 'productexchange', component: ListproductComponent, canActivate: [AuthGuard] },
      { path: 'debtbook', component: DebtbookComponent},
      { path: 'login', component: LoginComponent }
    ], { useHash: true })
  ],
  providers: [
    MessageService,
    LogService,
    ProductExchangeService,
    LogPublishersService,
    { provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi: true },
    { provide: HTTP_INTERCEPTORS, useClass: ErrorInterceptor, multi: true }
  ],
  bootstrap: [AppComponent]
})
export class AppModule {}
