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