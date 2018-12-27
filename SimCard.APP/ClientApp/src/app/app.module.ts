import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { TableModule } from 'primeng/table';
import { DialogModule } from 'primeng/dialog';
import { InputTextModule } from 'primeng/inputtext';
import { ToastModule } from 'primeng/toast';
import { DropdownModule } from 'primeng/dropdown';
import { CalendarModule } from 'primeng/calendar';
import { PanelModule } from 'primeng/panel';
import { ButtonModule } from 'primeng/button';
import { TabViewModule } from 'primeng/tabview';
import { FileUploadModule } from 'primeng/fileupload';
import { CoreModule } from './core/core.module';

// Component
import { AppComponent } from './app.component';
import { SidebarComponent } from './shared/sidebar/sidebar.component';
import { HomeComponent } from './public/home/home.component';
import { CustomerComponent } from '././pages/customer/customer.component';
import { DateInputComponent } from './shared/date-input/date-input.component';
import { TableConfigurationComponent } from '././pages/customer/table-configuration/table-configuration.component';
import { SearchBoxComponent } from '././pages/customer/search-box/search-box.component';
import { ConfigurationComponent } from './pages/configColumn/configuration.component';
import { EventsComponent } from './pages/events/events.component';
import { ProductComponent } from './pages/product/product.component';
import { WarehouseComponent } from './pages/warehouse/warehouse.component';

// Service
import { MessageService } from 'primeng/api';
@NgModule({
    declarations: [
        AppComponent,
        SidebarComponent,
        HomeComponent,
        CustomerComponent,
        DateInputComponent,
        TableConfigurationComponent,
        SearchBoxComponent,
        ConfigurationComponent,
        EventsComponent,
        ProductComponent,
        WarehouseComponent
    ],
    imports: [
        CoreModule,
        ReactiveFormsModule,
        CalendarModule,
        DropdownModule,
        ToastModule,
        InputTextModule,
        DialogModule,
        BrowserAnimationsModule,
        TableModule,
        BrowserModule,
        ButtonModule,
        PanelModule,
        HttpClientModule,
        FormsModule,
        TabViewModule,
        FileUploadModule,
        RouterModule.forRoot([
            { path: '', component: HomeComponent, pathMatch: 'full' },
            { path: 'customer', component: CustomerComponent },
            { path: 'event', component: EventsComponent },
            { path: 'config', component: ConfigurationComponent},
            { path: 'product', component: ProductComponent},
            { path: 'warehouse', component: WarehouseComponent}
        ])
    ],
    providers: [MessageService],
    bootstrap: [AppComponent]
})
export class AppModule { }
