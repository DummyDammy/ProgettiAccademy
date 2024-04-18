import { Component } from '@angular/core';
import { Giocatore } from '../../models/giocatore';
import { GiocatoreService } from '../../services/giocatore.service';

@Component({
  selector: 'app-giocatore',
  templateUrl: './giocatore.component.html',
  styleUrl: './giocatore.component.css'
})
export class GiocatoreComponent {

  nome : string | undefined;
  colore : string | undefined;
  lista : Giocatore[] = new Array();
  handleInterval : any;

  constructor(private service : GiocatoreService){}

  stampa(){
    this.service.GetAll().subscribe(giocatori => {
      this.lista = <Giocatore[]>giocatori.data;
    })
  }

  elimina(colore : string | undefined){
    console.log(colore);
    this.service.DeleteByColor(<string>colore).subscribe(ris => {
      if (ris.stato == "SUCCESS"){
        this.stampa();
      }
      else
        alert("ERRORE");
    })
  }

  aggiungi(){
    let giocatore = new Giocatore();
    giocatore.name = this.nome;
    giocatore.color = this.colore;
    this.service.Insert(giocatore).subscribe(ris => {
      if (ris.stato == "SUCCESS"){
        this.stampa();
        this.nome = "";
        this.colore = "";
      }
      else
        alert("errore");
    });
  }

  modifica(){
    
  }

  ngOnInit(): void {
    //Called after the constructor, initializing input properties, and the first call to ngOnChanges.
    //Add 'implements OnInit' to the class.
    this.stampa();

    this.handleInterval = setInterval(() => {
      this.stampa();
    }, 1000);
  }

  ngOnDestroy(): void {
    //Called once, before the instance is destroyed.
    //Add 'implements OnDestroy' to the class.
    console.log("distrutta");
    clearInterval(this.handleInterval);
  }
}
