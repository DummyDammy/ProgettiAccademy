import { Component } from '@angular/core';
import { Stanza } from '../../models/stanza';
import { ProfiloService } from '../../services/profilo.service';
import { Router } from '@angular/router';
import { Messaggio } from '../../models/messaggio';

@Component({
  selector: 'app-profilo',
  templateUrl: './profilo.component.html',
  styleUrl: './profilo.component.css'
})
export class ProfiloComponent {

  listaStanze : Stanza[] = new Array();
  listaStanzeCreate : Stanza[] = new Array();
  listaStanzePartecipante : Stanza [] = new Array();
  nickname : string = "";
  stanzaCorrente : Stanza | undefined;
  inputStanza : string | undefined;
  inputDescrizione : string | undefined;
  inputEmail : string | undefined;
  inputPassword: string | undefined;
  messaggio : string | undefined;
  listaMessaggi : Messaggio[] = new Array();
  handleInterval : any;

  constructor(private service : ProfiloService, private router : Router) {}

  stampaStanze(){
    this.service.getStanze(this.nickname).subscribe(ris => {
      this.listaStanze = ris.data;
    });
  }

  logout(){
    this.router.navigateByUrl(`utente/login`);
  }

  creaStanza(){
    let stanza = new Stanza();
    stanza.title = <string>this.inputStanza;
    stanza.description = this.inputDescrizione;
    stanza.admin.nick = this.nickname;
    this.service.createRoom(stanza).subscribe(() => {
      this.stampaStanze();
    });
  }

  gestioneStanze(){
    this.service.getStanzeCreate(this.nickname).subscribe(ris => {
      this.listaStanzeCreate = ris.data;
    });
    this.service.getStanzePartecipante(this.nickname).subscribe(ris => {
      this.listaStanzePartecipante = ris.data;
    })
  }

  eliminaStanza(titolo : string | undefined){
    this.service.deleteStanza(<string>titolo).subscribe(() => {
      this.gestioneStanze();
      this.stampaStanze();
    });
  }

  lasciaStanza(titolo : string | undefined){
    let stanza : Stanza = new Stanza();
    stanza.title = <string>titolo;
    this.service.leaveRoom(stanza, this.nickname).subscribe(() => {
      this.gestioneStanze();
      this.stampaStanze();
    });
  }

  pushStanza(titolo : string){
    this.service.pushRoom(titolo).subscribe(ris => {
      this.stanzaCorrente = ris.data;
      console.log(this.stanzaCorrente);
    })
  }

  inviaMessaggio(){
    let message : Messaggio = new Messaggio();
    message.text = this.messaggio;
    console.log(message);
    console.log(this.stanzaCorrente);
    console.log(this.nickname);
    this.service.sendMessage(message, <string>this.stanzaCorrente?.title, this.nickname).subscribe((ris) =>{
      console.log(ris);
      this.pushStanza(<string>this.stanzaCorrente?.title);
    });
    this.messaggio = "";
  }

  ngOnInit(): void {
    this.nickname = <string>localStorage.getItem(`Nickname`);
    this.stanzaCorrente = new Stanza();
    this.stanzaCorrente.title = `Stanza corrente`;

    this.stampaStanze();
  }

  ngOnDestroy(): void {
    clearInterval(this.handleInterval);
  }
}
