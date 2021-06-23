import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { CustomerComponent } from './customer/customer.component';
import { RoomComponent } from './room/room.component';
import { RoomtypeComponent } from './roomtype/roomtype.component';
import { RoomdetailComponent } from './roomdetail/roomdetail.component';
import { RoomserviceComponent } from './roomservice/roomservice.component';
import { ServiceComponent } from './service/service.component';
import { RoomtypedetailComponent } from './roomtypedetail/roomtypedetail.component';
import { HeaderComponent } from './core/layout/header/header.component';
import { FooterComponent } from './core/layout/footer/footer.component';
import { CustomerdetailComponent } from './customerdetail/customerdetail.component';
import { LoginComponent } from './auth/login/login.component';
import { RegisterComponent } from './auth/register/register.component';

@NgModule({
  declarations: [
    AppComponent,
    CustomerComponent,
    RoomComponent,
    RoomtypeComponent,
    RoomdetailComponent,
    RoomserviceComponent,
    ServiceComponent,
    RoomtypedetailComponent,
    HeaderComponent,
    FooterComponent,
    CustomerdetailComponent,
    LoginComponent,
    RegisterComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
