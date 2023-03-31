use AdventureWorks2017
GO
ALTER PROCEDURE ListeProduitXML(@data xml)
AS
	DECLARE @couleur nvarchar(50)
	DECLARE @ref nvarchar(50)
	SELECT  
		@couleur = T.N.value('@couleur[1]', 'nvarchar(50)'),  
		@ref = T.N.value('reference[1]', 'nvarchar(50)')  
	FROM   
		@data.nodes('/choix') T(N)

	select ProductID, ProductNumber, Color, ListPrice 
	from Production.Product 
	where 
		(@couleur is null or Color=@couleur)
		and
		(@ref is null or ProductNumber like @ref + '%')
GO

Exec ListeProduitXML '<choix couleur="Black"><reference>FR</reference></choix>'
-- select * from Production.Product
