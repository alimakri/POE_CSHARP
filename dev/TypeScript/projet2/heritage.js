"use strict";
class Salarie {
    constructor(_nom, _salaire) {
        this._nom = _nom;
        this._salaire = _salaire;
        Salarie.n++;
    }
    Salaire() { return this._salaire; }
}
Salarie.n = 0;
class Dev extends Salarie {
    constructor(nom, salaire, _prime) {
        super(nom, salaire);
        this._prime = _prime;
    }
    Salaire() { return super.Salaire() + this._prime; }
}
let devCSharp = new Dev('Sophie', 3050, 750);
let devJava = new Dev('Aurélie', 2050, 250);
console.log(devCSharp.Salaire());
console.log('nombre de salariés : ', Salarie.n);
