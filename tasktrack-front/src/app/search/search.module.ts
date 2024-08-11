import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FilterByDateComponent } from './filter-by-date/filter-by-date.component';



@NgModule({
  declarations: [
    FilterByDateComponent
  ],
  imports: [
    CommonModule
  ],
  exports:[
    FilterByDateComponent
  ]
})
export class SearchModule { }
