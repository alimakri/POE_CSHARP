"use strict";
var Boussole;
(function (Boussole) {
    Boussole[Boussole["Nord"] = 1] = "Nord";
    Boussole[Boussole["Sud"] = 2] = "Sud";
    Boussole[Boussole["Est"] = 4] = "Est";
    Boussole[Boussole["Ouest"] = 8] = "Ouest";
    Boussole[Boussole["SudOuest"] = 10] = "SudOuest";
})(Boussole || (Boussole = {}));
let direction = Boussole.SudOuest;
console.log('valeur de ', Boussole[10], '=', direction);
