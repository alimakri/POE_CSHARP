"use strict";
// Fonction générique
function AfficherV1(s) { console.log(s); }
let n = 1;
let texte = 'texte';
AfficherV1(n + 2);
AfficherV1(texte + '1');
function AfficherV2(s) { console.log(s); }
AfficherV2(n + 1);
AfficherV2(texte + '2');
// Classe générique
class Affichage {
    AfficherV3(s) { console.log(s); }
}
console.log('------------------');
let aff = new Affichage();
aff.AfficherV3(n + 3);
// aff.AfficherV3(texte);
class Personne1 {
    constructor(nom) { this.nom = nom; }
}
class Employe extends Personne1 {
}
class Identite {
    AfficherV4(p) { console.log(p.nom); }
}
class Animal1 {
    constructor(nom) { this.nom = nom; }
}
class Animal2 {
    constructor(nom) { this.surNom = nom; }
}
class Animal3 {
    constructor(nom) {
        this.age = 0;
        this.nom = nom;
    }
}
let pAlain = new Personne1('Alain');
let identite1 = new Identite();
identite1.AfficherV4(pAlain);
let pVero = new Employe('Vero');
let identite2 = new Identite();
identite1.AfficherV4(pVero);
let pMilou = new Animal1('Milou');
let identite3 = new Identite(); // même structure
identite3.AfficherV4(pMilou);
// let pIdefix = new Animal1('Idefix');
// let identite4 = new Identite<Animal2>(); // structure différente
// identite4.AfficherV4(pIdefix);
let pRintintin = new Animal3('Rintintin');
let identite4 = new Identite(); // structure différente
identite4.AfficherV4(pRintintin);
