import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { SharedComponent } from './shared.component';
import { SidebarComponent } from './sidebar/sidebar.component';

// Modules
import { RouterModule } from '@angular/router';

// Components
import { LayoutComponent } from './layout/layout.component';

@NgModule({
  imports: [
    CommonModule,
    RouterModule
  ],
  exports: [
    LayoutComponent
  ],
  declarations: [
    SharedComponent,
    LayoutComponent,
    SidebarComponent
  ]
})
export class SharedModule { }
