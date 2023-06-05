// Fonction générique
function AfficherV1(s:any): void {console.log(s)}

let n:number = 1;
let texte:string = 'texte';
AfficherV1(n+2);
AfficherV1(texte + '1');

function AfficherV2<T>(s:T): void {console.log(s)}
AfficherV2<number>(n+1);
AfficherV2<string>(texte+'2');

// Classe générique
class Affichage<T>{
    AfficherV3(s:T):void{ console.log(s);}
}
console.log('------------------');
let aff = new Affichage<number>();
aff.AfficherV3(n+3);
// aff.AfficherV3(texte);

class Personne1 {
    nom:string;
    constructor(nom:string){this.nom=nom;}
}
class Employe extends Personne1{}
class Identite<T extends Personne1>{
    AfficherV4(p:T):void{console.log(p.nom); }
}
class Animal1 {
    nom:string;
    constructor(nom:string){this.nom=nom;}
}
class Animal2 {
    surNom:string;
    constructor(nom:string){this.surNom=nom;}
}
class Animal3 {
    nom:string;
    age:number=0;
    constructor(nom:string){this.nom=nom;}
}

let pAlain = new Personne1('Alain');
let identite1 = new Identite<Personne1>();
identite1.AfficherV4(pAlain);

let pVero = new Employe('Vero');
let identite2 = new Identite<Personne1>();
identite1.AfficherV4(pVero);

let pMilou = new Animal1('Milou');
let identite3 = new Identite<Animal1>(); // même structure
identite3.AfficherV4(pMilou);

// let pIdefix = new Animal1('Idefix');
// let identite4 = new Identite<Animal2>(); // structure différente
// identite4.AfficherV4(pIdefix);

let pRintintin = new Animal3('Rintintin');
let identite4 = new Identite<Animal3>(); // structure différente
identite4.AfficherV4(pRintintin);