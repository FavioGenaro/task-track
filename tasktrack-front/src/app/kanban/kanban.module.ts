import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { KanbanComponent } from './kanban/kanban.component';
import { KanbanListComponent } from './kanban-list/kanban-list.component';
import { KanbanTaskComponent } from './kanban-task/kanban-task.component';



@NgModule({
  declarations: [
    KanbanComponent,
    KanbanListComponent,
    KanbanTaskComponent
  ],
  imports: [
    CommonModule
  ]
})
export class KanbanModule { }
