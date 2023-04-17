using B_Factory_Method;

var a = new Patient();
var b = new Patient { NumeroMutuelle = "0036565165165161" };
var c = new Patient { NumeroMutuelle = "0056565165165161" };

var factory = new MutuelleFactory();
Mutuelle mA = factory.GetMutuelle(a);
Mutuelle mB = factory.GetMutuelle(b);
Mutuelle mC = factory.GetMutuelle(c);

Console.WriteLine(mA.GetPourcentRbtMedecinTraitant());
Console.WriteLine(mB.GetPourcentRbtMedecinTraitant());
Console.WriteLine(mC.GetPourcentRbtMedecinTraitant());
