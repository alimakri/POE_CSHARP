class Revue{
    private editeur:string;
    private prix:number;
    constructor(editeur:string, prix:number){this.editeur=editeur; this.prix=prix;}
}
export{Revue as Magazine}
export class Livre{
    private titre:string;
    private auteur:string;
    constructor(titre:string, auteur:string){this.titre=titre; this.auteur=auteur;}
}