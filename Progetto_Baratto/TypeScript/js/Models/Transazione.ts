import { Oggetto } from "./Oggetto";
import { Proposta } from "./Proposta";
import { Utente } from "./Utente";

export class Transazione extends Proposta{

    private codice : string = Math.random().toString(36).substring(2,10).toUpperCase();
    
    constructor (oggettoMIT : Oggetto, oggettoDES : Oggetto, utenteMIT : Utente, utenteDES : Utente){
        super(oggettoMIT,oggettoDES,utenteMIT, utenteDES);
    }

    stampa() : string {
        return `${this.codice}: ${this.utenteMIT} - ${this.oggettoMIT} | ${this.utenteDES} ${this.oggettoDES}`;
    }
}