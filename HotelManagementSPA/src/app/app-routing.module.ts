import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CustomerComponent } from './customer/customer.component';
import { CustomerdetailComponent } from './customerdetail/customerdetail.component';
import { RoomComponent } from './room/room.component';
import { RoomdetailComponent } from './roomdetail/roomdetail.component';
import { RoomserviceComponent } from './roomservice/roomservice.component';
import { RoomtypeComponent } from './roomtype/roomtype.component';
import { RoomtypedetailComponent } from './roomtypedetail/roomtypedetail.component';
import { ServiceComponent } from './service/service.component';
import { LoginComponent } from './auth/login/login.component';
import { RegisterComponent } from './auth/register/register.component';


const routes: Routes = [
  { path: "customer", component: CustomerComponent },
  { path: "room", component: RoomComponent },
  { path: "service", component:ServiceComponent },
  { path: "roomtype", component: RoomtypeComponent },
  { path: "roomtype/:id", component: RoomtypedetailComponent },
  { path: "room/:id", component: RoomdetailComponent },
  { path: "serv/:id", component: RoomserviceComponent },
  { path: "cust/:id", component: CustomerdetailComponent },
  { path: "login", component: LoginComponent },
  { path: "register", component: RegisterComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
