use BD3

SELECT * from Ville

--AJOUT, SUPPRESSION, MODIFICATION
ALTER PROC EditVille(@data xml)
AS
	SELECT
		N.value('@op[1]', 'nvarchar(50)') op,
		N.value('@cp[1]', 'nvarchar(50)') cp,
		N.value('@nom[1]', 'nvarchar(50)') nom
	INTO #t1
	FROM
		@data.nodes('/villes/ville') AS T(N)
		
	IF EXISTS(SELECT * from #t1 WHERE op='Suppression')
		DELETE Ville WHERE CodePostal IN(
			SELECT cp
			FROM #t1
			WHERE op='Suppression')
	IF EXISTS(SELECT * from #t1 WHERE op='Ajout')
		INSERT Ville (CodePostal,Libelle) 
			SELECT cp,nom	
			FROM #t1
			WHERE op = 'Ajout'
	IF EXISTS(SELECT * from #t1 WHERE op='Modif')
		UPDATE Ville SET Libelle= #t1.nom
			FROM #t1 
			INNER JOIN Ville v ON #t1.cp = v.CodePostal and #t1.op = 'Modif'
GO
EXEC EditVille
'
<villes>
	<ville op="Ajout" cp ="33000" nom ="Bordeaux"/>
	<ville op="Suppression" cp ="75002"/>
	<ville op="Modif" cp ="75003" nom = "Paris4"/>
</villes>
'


SELECT * INTO #t2 FROM Ville 
SELECT * from #t2
SELECT * From Ville
--AJOUT, SUPPRESSION, MODIFICATION
ALTER PROC EditMusicien(@data xml)
AS
	SELECT
		N.value('@op[1]', 'nvarchar(50)') op,
		N.value('@id[1]', 'uniqueidentifier') id,
		N.value('@nom[1]', 'nvarchar(50)') nom,
		N.value('@age[1]', 'bigint') age
	INTO #t1
	FROM
		@data.nodes('/musiciens/musicien') AS T(N)
		
	IF EXISTS(SELECT * from #t1 WHERE op='Suppression')
		DELETE Musicien WHERE id IN(
			SELECT id
			FROM #t1
			WHERE op='Suppression')
	IF EXISTS(SELECT * from #t1 WHERE op='Ajout')
		INSERT Musicien(Nom,age) 
			SELECT nom,age	
			FROM #t1
			WHERE op = 'Ajout'
	IF EXISTS(SELECT * from #t1 WHERE op='Modif')
		UPDATE Musicien 
			SET 
				Nom = #t1.nom,
				Age = #t1.age
			FROM #t1 
			INNER JOIN Musicien m ON #t1.id = m.id and #t1.op = 'Modif'
GO
EXEC EditMusicien
'
<musiciens>
	<musicien op="Ajout" nom ="Taric" age="26"/>
	<musicien op="Suppression" id="767EEA88-85DF-4E81-89BD-DB0B7B7DEFC3"/>
	<musicien op="Modif" id="767EEA88-85DF-4E81-89BD-DB0B7B7DEFC3" nom ="Mary" age = "48"/>
</musiciens>
'

delete Pret Where Musicien = '767EEA88-85DF-4E81-89BD-DB0B7B7DEFC3'