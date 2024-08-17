import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NavbarComponent } from './navbar/navbar.component';
import { ModalDeleteComponent } from './modal-delete/modal-delete.component';
import { ModalSuccessComponent } from './modal-success/modal-success.component';
import { AppRoutingModule } from './../app-routing.module';


@NgModule({
  declarations: [
    NavbarComponent,
    ModalDeleteComponent,
    ModalSuccessComponent
  ],
  imports: [
    CommonModule,
    AppRoutingModule
  ],
  exports:[
    NavbarComponent,
    ModalSuccessComponent,
    ModalDeleteComponent
  ]
})
export class ComponentsModule { }
