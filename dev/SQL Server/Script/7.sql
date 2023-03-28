SELECT Production.Product.Name, Production.ProductCategory.Name AS Categorie, Production.ProductSubcategory.Name AS SousCategorie
FROM     Production.Product RIGHT OUTER JOIN
                  Production.ProductSubcategory ON Production.Product.ProductSubcategoryID = Production.ProductSubcategory.ProductSubcategoryID RIGHT OUTER JOIN
                  Production.ProductCategory ON Production.ProductSubcategory.ProductCategoryID = Production.ProductCategory.ProductCategoryID/****** Script for SelectTopNRows command from SSMS  ******/


Personne left outer join Ville
Personne inner join Ville
Personne right outer join Ville