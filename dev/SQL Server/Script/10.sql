use AdventureWorks2017
select top 3 p.BusinessEntityID, SUM(OrderQty * UnitPrice) CA
INTO ##TopVendeur
from Sales.SalesOrderDetail d
inner join Sales.SalesOrderHeader h on d.SalesOrderID = h.SalesOrderID
inner join Person.Person p on h.SalesPersonID = p.BusinessEntityID
GROUP BY p.BusinessEntityID
ORDER BY SUM(OrderQty * UnitPrice) desc

SELECT * FROM ##TopVendeur

INSERT INTO Personnes values ('Michel','Blanc')

select * from Personnes

CREATE PROC AjoutPersonne(@data xml)
AS
	SELECT 
		N.value('prenom[1]', 'nvarchar(50)'),
		N.value('nom[1]', 'nvarchar(50)')
	FROM
		@data.nodes('/personnes/personne') AS T(N)
GO

Exec AjoutPersonne
	'<personnes>
		<personne>
			<prenom>Jacques</prenom>
			<nom>Bernard</nom>
			<age>56</age>
		</personne>
		<personne>
			<prenom>Blandine</prenom>
			<nom>Bois</nom>
		</personne>
		<maison>
			<adresse>56 rue du Chêne</adresse>
		</maison>
	</personnes>'

ALTER PROC AjoutVille(@data xml)
AS
	SELECT 
		N.value('id[1]', 'bigInt') CodePostal,
		N.value('nom[1]', 'nvarchar(50)') Libelle
	INTO #t1
	FROM
		@data.nodes('/villes/ville') AS T(N)

	SELECT * from #t1
GO

Exec AjoutVille
'<villes>
	<ville>
		<id>86500</id>
		<nom>Valmy</nom>
	</ville>
	<ville>
		<id>31400</id>
		<nom>Toulouse</nom>
	</ville>
	<ville>
		<id>69600</id>
		<nom>Oullins</nom>
	</ville>
</villes>'
		
SELECT * from #t


