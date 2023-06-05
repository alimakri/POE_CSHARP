// Les types
// --------------------

function f(){
    var a = 2;
    if (true){
        let a=3;
    }
}
const a=3;
console.log(a);

let isDone: boolean = false;
let decimal: number=6;
let hello:string = "world";
let sayhello:string = `hello ${hello}`;
let desnombres: number[] = [1,2,3];
let desnombres2: Array<number> = [1,2,3];
let x:[string, number];
x=["hello", 10];
enum Couleur{Rouge, Vert, Bleu};
let c:Couleur = Couleur.Bleu;

let uneVariable: any =4;
uneVariable = "une valeur";

function doAlert():void{
    alert("une alerte");
}

let chaine: any = "Ceci est une chaine";
let taille1 :number = (<string>chaine).length;
taille1 = (chaine as string).length;
