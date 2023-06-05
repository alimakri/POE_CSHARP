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
var Personne = /** @class */ (function () {
    function Personne(a) {
        this.name = a;
    }
    Personne.prototype.direBonjour = function () {
        console.log("bonjour je m'appelle " + this.name);
    };
    return Personne;
}());
var p;
p = new Personne("Robert");
p.direBonjour();
var MammifereV1 = /** @class */ (function () {
    function MammifereV1(name) {
        this.name = name;
    }
    return MammifereV1;
}());
var dauphin = new MammifereV1('Dauphin');
// identique à MammifereV1
var MammifereV2 = /** @class */ (function () {
    function MammifereV2(name) {
        this.name = name;
    }
    return MammifereV2;
}());
var baleine = new MammifereV2('Baleine');
// identique à MammifereV1 sauf que name est private
var MammifereV3 = /** @class */ (function () {
    function MammifereV3(_name) {
        this._name = _name;
    }
    Object.defineProperty(MammifereV3.prototype, "name", {
        get: function () { return this._name; },
        enumerable: false,
        configurable: true
    });
    return MammifereV3;
}());
var orque = new MammifereV3('Orque');
console.log(orque.name);
// version avec héritage
var Animal = /** @class */ (function () {
    function Animal() {
    }
    return Animal;
}());
var MammifereV4 = /** @class */ (function (_super) {
    __extends(MammifereV4, _super);
    function MammifereV4(name) {
        var _this = _super.call(this) || this;
        _this.isMammifere = true;
        _this.name = name;
        return _this;
    }
    return MammifereV4;
}(Animal));
var lamentin = new MammifereV4('Lamentin');
