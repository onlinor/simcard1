import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { SharedComponent } from './shared.component';
import { SidebarComponent } from './sidebar/sidebar.component';

// Modules
import { RouterModule } from '@angular/router';

// Components
import { LayoutComponent } from './layout/layout.component';

@NgModule({
  imports: [
    CommonModule,
    RouterModule,
    FormsModule,
    ReactiveFormsModule,
    BrowserAnimationsModule
  ],
  exports: [LayoutComponent, SidebarComponent],
  declarations: [SharedComponent, LayoutComponent, SidebarComponent]
})
export class SharedModule {}
