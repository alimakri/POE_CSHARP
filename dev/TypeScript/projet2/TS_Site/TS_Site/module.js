"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.Livre = exports.Magazine = void 0;
var Revue = /** @class */ (function () {
    function Revue(editeur, prix) {
        this.editeur = editeur;
        this.prix = prix;
    }
    return Revue;
}());
exports.Magazine = Revue;
var Livre = /** @class */ (function () {
    function Livre(titre, auteur) {
        this.titre = titre;
        this.auteur = auteur;
    }
    return Livre;
}());
exports.Livre = Livre;
