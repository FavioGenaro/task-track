import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './auth/login/login.component';
import { RegisterComponent } from './auth/register/register.component';
import { CalendarComponent } from './calendar/calendar/calendar.component';
import { EditProfileComponent } from './auth/edit-profile/edit-profile.component';
import { MainAppComponent } from './main/main-app/main-app.component';
import { KanbanComponent } from './kanban/kanban/kanban.component';
import { EditTaskComponent } from './manage-task/edit-task/edit-task.component';
import { CreateTaskComponent } from './manage-task/create-task/create-task.component';

const routes: Routes = [
  { path: '', redirectTo: '/login', pathMatch: 'full'},
  { path: 'login', component: LoginComponent },
  { path: 'register', component: RegisterComponent },
  { path: 'main', component: MainAppComponent, children:[
    { path: 'edit-profile', title:"Editar perfil", component: EditProfileComponent },
    { path: 'calendar', title:"Calendar", component: CalendarComponent },
    { path: 'Kanban', title:"Calendar", component: KanbanComponent },
    { path: 'edit-task', title:"Editar tarea", component: EditTaskComponent},
    { path: 'create-task', title:"Crear tarea", component: CreateTaskComponent},
    // { path: 'creartarea', title:"Crear tarea", component: CrearTareaComponent },
    { path: '', redirectTo: "/main/calendar", pathMatch: 'full'},
  ]
},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
