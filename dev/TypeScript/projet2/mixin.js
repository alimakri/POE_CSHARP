var Automobile = /** @class */ (function () {
    function Automobile() {
    }
    Automobile.prototype.roule = function () { console.log("Roule"); };
    return Automobile;
}());
var Bateau = /** @class */ (function () {
    function Bateau() {
    }
    Bateau.prototype.vogue = function () { console.log("vogue"); };
    return Bateau;
}());
var Amphibie = /** @class */ (function () {
    function Amphibie() {
    }
    return Amphibie;
}());
function applyMixins(derivedCtor, baseCtors) {
    baseCtors.forEach(function (baseCtor) {
        Object.getOwnPropertyNames(baseCtor.prototype).forEach(function (name) {
            derivedCtor.prototype[name] = baseCtor.prototype[name];
        });
    });
}
applyMixins(Amphibie, [Automobile, Bateau]);
var frog12 = new Amphibie();
frog12.roule();
frog12.vogue();
