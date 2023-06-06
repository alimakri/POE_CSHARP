"use strict";
class Automobile {
    roule() { console.log("Roule"); }
}
class Bateau {
    vogue() { console.log("vogue"); }
}
class Amphibie {
}
function applyMixins(derivedCtor, baseCtors) {
    baseCtors.forEach(baseCtor => {
        Object.getOwnPropertyNames(baseCtor.prototype).forEach(name => {
            derivedCtor.prototype[name] = baseCtor.prototype[name];
        });
    });
}
applyMixins(Amphibie, [Automobile, Bateau]);
let frog12 = new Amphibie();
frog12.roule();
frog12.vogue();
