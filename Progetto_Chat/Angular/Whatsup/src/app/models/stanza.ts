import { Messaggio } from "./messaggio";
import { Utente } from "./utente";

export class Stanza {
    title : string = "";
    description : string | undefined;
    admin: Utente = new Utente();
    users : Utente[] | undefined;
    messages : Messaggio[] | undefined;
}
