use AdventureWorks2017
go
-- 295 --504
SELECT 
	p.ProductID Id, 
	p.Name produit, 
	s.Name SousCat, 
	c.Name Cat
FROM     
	Production.Product p 
	LEFT OUTER JOIN Production.ProductSubcategory s ON p.ProductSubcategoryID = s.ProductSubcategoryID 
	LEFT OUTER JOIN Production.ProductCategory c ON s.ProductCategoryID = c.ProductCategoryID

