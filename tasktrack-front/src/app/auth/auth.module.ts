import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { EditProfileComponent } from './edit-profile/edit-profile.component';



@NgModule({
  declarations: [
    LoginComponent,
    RegisterComponent,
    EditProfileComponent
  ],
  imports: [
    CommonModule
  ]
})
export class AuthModule { }
