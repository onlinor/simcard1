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
import {DropdownModule} from 'primeng/dropdown';
import {CalendarModule} from 'primeng/calendar';

// Component
import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { CustomerComponent } from './customer/customer.component';
import { DateInputComponent } from './_commonComponent/date-input/date-input.component';
import { TableConfigurationComponent } from './customer/table-configuration/table-configuration.component';
import { SearchBoxComponent } from './customer/search-box/search-box.component';
import { ConfigurationComponent } from './configColumn/configuration.component';
import { EventsComponent } from './events/events.component';

// Service
import { CustomerService } from './_services/customer-service/customer.service';
import { ConfigurationService } from './_services/configuration-service/configuration.service';
import { MessageService } from 'primeng/api';
import { EventsService } from './_services/events-service/events.service';
import { FileService } from './_services/fileExcel-service/file.service';

@NgModule({
    declarations: [
        AppComponent,
        NavMenuComponent,
        HomeComponent,
        CounterComponent,
        FetchDataComponent,
        CustomerComponent,
        DateInputComponent,
        TableConfigurationComponent,
        SearchBoxComponent,
        ConfigurationComponent,
        EventsComponent
    ],
    imports: [
        CalendarModule,
        DropdownModule,
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
    providers: [CustomerService, ConfigurationService, MessageService, EventsService, FileService],
    bootstrap: [AppComponent]
})
export class AppModule { }
