use AdventureWorks2017
GO
ALTER PROCEDURE ListeProduit(@couleur nvarchar(15)=null, @ref char(2)=null)
AS
	select ProductID, ProductNumber, Color, ListPrice 
	from Production.Product 
	where 
		(@couleur is null or Color=@couleur)
		and
		(@ref is null or ProductNumber like @ref + '%')
GO

Exec ListeProduit '<choix couleur="Red"><reference>BK</reference></choix>'
-- select * from Production.Product
