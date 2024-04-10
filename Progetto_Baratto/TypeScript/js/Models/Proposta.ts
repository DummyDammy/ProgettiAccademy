import { Oggetto } from "./Oggetto";
import { Utente } from "./Utente";

export class Proposta{

    protected oggettoMIT : Oggetto;
    protected utenteMIT : Utente;
    protected oggettoDES : Oggetto;
    protected utenteDES : Utente;

    constructor (oggettoMIT : Oggetto, oggettoDES : Oggetto, untenteMIT : Utente, utenteDES : Utente){
        this.oggettoMIT = oggettoMIT;
        this.utenteMIT = untenteMIT;
        this.oggettoDES = oggettoDES;
        this.utenteDES = utenteDES;
    }

    stampa() : string {
        return `${this.utenteMIT} - ${this.oggettoMIT}`;
    }
}