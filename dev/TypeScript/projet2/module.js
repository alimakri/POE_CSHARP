System.register([], function (exports_1, context_1) {
    "use strict";
    var Revue, Livre;
    var __moduleName = context_1 && context_1.id;
    return {
        setters: [],
        execute: function () {
            Revue = class Revue {
                constructor(editeur, prix) { this.editeur = editeur; this.prix = prix; }
            };
            exports_1("Magazine", Revue);
            Livre = class Livre {
                constructor(titre, auteur) { this.titre = titre; this.auteur = auteur; }
            };
            exports_1("Livre", Livre);
        }
    };
});
