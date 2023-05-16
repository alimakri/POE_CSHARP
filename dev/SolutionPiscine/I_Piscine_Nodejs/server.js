'use strict';
// npm install express

// http://localhost:8081/Piscine%20de%20Hautepierre

var urlDetailPiscine = 'https://www.strasbourg.eu/lieu/-/entity/sig';
// Etape 1 : Définir une liste d'objets json : (CENTRE NAUTIQUE DE SCHILTIGHEIM - /401_SPO_2/centre-nautique-de-schiltigheim), (PISCINE DE HAUTEPIERRE  - /402_SPO_3/piscine-de-hautepierre)
var liens =
    [
        { "Piscine": "Centre nautique de Schiltigheim", "url": "/401_SPO_2/centre-nautique-de-schiltigheim" },
        { "Piscine": "Piscine de Hautepierre", "url": "/402_SPO_3/piscine-de-hautepierre" },
        { "Piscine": "Piscine de la Hardt", "url": "/403_SPO_4/piscine-de-la-hardt" },
        { "Piscine": "Piscine de la Kibitzenau", "url": "/404_SPO_5/piscine-de-la-kibitzenau" },
        { "Piscine": "Piscine de la Roberstau", "url": "/405_SPO_6/piscine-de-la-robertsau" },
        { "Piscine": "Piscine de Lingolsheim", "url": "/406_SPO_7/piscine-de-lingolsheim" },
        { "Piscine": "Piscine d'Ostwald", "url": "/407_SPO_8/piscine-d-ostwald" },
        { "Piscine": "Piscine du Wacken", "url": "/408_SPO_9/piscine-du-wacken" },
        { "Piscine": "Bains municipaux de Strasbourg", "url": "/400_SPO_1/bains-municipaux-de-strasbourg" }];

// Etape 2 : partant du nom de la piscine se connecter à sa page.
var express = require('express');
var app = express();

app.get('/:nomPiscine', function (req, res) {
    var url = urlDetailPiscine + liens[req.params.nomPiscine].url;
    console.log(url);

    // Récupérer le html de url
});

var server = app.listen(8081, function () {
    var host = server.address().address;
    var port = server.address().port;
    console.log("accès au serveur http://" + host + ":" + port);
})
// Etape 3 : dans l'application WPF faire appel à ce service