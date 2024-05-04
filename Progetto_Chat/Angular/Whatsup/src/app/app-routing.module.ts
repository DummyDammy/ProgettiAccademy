import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './components/login/login.component';
import { ProfiloComponent } from './components/profilo/profilo.component';

const routes: Routes = [
  {path: "", redirectTo: "utente/login", pathMatch: 'full'},
  {path: "utente/login", component: LoginComponent},
  {path: "profilo/home", component: ProfiloComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
