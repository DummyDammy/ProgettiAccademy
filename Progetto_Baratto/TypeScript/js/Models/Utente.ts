import { Oggetto } from "./Oggetto";

export class Utente{

    private nominativo : string;
    private codice : string;
    private inventario : Oggetto[] = new Array();

    constructor(nominativo : string){
        this.nominativo = nominativo;
        this.codice = Math.random().toString(36).substring(2,10).toUpperCase();
    }

    add(oggetto : Oggetto) : void {
        this.inventario.push(oggetto);
    }

    stampa() : string {
        return `${this.codice}: ${this.nominativo}`
    }
}