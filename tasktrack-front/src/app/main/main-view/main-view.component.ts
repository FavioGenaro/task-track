import { Component } from '@angular/core';

@Component({
  selector: 'app-main-view',
  templateUrl: './main-view.component.html',
  styleUrls: ['./main-view.component.css']
})
export class MainViewComponent {
  showCalendar: boolean = true; // password
  showKanban: boolean = false; // password

  showKanbanView(){
    this.showKanban=true;
    this.showCalendar=false;
  }

  showCalendarView(){
    this.showCalendar=true;
    this.showKanban=false;
  }

}
