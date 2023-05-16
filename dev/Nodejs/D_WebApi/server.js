// https://www.tutorialspoint.com/nodejs/nodejs_restful_api.htm


// npm install express
var express = require('express');
var app = express();
var fs = require('fs')

var p = { "id": 4, "nom": "Carla", "age": 30 };

// Liste des personnes (GET)
// http://localhost:8081/listUsers 
app.get('/listUsers', function (req, res) {
    var data = fs.readFileSync('personnes.json');
    return res.end(data);
});

// POST : ajouter personne
app.post('/addUser', function (req, res) {
    var data = fs.readFileSync('personnes.json');
    var json = JSON.parse(data);
    json.push(p);
    return res.end(JSON.stringify(json));
});

// GET : sélectionner une personne avec id
app.get('/:id', function (req, res) {
    var data = fs.readFileSync('personnes.json');
    var json = JSON.parse(data);
    console.log('infos concernant ' + json[req.params.id - 1].nom);
    var user = json[req.params.id - 1];
    res.setHeader('Content-Type', 'application/json;charset:UTF8')
    return res.end(JSON.stringify(user));
});

// DELETE : supprimer une personne
app.delete('/deleteUser/:id', function (req, res) {
    var data = fs.readFileSync('personnes.json');
    var json = JSON.parse(data);
    var user = json[req.params.id - 1];
    delete json[user.id-1];
    return res.end(JSON.stringify(json));
});


// Affichage dans server
var server = app.listen(8081, function () {
    var host = server.address().address;
    var port = server.address().port;
    console.log("accès au serveur http://" + host + ":" + port);
})