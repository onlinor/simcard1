import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import {DropdownModule} from 'primeng/dropdown';
import {BrowserAnimationsModule} from '@angular/platform-browser/animations';

// Component
import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { CustomerComponent } from './customer/customer.component';
import { CustomerFormComponent } from './customer/customer-form/customer-form.component';
import { CustomerService } from './_services/customer-service/customer.service';
import { DateInputComponent } from './_commonComponent/date-input/date-input.component';
import { TableConfigurationComponent } from './customer/table-configuration/table-configuration.component';
import { SearchBoxComponent } from './customer/search-box/search-box.component';


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
        FilterPipe
    ],
    imports: [
        BrowserAnimationsModule,
        DropdownModule,
        BrowserModule,
        HttpClientModule,
        FormsModule,
        RouterModule.forRoot([
            { path: '', component: HomeComponent, pathMatch: 'full' },
            { path: 'counter', component: CounterComponent },
            { path: 'fetch-data', component: FetchDataComponent }
        ])
    ],
    providers: [CustomerService],
    bootstrap: [AppComponent],
    exports: [
        FilterPipe
    ]
})
export class AppModule { }
