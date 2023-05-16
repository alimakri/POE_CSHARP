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
const regex = /Coordonn\u00E9es[^>]*[>][\n\r\t ]*[^>]*[>][\n\r\t ]*[^>]*[>][\n\r\t ]*([^<]*)[^>]*[>]*[>][\n\r\t ]*([0-9a-zA-Z ]*)[\n\r\t ]*[^>]*[>][\n\r\t ]*[^>]*[>][\n\r\t ]*T\u00E9l\u00E9phone : ([0-9+() ]*)/gm;

// Etape 2 : partant du nom de la piscine se connecter à sa page.
var express = require('express');
var app = express();
var https = require("https");

app.get('/:nomPiscine', function (req, response) {
    // retrouver l'url dans liens
    var urlItem;
    liens.forEach(function (item) {
        if (item.Piscine == req.params.nomPiscine) urlItem = item.url;
    });
    var url = urlDetailPiscine + urlItem;
    console.log('Connexion à ' + url);

    // Récupérer le html de url
    https.get(url, (res) => {
        let codeHtml = '';
        res.on('data', (chunk) => { codeHtml += chunk; });
        res.on('end', () => {
            try {
                // regex
                var json = processRegex(codeHtml);
                console.log(JSON.stringify(json));
                // retour en json : {"adresse1":"....", "adresse2":"....", "telephone":"...."}
                return response.end(JSON.stringify(json));
            } catch (e) {
                console.error('ERREUR:' + e.message);
            }
        });
    });

});

function processRegex(codeHtml) {
    // Extraire avec un regex l'adresse de la piscine dans codeHtml
    //var matches = codeHtml.match(regex);
    var matches = regex.exec(codeHtml);
    var adresse1 = matches[1];
    var adresse2 = matches[2];
    var telephone = matches[3];

    return { "adresse1": adresse1, "adresse2": adresse2, "telephone": telephone };
}

var server = app.listen(8081, function () {
    var host = server.address().address;
    var port = server.address().port;
    console.log("accès au serveur http://" + host + ":" + port);
})
// Etape 3 : dans l'application WPF faire appel à ce service