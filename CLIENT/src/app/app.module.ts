import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';


import { ReactiveFormsModule } from '@angular/forms';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { CoreModule } from './core/core.module';
import { ShopModule } from './shop/shop.module';


import {MatPaginatorModule} from '@angular/material/paginator';
import { SharedModule } from './shared/shared.module';
import { HomeModule } from './home/home.module';


@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    
    BrowserModule,
    AppRoutingModule,
    ReactiveFormsModule,
    
    HttpClientModule,
    CoreModule,
    SharedModule,
    HomeModule,
    MatPaginatorModule
   
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
