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
