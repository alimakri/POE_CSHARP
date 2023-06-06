System.register(["./module"], function (exports_1, context_1) {
    "use strict";
    var module_1, lm, psy;
    var __moduleName = context_1 && context_1.id;
    return {
        setters: [
            function (module_1_1) {
                module_1 = module_1_1;
            }
        ],
        execute: function () {
            lm = new module_1.Livre('les misérables', 'Victor Hugo');
            psy = new module_1.Magazine('Psycho mag', 12.50);
            console.log(lm);
            console.log(psy);
        }
    };
});
