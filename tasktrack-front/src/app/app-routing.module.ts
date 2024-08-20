import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './auth/login/login.component';
import { RegisterComponent } from './auth/register/register.component';
import { EditProfileComponent } from './auth/edit-profile/edit-profile.component';
import { MainAppComponent } from './main/main-app/main-app.component';
import { EditTaskComponent } from './manage-task/edit-task/edit-task.component';
import { CreateTaskComponent } from './manage-task/create-task/create-task.component';
import { MainViewComponent } from './main/main-view/main-view.component';

const routes: Routes = [
  { path: '', redirectTo: '/login', pathMatch: 'full'},
  { path: 'login', component: LoginComponent },
  { path: 'register', component: RegisterComponent },
  { path: 'main', component: MainAppComponent, children:[
      { path: 'calendar', title:"Calendar", component: MainViewComponent },
      { path: 'edit-profile', title:"Editar perfil", component: EditProfileComponent },
      { path: 'edit-task', title:"Editar tarea", component: EditTaskComponent},
      { path: 'create-task', title:"Crear tarea", component: CreateTaskComponent},
      { path: '', redirectTo: "/main/calendar", pathMatch: 'full'},
    ]
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
