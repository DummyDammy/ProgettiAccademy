import { Component } from '@angular/core';
import { Utente } from './Models/utente';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'Angular';

  constructor(){
    let listaUtenti = localStorage.getItem(`lista_utenti`);
    if (!listaUtenti){
      localStorage.setItem(`lista_utenti`,JSON.stringify([]));
    }
  }
}
