import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MainAppComponent } from './main-app/main-app.component';
import { AppRoutingModule } from './../app-routing.module';
import { ComponentsModule } from '../components/components.module';
import { MainViewComponent } from './main-view/main-view.component';
import { CalendarModule } from '../calendar/calendar.module';
import { KanbanModule } from '../kanban/kanban.module';
import { SearchModule } from '../search/search.module';


@NgModule({
  declarations: [
    MainAppComponent,
    MainViewComponent
  ],
  imports: [
    CommonModule,
    AppRoutingModule,
    ComponentsModule,
    CalendarModule,
    KanbanModule,
    SearchModule
  ],
  exports:[
    // MainAppComponent
  ]
})
export class MainModule { }
