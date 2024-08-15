import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { EditProfileComponent } from './edit-profile/edit-profile.component';
// importamos esto para usar la directiva ngModel dentro de los componentes
import { FormsModule } from '@angular/forms';
import { AppRoutingModule } from './../app-routing.module';


@NgModule({
  declarations: [
    LoginComponent,
    RegisterComponent,
    EditProfileComponent
  ],
  imports: [
    CommonModule,
    FormsModule,
    AppRoutingModule
  ]
})
export class AuthModule { }
