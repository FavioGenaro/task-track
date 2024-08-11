import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { CommonModule } from '@angular/common';
import { CalendarModule } from './calendar/calendar.module';
import { MainModule } from './main/main.module';
import { SearchModule } from './search/search.module';
import { KanbanModule } from './kanban/kanban.module';
import { AuthModule } from './auth/auth.module';
import { ManageTaskModule } from './manage-task/manage-task.module';

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    CommonModule,
    CalendarModule,
    MainModule,
    SearchModule,
    KanbanModule,
    AuthModule,
    ManageTaskModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
