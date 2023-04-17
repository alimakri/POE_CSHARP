using O_Exo5;

var becassine = new Personne();
var becassineP2 = new Personne();
var becassineP2P2 = new Personne();
var alain = new Personne();

var josephine = new Personne();
var josephineP1 = new Personne();

// ------------------------------------------------------
becassine.Parent2 = becassineP2;
becassineP2.Parent2 = becassineP2P2;
josephine.Parent1 = josephineP1;
josephineP1.Parent1 = becassineP2P2;
alain.Parent1 = josephineP1;
// ------------------------------------------------------

Console.WriteLine( Genealogie.SontCousins(becassine, josephine));