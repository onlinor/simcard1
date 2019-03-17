import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {FormsModule, ReactiveFormsModule} from '@angular/forms';
import {BrowserAnimationsModule} from '@angular/platform-browser/animations';

import { SharedComponent } from './shared.component';
import { SidebarComponent } from './sidebar/sidebar.component';

// Modules
import { RouterModule } from '@angular/router';

// Ex-Modules
import {BsDropdownModule} from 'ngx-bootstrap/dropdown';
import {ModalModule} from 'ngx-bootstrap/modal';
import {PaginationModule} from 'ngx-bootstrap/pagination';
import {TooltipModule} from 'ngx-bootstrap/tooltip';
import {AlertModule} from 'ngx-bootstrap/alert';
import {TabsModule} from 'ngx-bootstrap/tabs';

// Components
import { LayoutComponent } from './layout/layout.component';

@NgModule({
  imports: [CommonModule,
    RouterModule,
    FormsModule,
    ReactiveFormsModule,
    BrowserAnimationsModule,
    BsDropdownModule.forRoot(),
    ModalModule.forRoot(),
    PaginationModule.forRoot(),
    TooltipModule.forRoot(),
    AlertModule.forRoot(),
    TabsModule.forRoot()
  ],
  exports: [LayoutComponent,
    SidebarComponent
  ],
  declarations: [
    SharedComponent,
    LayoutComponent,
    SidebarComponent
  ]
})
export class SharedModule {}
