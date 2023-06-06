"use strict";
// tsc -t es6 .\symbole.ts
let symbole1 = Symbol("Unicite");
let symbole2 = Symbol("Unicite");
console.log(symbole1 == symbole2);
class Vegetal {
    constructor(nom) { this._nom = nom; }
    Affiche() {
        console.log('Végétal: ' + this._nom);
    }
    [Symbol.toPrimitive]() {
        return '::' + this._nom;
    }
    [Symbol.replace](val) {
        return `${this._nom} ${val}`;
    }
}
let ficus = new Vegetal('Ficus');
ficus.Affiche();
console.log(ficus);
console.log("==>" + ficus);
console.log('vert'.replace(ficus, 'ooo'));
class Vegetaux {
    constructor() {
        this._liste = [];
        this._liste.push(new Vegetal('Ficus'), new Vegetal('begonia'), new Vegetal('Yucca'));
    }
    [Symbol.iterator]() {
        let index = 0;
        let liste = this._liste;
        return {
            next() {
                let item = new VegetalIterator();
                if (index < liste.length) {
                    item.value = liste[index];
                    item.done = false;
                    index++;
                }
            }
        };
    }
}
class VegetalIterator {
    constructor() {
        this.done = true;
    }
}
