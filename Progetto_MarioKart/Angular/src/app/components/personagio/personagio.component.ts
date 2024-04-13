import { Component } from '@angular/core';
import { Personaggio } from '../../models/personaggio';

@Component({
  selector: 'app-personagio',
  templateUrl: './personagio.component.html',
  styleUrl: './personagio.component.css'
})
export class PersonagioComponent {
  nomePersonaggio : string | undefined;
  categoria : string | undefined;
  mezzo : string | undefined;
  costo : number | undefined;
  lista : Personaggio[] = new Array();
}
