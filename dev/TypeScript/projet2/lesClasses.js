"use strict";
class Personne {
    constructor(a) {
        this.name = a;
    }
    direBonjour() {
        console.log("bonjour je m'appelle " + this.name);
    }
}
let p;
p = new Personne("Robert");
p.direBonjour();
class MammifereV1 {
    constructor(name) {
        this.name = name;
    }
}
let dauphin = new MammifereV1('Dauphin');
// identique à MammifereV1
class MammifereV2 {
    constructor(name) {
        this.name = name;
    }
}
let baleine = new MammifereV2('Baleine');
// identique à MammifereV1 sauf que name est private
class MammifereV3 {
    constructor(_name) {
        this._name = _name;
    }
    get name() { return this._name; }
}
let orque = new MammifereV3('Orque');
console.log(orque.name);
// version avec héritage
class Animal {
    constructor() {
        this.name = "";
        this.isMammifere = false;
    }
}
class MammifereV4 extends Animal {
    constructor(name) {
        super();
        this.isMammifere = true;
        this.name = name;
    }
}
let lamentin = new MammifereV4('Lamentin');
