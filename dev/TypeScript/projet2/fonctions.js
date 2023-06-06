"use strict";
function somme(a, b) {
    return a + b;
}
let somme2 = function (a, b) {
    return a + b;
};
var s1 = somme(1, 2);
var s2 = somme2(1, 2);
function sommeV1(a, b) { return a + b; }
function produitV1(x, y) {
    if (y === undefined)
        y = 1;
    return x * y;
}
function produitV2(x, y = 1) {
    if (y === undefined)
        y = 1;
    return x * y;
}
function produitV3(x, y) {
    let resultat = x;
    y.forEach(j => resultat *= j);
    return resultat;
}
// PersonneV1
function PersonneV1(nom) {
    this.nom = nom;
    setTimeout(() => {
        console.log("nom.v2: ", this.nom);
    }, 1000);
}
;
var p1 = new PersonneV1('Roger');
var PersonneV2 = function (nom) {
    this.nom = nom;
    setTimeout(() => {
        console.log("nom.v2: ", this.nom);
    }, 1000);
};
var p2 = new PersonneV2('Rabbit');
function fraction(x, y) {
    let op1 = 0, op2 = 0;
    let b = true;
    if (typeof x == "string")
        op1 = parseInt(x);
    else if (typeof x == "number")
        op1 = x;
    else
        b = false;
    if (typeof y == "string")
        op2 = parseInt(y);
    else if (typeof y == "number")
        op2 = y;
    else
        b = false;
    if (b && op2 != 0)
        return op1 / op2;
    return 0;
}
