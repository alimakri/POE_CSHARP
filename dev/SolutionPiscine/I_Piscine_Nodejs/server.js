'use strict';
var http = require('http');
var port = process.env.PORT || 1337;

http.createServer(function (req, res) {
    res.writeHead(200, { 'Content-Type': 'text/plain' });
    res.end('Hello World\n');
}).listen(port);


// Etape 1 : Définir une liste d'objets json : (CENTRE NAUTIQUE DE SCHILTIGHEIM - /401_SPO_2/centre-nautique-de-schiltigheim), (PISCINE DE HAUTEPIERRE  - /402_SPO_3/piscine-de-hautepierre)

// Avec le lien, retrouver l'adresse de la piscine. Verbe GET
