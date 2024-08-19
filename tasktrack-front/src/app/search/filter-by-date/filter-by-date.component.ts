import { Component } from '@angular/core';

@Component({
  selector: 'app-filter-by-date',
  templateUrl: './filter-by-date.component.html',
  styleUrls: ['./filter-by-date.component.css']
})
export class FilterByDateComponent {
  fechaInicio:string = "";
  fechaFin:string = "";

  mostrarCalendar(){
    // this.calendar = true;
    // this.kanban = false;
    // this.filtro = false;
  }

  mostrarKanban(){
    // this.calendar = false;
    // this.kanban = true;
    // this.filtro = false;
  }

  async filtrarTareas(){

    if (this.fechaInicio == '' || this.fechaFin == ''){
      console.log("Debe seleccionar ambas fechas")
      // this.mostrarCalendar();
    }else if(this.fechaInicio > this.fechaFin){
      console.log("La fecha de inicio es mayor a la fecha de fin")
    }else if(this.fechaInicio == this.fechaFin){
      console.log("La fecha de inicio y la fecha de fin son las mismas")
    }
    else{
      // this.calendar = false;
      // this.kanban = false;
      // this.filtro = true;

      let dataUser:string = ((localStorage.getItem('user_taskhub')==null) ? "" : String(localStorage.getItem('user_taskhub')));
      let userid = JSON.parse(dataUser).idUsuario;
      // await this.tasksService.filtrarTareas(userid,this.fechaInicio,this.fechaFin);
    }

  }
}
