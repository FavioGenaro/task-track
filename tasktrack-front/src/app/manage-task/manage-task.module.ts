import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { EditTaskComponent } from './edit-task/edit-task.component';
import { CreateTaskComponent } from './create-task/create-task.component';



@NgModule({
  declarations: [
    EditTaskComponent,
    CreateTaskComponent
  ],
  imports: [
    CommonModule
  ]
})
export class ManageTaskModule { }
