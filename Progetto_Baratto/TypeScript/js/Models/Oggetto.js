"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.Oggetto = void 0;
var Oggetto = /** @class */ (function () {
    function Oggetto(nome, codice, descrizione) {
        this.nome = nome;
        this.descrizione = descrizione;
        this.codice = codice;
    }
    Oggetto.prototype.stampa = function () {
        return "".concat(this.codice, ": ").concat(this.nome, " | ").concat(this.descrizione);
    };
    return Oggetto;
}());
exports.Oggetto = Oggetto;
