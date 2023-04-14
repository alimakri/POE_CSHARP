using E_Builder;

var borne = new BorneDeVente();

var reineBuilder = new ReineBuilder("Reine");
borne.PreparerPizza(reineBuilder);
Console.WriteLine(reineBuilder.Pizza);

var chevreMiel = new ChevreMielBuilder("ChevreMiel");
borne.PreparerPizza(chevreMiel);
Console.WriteLine(chevreMiel.Pizza);


