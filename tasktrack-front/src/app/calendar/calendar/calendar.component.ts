import { Component } from '@angular/core';
import { CalendarOptions } from '@fullcalendar/core';
import timeGridPlugin from '@fullcalendar/timegrid';
import dayGridPlugin from '@fullcalendar/daygrid';
import esLocale from '@fullcalendar/core/locales/es';
import interactionPlugin from '@fullcalendar/interaction';
@Component({
  selector: 'app-calendar',
  templateUrl: './calendar.component.html',
  styleUrls: ['./calendar.component.css']
})
export class CalendarComponent {

  clickEvent (info:any) {
    // DOBLE CLICK AL ELEMENTO DEBE ABRIR EL EDITOR DE TAREAS
    // let lista = this.tasksService.tasks;
    // const func = (task:any) => {
    //   this.tasksService.taskEdit = task;
    //   this.router.navigate(['/main/editartarea']);
    // }

    info.el.ondblclick = function() {
      // console.log('Event: ', info.event);
      // console.log('Event: ', info.event.title);
      // console.log('Event: ', info.event.start);
      // console.log('Event: ', info.event.id);

      // this.editarTaksSelect();
      console.log('click');
      // console.log(lista)
      // console.log(lista.filter((task:any) => task.idTarea == Number(info.event.id))[0])
      // func(lista.filter((task:any) => task.idTarea == Number(info.event.id))[0])

    };
  }
  // events = this.dataCalendar.map((e:any)=> {
    
  //   return { title: e.nombre, start: new Date(e.fechaFin), id: e.idTarea }
  // });

  calendarOptions: CalendarOptions = {
    plugins: [dayGridPlugin,timeGridPlugin,interactionPlugin], //  
    initialView: 'dayGridMonth',
    locale: esLocale,
    eventClick: (info) => this.clickEvent(info),
    headerToolbar:{
      left: 'title',
      center: 'prev,next',
      right: 'dayGridMonth,timeGridWeek,timeGridDay'
    },
    editable: true,
    weekends: true,
    events: [
      { title: 'Meeting', start: new Date() },
      { title: 'Meeting', start: new Date() },
      { title: 'Meeting', start: new Date() },
      { title: 'Meeting', start: new Date() }
    ]
  };

}
