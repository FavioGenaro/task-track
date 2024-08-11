import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MainAppComponent } from './main-app/main-app.component';
import { AppRoutingModule } from './../app-routing.module';
import { ComponentsModule } from '../components/components.module';


@NgModule({
  declarations: [
    MainAppComponent
  ],
  imports: [
    CommonModule,
    AppRoutingModule,
    ComponentsModule,
  ],
  exports:[
    // MainAppComponent
  ]
})
export class MainModule { }
