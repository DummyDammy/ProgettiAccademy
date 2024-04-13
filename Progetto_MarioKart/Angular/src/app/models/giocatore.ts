import { Personaggio } from "./personaggio";

export class Giocatore {

    name : string | undefined;
    credits : number | undefined;
    color : string | undefined;
    characters : Personaggio[] = new Array();

}
