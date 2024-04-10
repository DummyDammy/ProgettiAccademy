import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { UtenteListComponent } from './Components/utente-list/utente-list.component';

const routes: Routes = [
  {path: "", redirectTo: "utenti/lista", pathMatch:'full'},
  {path: "utenti/lista", component: UtenteListComponent},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
