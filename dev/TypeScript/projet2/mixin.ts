class Automobile {roule(){console.log("Roule");}}
class Bateau {vogue(){console.log("vogue");}}

class Amphibie implements Automobile, Bateau{
    roule: ()=>void;
    vogue: ()=>void;
}

function applyMixins(derivedCtor: any, baseCtors: any[]) {
    baseCtors.forEach(baseCtor => {
        Object.getOwnPropertyNames(baseCtor.prototype).forEach(name => {
            derivedCtor.prototype[name] = baseCtor.prototype[name];
        });
    });
}
applyMixins(Amphibie, [Automobile, Bateau]);

let frog12:Amphibie = new Amphibie();
frog12.roule();
frog12.vogue();
