using D_Exo1;

Directeur albert = new Directeur(1.2M);
var alfred = new Employe(1);
ISalarie aymeric = new ChefdeProjet();

var salaire1 = albert.GetSalaire();
var salaire2 = alfred.GetSalaire();
var salaire3= aymeric.GetSalaire();

Console.WriteLine(salaire1);
Console.WriteLine(salaire2);
Console.WriteLine(salaire3);
