var __extends = (this && this.__extends) || (function () {
    var extendStatics = function (d, b) {
        extendStatics = Object.setPrototypeOf ||
            ({ __proto__: [] } instanceof Array && function (d, b) { d.__proto__ = b; }) ||
            function (d, b) { for (var p in b) if (Object.prototype.hasOwnProperty.call(b, p)) d[p] = b[p]; };
        return extendStatics(d, b);
    };
    return function (d, b) {
        if (typeof b !== "function" && b !== null)
            throw new TypeError("Class extends value " + String(b) + " is not a constructor or null");
        extendStatics(d, b);
        function __() { this.constructor = d; }
        d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
    };
})();
var Salarie = /** @class */ (function () {
    function Salarie(_nom, _salaire) {
        this._nom = _nom;
        this._salaire = _salaire;
        Salarie.n++;
    }
    Salarie.prototype.Salaire = function () { return this._salaire; };
    Salarie.n = 0;
    return Salarie;
}());
var Dev = /** @class */ (function (_super) {
    __extends(Dev, _super);
    function Dev(nom, salaire, _prime) {
        var _this = _super.call(this, nom, salaire) || this;
        _this._prime = _prime;
        return _this;
    }
    Dev.prototype.Salaire = function () { return _super.prototype.Salaire.call(this) + this._prime; };
    return Dev;
}(Salarie));
var devCSharp = new Dev('Sophie', 3050, 750);
var devJava = new Dev('Aurélie', 2050, 250);
console.log(devCSharp.Salaire());
console.log('nombre de salariés : ', Salarie.n);
