class Personne{
    name:string;
    constructor(a:string){
        this.name=a;
    }
    direBonjour(){
        console.log("bonjour je m'appelle " + this.name);
    }
}
let p:Personne;
p = new Personne("Robert");
p.direBonjour();

class MammifereV1{
    name:string; // public
    constructor(name:string){
        this.name = name;
    } 
}
let dauphin:MammifereV1 = new MammifereV1('Dauphin');

// identique à MammifereV1
class MammifereV2 {
    constructor(public name:string){}
}
let baleine:MammifereV2 = new MammifereV2('Baleine');

// identique à MammifereV1 sauf que name est private
class MammifereV3 {
    constructor(private _name:string){}
    get name(){return this._name;}
}
let orque:MammifereV3 = new MammifereV3('Orque');
console.log(orque.name);

// version avec héritage
abstract class Animal{
    public name:string="";
    protected isMammifere:boolean=false;
}
class MammifereV4 extends Animal{
    constructor(name:string){
        super();
        this.isMammifere = true;
        this.name=name;
    }
}
let lamentin:MammifereV4 = new MammifereV4('Lamentin');
