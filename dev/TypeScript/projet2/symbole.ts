// tsc -t es6 .\symbole.ts

let symbole1 = Symbol("Unicite");
let symbole2 = Symbol("Unicite");
console.log(symbole1==symbole2);

class Vegetal{
    private _nom:string;
    constructor(nom:string){this._nom=nom;}
    public Affiche():void{
        console.log('Végétal: '+this._nom);
    }
    [Symbol.toPrimitive]():string{
        return '::' + this._nom;
    }
    [Symbol.replace](val:string):string{
        return `${this._nom} ${val}`;
    }
}
let ficus :Vegetal = new Vegetal('Ficus');
ficus.Affiche();
console.log(ficus);
console.log("==>" + ficus);
console.log('vert'.replace(ficus, 'ooo'));

