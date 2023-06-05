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
