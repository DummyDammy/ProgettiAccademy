import { Stanza } from "./stanza";
import { Utente } from "./utente";

export class Messaggio {

    sendDate : Date | undefined;
    sender : Utente | undefined;
    room : Stanza | undefined;
    text: string | undefined;
}
