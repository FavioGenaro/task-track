import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NavbarComponent } from './navbar/navbar.component';
import { ModalDeleteComponent } from './modal-delete/modal-delete.component';
import { ModalSuccessComponent } from './modal-success/modal-success.component';



@NgModule({
  declarations: [
    NavbarComponent,
    ModalDeleteComponent,
    ModalSuccessComponent
  ],
  imports: [
    CommonModule
  ],
  exports:[
    NavbarComponent,
    ModalSuccessComponent,
    ModalDeleteComponent
  ]
})
export class ComponentsModule { }
