import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ShopComponent } from './shop.component';
import { ProductItemComponent } from './product-item/product-item.component';

import { MatPaginatorModule } from '@angular/material/paginator';
import { SharedModule } from '../shared/shared.module';
import { ReactiveFormsModule } from '@angular/forms';



@NgModule({
  declarations: [
    ShopComponent,
    ProductItemComponent,    
  ],
  imports: [
    CommonModule,
    SharedModule,
    MatPaginatorModule,

    ReactiveFormsModule
  ],
  exports: [ShopComponent]
})
export class ShopModule { }
