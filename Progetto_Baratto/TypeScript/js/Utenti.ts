import { Oggetto } from "./Models/Oggetto";
import { Utente } from "./Models/Utente";
import { Proposta } from "./Models/Proposta"
import { Transazione } from "./Models/Transazione"


const stampa = () => {

}

const aggiungi = () => {
    let elenco : Utente[] = JSON.parse(localStorage.getItem(`lista_utenti`) || '{}');

    let nominativo : string = $("#input_nominativo").val() as string;
    elenco.push(new Utente(nominativo));

    localStorage.setItem(`lista_utenti`, JSON.stringify(elenco));
}

$(document).ready(
    function(){
        console.log("oi");
        let listaUtenti = localStorage.getItem(`lista_utenti`);
        if(!listaUtenti){
            localStorage.setItem(`lista_utenti`, JSON.stringify([]));
        }

        stampa();

        $(".aggiungi").on("click", () => {
            aggiungi();
        });
    }
);