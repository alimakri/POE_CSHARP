var Auto = /** @class */ (function () {
    function Auto() {
        this.hybride = false;
        this.nombreRoues = 4;
    }
    Auto.prototype.rouler = function () {
    };
    Auto.prototype.freiner = function () {
    };
    return Auto;
}());
var auto1 = new Auto();
var auto2 = {
    'nombreRoues': 4,
    'rouler': function () { },
    'freiner': function () { },
    'hybride': true
};
var marques = ['Honda', 'Peugeot', 'Toyota'];
console.log(marques[2]);
