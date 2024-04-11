import { Injectable } from '@angular/core';
import { Utente } from '../Models/utente';

@Injectable({
  providedIn: 'root'
})
export class UtenteService {

  constructor() { }

  aggiungi(utente : Utente){

    let elenco : Utente[] = JSON.parse(localStorage.getItem(`lista_utenti`) || '{}');

    elenco.push(utente);

    localStorage.setItem(`lista_utenti`, JSON.stringify(elenco));
  }

  recupera() : Utente[]{
    return JSON.parse(localStorage.getItem(`lista_utenti`) || '{}');
  }
}
