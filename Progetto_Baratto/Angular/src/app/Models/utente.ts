import { Oggetto } from "./oggetto";

export class Utente {
    
    nominativo : string | undefined;
    codice : string;
    inventario : Oggetto[] = new Array();

    constructor(nominativo? : string){
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
