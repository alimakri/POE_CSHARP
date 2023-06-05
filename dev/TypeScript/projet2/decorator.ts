export class Maison{
    private _nom:string;
    constructor(nom:string){this._nom=nom;}

    @deco1
    @deco2("Picasso")
    public Info():string{return this._nom;}
}
function deco1(target, prop){
    console.log("Pasasge par deco1")
}
function deco2(param){
    return function(target, prop){
        console.log("Passage par deco2 :" + param);
    }
}