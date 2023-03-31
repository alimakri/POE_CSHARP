use AdventureWorks2017

ALTER PROC ListeProduits(@couleur nvarchar(15)=null, @seuil money=null, @type char(2)=null)
AS
	SELECT *
	FROM
		Production.Product
	WHERE
		(@couleur is NULL or Color = @couleur)
		and
		(@seuil is NULL or ListPrice > @seuil)
		and
		(@type is NULL or LEFT (ProductNumber, 2) = @type)
GO

EXEC ListeProduits
EXEC ListeProduits 'Black'
EXEC ListeProduits 'Black', 100
EXEC ListeProduits 'Black', 100, 'BK'
EXEC ListeProduits @seuil=100, @couleur='Red'
SELECT * FROM Production.Product order By ProductNumber


ALTER PROC ListeProduitsXML(@data xml)
AS
	DECLARE @couleur nvarchar(15)
	DECLARE @seuil money
	DECLARE @type char(2)
	/*******************************************/
	SELECT 
		@couleur = N.value('@couleur[1]', 'nvarchar(15)'),
		@seuil = N.value('@seuil[1]', 'money'),
		@type = N.value('type[1]', 'char(2)')
	FROM
		@data.nodes('/produit') AS T(N)
	/******************************************/
	SELECT *
	FROM
		Production.Product
	WHERE
		(@couleur is NULL or Color = @couleur)
		and
		(@seuil is NULL or ListPrice > @seuil)
		and
		(@type is NULL or LEFT (ProductNumber, 2) = @type)
GO

EXEC ListeProduitsXML 
'<produit couleur="Red" seuil="3000">
	<type>BK</type>
</produit>'

/*************************************************/
--On veut récupérer la liste des Personnes en fonction de données XML
-- 1) Créer une procédure stockée qui affiche la liste des personnes
ALTER PROC ListePersonne
AS
	SELECT *
	FROM Person.Person
GO

EXEC ListePersonne
-- 2) Ajouter des paramètres (prenom, type)
ALTER PROC ListePersonne(@prenom nvarchar(50) = null, @type char(2) = null)
AS
	SELECT *
	FROM 
		Person.Person
	WHERE
		(@prenom is NULL or FirstName = @prenom)
		and
		(@type is NULL or PersonType = @type)
GO

EXEC ListePersonne 
-- 3) Avec du XML
ALTER PROC ListePersonneXML(@data xml)
AS
	DECLARE @prenom nvarchar(50)
	DECLARE @type char(2)
	/*******************************/
	SELECT
		@prenom = N.value('@prenom[1]', 'nvarchar(50)'),
		@type = N.value('type[1]','char(2)')
	FROM
		@data.nodes('/personne') AS T(N)
	/***********************************/
	SELECT *
	FROM
		Person.Person
	WHERE
		(@prenom is NULL or FirstName = @prenom)
		and
		(@type is NULL or PersonType = @type)
GO

EXEC ListePersonneXML
'<personne prenom="Ken">
	<type>EM</type>
</personne>'

ALTER PROC ListePersonnesXML(@data xml)
AS 
	/*******************************/
	SELECT
		N.value('@prenom[1]', 'nvarchar(50)') prenom,
		N.value('type[1]','char(2)') PersonType
	INTO #t1
	FROM
		@data.nodes('/personnes/personne') AS T(N)
	/***********************************/
	--SELECT * from #t1
	SELECT *
	FROM
		Person.Person p
	INNER JOIN
		#t1 on (p.FirstName = #t1.prenom) and (#t1.PersonType is null or #t1.PersonType = p.PersonType)
GO

EXEC ListePersonnesXML
'<personnes> 
	<personne prenom="Ken"/>
	<personne prenom="Mary">
		<type>EM</type>
	</personne>
</personnes>'

Select p.Name Produit, s.Name SousCat, c.Name Cat
FROM Production.Product p
inner join Production.ProductSubCategory s on p.ProductSubcategoryID = s.ProductSubcategoryID
inner join Production.ProductCategory c on s.ProductCategoryID = c.ProductCategoryID
--Afficher tous les produits
ALTER PROC ListeCat
AS
	SELECT p.Name Produit, s.Name SousCat, c.Name Cat
	FROM Production.Product p
	inner join Production.ProductSubCategory s on p.ProductSubcategoryID = s.ProductSubcategoryID
	inner join Production.ProductCategory c on s.ProductCategoryID = c.ProductCategoryID
GO

EXEC ListeCat 
--Filtre avec des paramètres
ALTER PROC ListeCat(@cat varchar(20) = null, @sousCat varchar(20) = null)
AS
	SELECT p.Name Produit, s.Name SousCat, c.Name Cat
	FROM Production.Product p
		inner join Production.ProductSubCategory s on p.ProductSubcategoryID = s.ProductSubcategoryID
		inner join Production.ProductCategory c on s.ProductCategoryID = c.ProductCategoryID
	WHERE
		(@cat is NULL or c.Name = @cat)
		and
		(@sousCat is NULL or s.Name = @sousCat)
GO
EXEC ListeCat @sousCat = 'Caps'

--Filtre avec XML
ALTER PROC ListeCat(@data xml)
AS
	DECLARE
		@cat varchar(20),
		@sousCat varchar(20)
	/******************************************/
	SELECT
		@cat = N.value('categorie[1]', 'varchar(20)'),
		@sousCat = N.value('sous-categorie[1]','varchar(20)')
	FROM
		@data.nodes('/produit') AS T(N)

	/***********************************************/
	SELECT p.Name Produit, s.Name SousCat, c.Name Cat
	FROM Production.Product p
		inner join Production.ProductSubCategory s on p.ProductSubcategoryID = s.ProductSubcategoryID
		inner join Production.ProductCategory c on s.ProductCategoryID = c.ProductCategoryID
	WHERE
		(@cat is NULL or c.Name = @cat)
		and
		(@sousCat is NULL or s.Name = @sousCat)
GO
EXEC ListeCat
'<produit>
		<sous-categorie>Caps</sous-categorie>
</produit>'

--Plusieurs filtre avec XML

ALTER PROC ListeCat(@data xml)
AS
	SELECT
		N.value('categorie[1]', 'varchar(20)') Cat,
		N.value('sous-categorie[1]','varchar(20)') SousCat
	INTO #t1
	FROM
		@data.nodes('/produits/produit') AS T(N)
	/***********************************************/
	SELECT p.Name Produit, s.Name SousCat, c.Name Cat
	FROM Production.Product p
		inner join Production.ProductSubCategory s on p.ProductSubcategoryID = s.ProductSubcategoryID
		inner join Production.ProductCategory c on s.ProductCategoryID = c.ProductCategoryID
	INNER JOIN #t1 on (#t1.SousCat is NULL or s.Name = #t1.SousCat) and (#t1.Cat is NULL or c.Name = #t1.Cat)
GO
EXEC ListeCat
'<produits>
	<produit>
		<categorie>Components</categorie>
		<sous-categorie>Road Frames</sous-categorie>
	</produit>
	<produit>
		<categorie>Bikes</categorie>
	</produit>
</produits>'

