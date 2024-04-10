"use strict";
var __extends = (this && this.__extends) || (function () {
    var extendStatics = function (d, b) {
        extendStatics = Object.setPrototypeOf ||
            ({ __proto__: [] } instanceof Array && function (d, b) { d.__proto__ = b; }) ||
            function (d, b) { for (var p in b) if (Object.prototype.hasOwnProperty.call(b, p)) d[p] = b[p]; };
        return extendStatics(d, b);
    };
    return function (d, b) {
        if (typeof b !== "function" && b !== null)
            throw new TypeError("Class extends value " + String(b) + " is not a constructor or null");
        extendStatics(d, b);
        function __() { this.constructor = d; }
        d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
    };
})();
Object.defineProperty(exports, "__esModule", { value: true });
exports.Transazione = void 0;
var Proposta_1 = require("./Proposta");
var Transazione = /** @class */ (function (_super) {
    __extends(Transazione, _super);
    function Transazione(oggettoMIT, oggettoDES, utenteMIT, utenteDES) {
        var _this = _super.call(this, oggettoMIT, oggettoDES, utenteMIT, utenteDES) || this;
        _this.codice = Math.random().toString(36).substring(2, 10).toUpperCase();
        return _this;
    }
    Transazione.prototype.stampa = function () {
        return "".concat(this.codice, ": ").concat(this.utenteMIT, " - ").concat(this.oggettoMIT, " | ").concat(this.utenteDES, " ").concat(this.oggettoDES);
    };
    return Transazione;
}(Proposta_1.Proposta));
exports.Transazione = Transazione;
