var fs = require('fs');

// Vesion 1 : Lecture en mode synchrone
// var data = fs.readFileSync('input.txt');
// console.log(data.toString());


// Version 2 :Lecture en mode asynchrone
var data = fs.readFile('input.txt', function (err, data) {
    if (err) return console.error(err);
    console.log(data.toString());
});

console.log("program ended");