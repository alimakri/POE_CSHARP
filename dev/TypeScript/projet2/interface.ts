interface IVehicule{
    nombreRoues:number;
    rouler():void;
    freiner():void;
    marque?:string;
    readonly hybride:boolean;
}
class Auto implements IVehicule{
    marque?: string;
    hybride: boolean=false;
    nombreRoues: number=4;
    rouler(): void {
        
    }
    freiner(): void {
        
    }
}
let auto1:IVehicule = new Auto();
let auto2:IVehicule = {
    'nombreRoues':4,
    'rouler':function(){},
    'freiner': function(){},
    'hybride':true
};

interface IListMarque{
    [index:number]:string;
}
let marques = ['Honda','Peugeot','Toyota'];
console.log(marques[2]);