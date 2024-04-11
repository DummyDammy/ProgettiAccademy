import { Utente } from "./Utente";

export class Oggetto{
    private nome: string;
    private descrizione : string | undefined;
    private codice : string = Math.random().toString(36).substring(2,10).toUpperCase();
    private utenteRIF : Utente;

    constructor(utenteRIF : Utente, nome: string, descrizione?: string){
        this.utenteRIF = utenteRIF;
        this.nome = nome;
        this.descrizione = descrizione;
    }

    stampa() : string{
        return `${this.codice}: | ${this.utenteRIF.stampa()} | ${this.nome} | ${this.descrizione}`;
    }
}