using F_Prototype;

var personne = new Personne("Ali");
Console.WriteLine("Nom de la personne : {0}", personne.Nom);

var chien = new Chien("Milou", personne);
Console.WriteLine("Nom du chien : {0}", chien.Nom);
Console.WriteLine("Nom du propriétaire : {0}", chien.Proprietaire.Nom);

var chienClone = (Chien)chien.Clone(true);
chienClone.Proprietaire.Nom = "Nadia";
Console.WriteLine("Nom du chien cloné : {0}", chienClone.Nom);
Console.WriteLine("Nom du propriétaire : {0}", chienClone.Proprietaire.Nom);

Console.WriteLine(Object.ReferenceEquals(personne, chienClone.Proprietaire));