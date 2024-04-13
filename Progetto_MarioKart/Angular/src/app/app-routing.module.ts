import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { GiocatoreComponent } from './components/giocatore/giocatore.component';
import { PersonagioComponent } from './components/personagio/personagio.component';

const routes: Routes = [
  {path: "giocatori", component : GiocatoreComponent},
  {path: "personaggi", component : PersonagioComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
