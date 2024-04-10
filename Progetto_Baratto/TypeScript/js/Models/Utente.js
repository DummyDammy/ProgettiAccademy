"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.Utente = void 0;
var Utente = /** @class */ (function () {
    function Utente(nominativo) {
        this.inventario = new Array();
        this.nominativo = nominativo;
        this.codice = Math.random().toString(36).substring(2, 10).toUpperCase();
    }
    Utente.prototype.add = function (oggetto) {
        this.inventario.push(oggetto);
    };
    Utente.prototype.stampa = function () {
        return "".concat(this.codice, ": ").concat(this.nominativo);
    };
    return Utente;
}());
exports.Utente = Utente;
