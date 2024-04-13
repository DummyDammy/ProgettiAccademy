import { Giocatore } from "./giocatore";

export class Personaggio {

    name : string | undefined;
    category : string | undefined;
    veichle : string | undefined;
    cost : number | undefined;
    player : Giocatore | undefined;
}
