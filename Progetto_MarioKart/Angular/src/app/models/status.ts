import { Giocatore } from "./giocatore";
import { Personaggio } from "./personaggio";

export class Status {

    stato : string | undefined;
    data : undefined | string | Giocatore[] | Giocatore | Personaggio [] | Personaggio | null;
}
