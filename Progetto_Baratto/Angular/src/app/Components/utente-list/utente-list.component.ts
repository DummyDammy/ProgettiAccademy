import { Component } from '@angular/core';
import { UtenteService } from '../../Services/utente.service';
import { Utente } from '../../Models/utente';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-utente-list',
  templateUrl: './utente-list.component.html',
  styleUrl: './utente-list.component.css'
})
export class UtenteListComponent {

  nominativo : string | undefined;
  lista : Utente [] = new Array();

  constructor(private service : UtenteService, private route : ActivatedRoute, private router : Router) {
    //il recupero dell'informazone per route si può fare solo in onInit pechè operazione perchè lenta
   }

  aggiungi(){
    if (this.nominativo?.trim() != "" || !(this.nominativo == undefined)){
      this.service.aggiungi(new Utente(this.nominativo));
      this.lista = this.service.recupera();
      this.nominativo = "";
    }
    else{
      alert("Riempire il campo");
    }
  }
  
  ngOnInit(): void {
    //Called after the constructor, initializing input properties, and the first call to ngOnChanges.
    //Add 'implements OnInit' to the class.
    this.lista = this.service.recupera();
    this.route.params.subscribe(parametri => { //subscribe è una funzione che aspetta finche la variabile non si popola
      console.log(parametri[`parametro`]); //dichiarato nel approuting http://localhost/utente-list/:parametro
    });
    //this.router.navigateByUrl("link"); per far navigare il browser
  }
}
