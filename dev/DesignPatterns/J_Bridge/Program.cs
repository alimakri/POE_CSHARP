using J_Bridge;
var reducFaible = new ReductionFaible();
var reducForte = new ReductionForte();

var aStandard = new AbonnementStandard(reducFaible);
var prix = aStandard.GetPrice();
Console.WriteLine(prix);