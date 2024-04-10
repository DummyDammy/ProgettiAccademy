import { Component } from '@angular/core';
import { UtenteService } from '../../Services/utente.service';
import { Utente } from '../../Models/utente';

@Component({
  selector: 'app-utente-list',
  templateUrl: './utente-list.component.html',
  styleUrl: './utente-list.component.css'
})
export class UtenteListComponent {

  nominativo : string | undefined;
  lista : Utente [] = new Array();

  constructor(private service : UtenteService){ }

  aggiungi(){
    if (this.nominativo?.trim() != "" || !(this.nominativo == undefined)){
      this.service.aggiungi(new Utente(this.nominativo));
    }
    else{
      alert("Riempire il campo");
    }
  }
  
  ngOnInit(): void {
    //Called after the constructor, initializing input properties, and the first call to ngOnChanges.
    //Add 'implements OnInit' to the class.
    setTimeout(() => {
      this.lista = this.service.recupera();
    }, 500);
  }
}
