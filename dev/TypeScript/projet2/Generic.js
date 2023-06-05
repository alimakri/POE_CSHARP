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
// Fonction générique
function AfficherV1(s) { console.log(s); }
var n = 1;
var texte = 'texte';
AfficherV1(n + 2);
AfficherV1(texte + '1');
function AfficherV2(s) { console.log(s); }
AfficherV2(n + 1);
AfficherV2(texte + '2');
// Classe générique
var Affichage = /** @class */ (function () {
    function Affichage() {
    }
    Affichage.prototype.AfficherV3 = function (s) { console.log(s); };
    return Affichage;
}());
console.log('------------------');
var aff = new Affichage();
aff.AfficherV3(n + 3);
// aff.AfficherV3(texte);
var Personne1 = /** @class */ (function () {
    function Personne1(nom) {
        this.nom = nom;
    }
    return Personne1;
}());
var Employe = /** @class */ (function (_super) {
    __extends(Employe, _super);
    function Employe() {
        return _super !== null && _super.apply(this, arguments) || this;
    }
    return Employe;
}(Personne1));
var Identite = /** @class */ (function () {
    function Identite() {
    }
    Identite.prototype.AfficherV4 = function (p) { console.log(p.nom); };
    return Identite;
}());
var Animal1 = /** @class */ (function () {
    function Animal1(nom) {
        this.nom = nom;
    }
    return Animal1;
}());
var pAlain = new Personne1('Alain');
var identite1 = new Identite();
identite1.AfficherV4(pAlain);
var pVero = new Employe('Vero');
var identite2 = new Identite();
identite1.AfficherV4(pVero);
var pMilou = new Animal1('Milou');
var identite3 = new Identite();
identite3.AfficherV4(pMilou);
