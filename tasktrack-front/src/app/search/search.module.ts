import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FilterByDateComponent } from './filter-by-date/filter-by-date.component';
import { FormsModule } from '@angular/forms';


@NgModule({
  declarations: [
    FilterByDateComponent
  ],
  imports: [
    CommonModule,
    FormsModule
  ],
  exports:[
    FilterByDateComponent
  ]
})
export class SearchModule { }
