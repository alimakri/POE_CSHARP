use AdventureWorks2017
GO
ALTER PROCEDURE ListeProduitXML(@data xml)
AS
	DECLARE @couleur nvarchar(50)
	DECLARE @ref nvarchar(50)
	SELECT  
		T.N.value('@couleur', 'nvarchar(50)') couleur,  
		T.N.value('@reference', 'nvarchar(50)') ref 
	INTO #t
	FROM   
		@data.nodes('//Listechoix/choix') T(N)

	select ProductID, ProductNumber, Color, ListPrice 
	from Production.Product 
		inner join #t on Color=Couleur and LEFT(ProductNumber, 2)=ref
GO

Exec ListeProduitXML '
	<Listechoix>
		<choix couleur="black" reference="BK"/>
		<choix couleur="black" reference="FR"/>
	</Listechoix>'
-- select * from Production.Product
