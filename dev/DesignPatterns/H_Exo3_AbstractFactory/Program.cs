using H_Exo3_AbstractFactory;

var guepard = new Animal();
var aigleRoyal = new Animal { AvecAiles = true };

IAnimalFactory GetFactory(Animal a)
{
    if (a.AvecAiles) return new AnimalAvecAilesFactory();
    return new AnimalSansAilesFactory();
}

IAnimalFactory factoryGuepard = GetFactory(guepard);
IAnimalFactory factoryAigle = GetFactory(aigleRoyal);

var vitesseGuepard = new VitesseAnimal(factoryGuepard);
var vitessAigle = new VitesseAnimal(factoryAigle);

Console.WriteLine("Guepard");
vitesseGuepard.SeDeplacer();

Console.WriteLine("Aigle");
vitessAigle.SeDeplacer();