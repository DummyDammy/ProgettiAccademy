import { Oggetto } from "./oggetto";
import { Utente } from "./utente";

export class Proposta {

    protected oggettoMIT : Oggetto | undefined;
    protected utenteMIT : Utente | undefined;
    protected oggettoDES : Oggetto | undefined;
    protected utenteDES : Utente | undefined;

    constructor (oggettoMIT? : Oggetto, oggettoDES? : Oggetto, untenteMIT? : Utente, utenteDES? : Utente){
        this.oggettoMIT = oggettoMIT;
        this.utenteMIT = untenteMIT;
        this.oggettoDES = oggettoDES;
        this.utenteDES = utenteDES;
    }

    stampa() : string {
        return `${this.utenteMIT} - ${this.oggettoMIT}`;
    }
}
