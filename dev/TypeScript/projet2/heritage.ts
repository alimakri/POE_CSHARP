class Salarie{
    constructor(protected _nom:string, private _salaire:number){
        Salarie.n++;
    }
    public static n:number=0;
    public Salaire():number{return this._salaire;}
}

class Dev extends Salarie{
    constructor(nom:string, salaire:number, private _prime:number){
        super(nom, salaire);
    }
    public Salaire():number{return super.Salaire() + this._prime;}
}

let devCSharp = new Dev('Sophie', 3050, 750);
let devJava = new Dev('Aurélie', 2050, 250);

console.log(devCSharp.Salaire());
console.log('nombre de salariés : ' , Salarie.n);