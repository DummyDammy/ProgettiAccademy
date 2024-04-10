"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var Utente_1 = require("./Models/Utente");
var stampa = function () {
};
var aggiungi = function () {
    var elenco = JSON.parse(localStorage.getItem("lista_utenti") || '{}');
    var nominativo = $("#input_nominativo").val();
    elenco.push(new Utente_1.Utente(nominativo));
    localStorage.setItem("lista_utenti", JSON.stringify(elenco));
};
$(document).ready(function () {
    console.log("oi");
    var listaUtenti = localStorage.getItem("lista_utenti");
    if (!listaUtenti) {
        localStorage.setItem("lista_utenti", JSON.stringify([]));
    }
    stampa();
    $(".aggiungi").on("click", function () {
        aggiungi();
    });
});
