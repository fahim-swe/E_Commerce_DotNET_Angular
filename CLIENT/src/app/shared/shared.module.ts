import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PagingHeaderComponent } from './components/paging-header/paging-header.component';
import { PagerComponent } from './components/pager/pager.component';

import { MatPaginatorModule } from '@angular/material/paginator';


@NgModule({
  declarations: [
    PagingHeaderComponent,
    PagerComponent
  ],
  imports: [
    CommonModule,
    MatPaginatorModule,
   
  ],
  exports: [PagingHeaderComponent, PagerComponent]
})
export class SharedModule { }
