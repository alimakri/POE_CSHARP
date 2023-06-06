"use strict";
class Auto {
    constructor() {
        this.hybride = false;
        this.nombreRoues = 4;
    }
    rouler() {
    }
    freiner() {
    }
}
let auto1 = new Auto();
let auto2 = {
    'nombreRoues': 4,
    'rouler': function () { },
    'freiner': function () { },
    'hybride': true
};
let marques = ['Honda', 'Peugeot', 'Toyota'];
console.log(marques[2]);
