import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { TableModule } from 'primeng/table';
import { DialogModule } from 'primeng/dialog';
import { InputTextModule } from 'primeng/inputtext';
import { ToastModule } from 'primeng/toast';

// Component
import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { CustomerComponent } from './customer/customer.component';
import { CustomerFormComponent } from './customer/customer-form/customer-form.component';
import { DateInputComponent } from './_commonComponent/date-input/date-input.component';
import { TableConfigurationComponent } from './customer/table-configuration/table-configuration.component';
import { SearchBoxComponent } from './customer/search-box/search-box.component';
import { ConfigurationComponent } from './configuration/configuration.component';

// Service
import { CustomerService } from './_services/customer-service/customer.service';
import { ConfigurationService } from './_services/configuration-service/configuration.service';
import { MessageService } from 'primeng/api';
// Pipe
import { FilterPipe } from './_pipe/filterPipe/filter.pipe';

@NgModule({
    declarations: [
        AppComponent,
        NavMenuComponent,
        HomeComponent,
        CounterComponent,
        FetchDataComponent,
        CustomerComponent,
        CustomerFormComponent,
        DateInputComponent,
        TableConfigurationComponent,
        SearchBoxComponent,
        FilterPipe,
        ConfigurationComponent
    ],
    imports: [
        ToastModule,
        InputTextModule,
        DialogModule,
        BrowserAnimationsModule,
        TableModule,
        BrowserModule,
        HttpClientModule,
        FormsModule,
        RouterModule.forRoot([
            { path: '', component: HomeComponent, pathMatch: 'full' },
            { path: 'counter', component: CounterComponent },
            { path: 'fetch-data', component: FetchDataComponent }
        ])
    ],
    providers: [CustomerService, ConfigurationService, MessageService],
    bootstrap: [AppComponent],
    exports: [
        FilterPipe
    ]
})
export class AppModule { }
