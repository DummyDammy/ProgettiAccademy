import { Component } from '@angular/core';
import { Giocatore } from '../../models/giocatore';

@Component({
  selector: 'app-giocatore',
  templateUrl: './giocatore.component.html',
  styleUrl: './giocatore.component.css'
})
export class GiocatoreComponent {

  nome : string | undefined;
  colore : string | undefined;
  lista : Giocatore[] = new Array();
}
