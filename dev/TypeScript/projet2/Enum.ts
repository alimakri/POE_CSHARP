enum Boussole{
    Nord=1,
    Sud=2,
    Est=4,
    Ouest=8,
    SudOuest = Sud+Ouest
}
let direction:Boussole = Boussole.SudOuest;
console.log('valeur de ', Boussole[10], '=', direction);
