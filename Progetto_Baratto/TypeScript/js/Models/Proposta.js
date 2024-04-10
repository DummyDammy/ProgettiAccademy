"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.Proposta = void 0;
var Proposta = /** @class */ (function () {
    function Proposta(oggettoMIT, oggettoDES, untenteMIT, utenteDES) {
        this.oggettoMIT = oggettoMIT;
        this.utenteMIT = untenteMIT;
        this.oggettoDES = oggettoDES;
        this.utenteDES = utenteDES;
    }
    Proposta.prototype.stampa = function () {
        return "".concat(this.utenteMIT, " - ").concat(this.oggettoMIT);
    };
    return Proposta;
}());
exports.Proposta = Proposta;
