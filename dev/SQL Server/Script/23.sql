DECLARE @xml xml
SET @xml = '
	<personnes>
		<personne id="1">
			<nom>Zola</nom>
			<prenom>Emile</prenom>
		</personne>
		<personne id="2">
			<nom>Hugo</nom>
			<prenom>Victor</prenom>
		</personne>
	</personnes>'
SELECT  
	T.N.value('@id[1]', 'int') id,  
	T.N.value('nom[1]', 'nvarchar(50)') nom,  
	T.N.value('prenom[1]', 'nvarchar(50)') prenom 
FROM   
	@xml.nodes('/personnes/personne') T(N)