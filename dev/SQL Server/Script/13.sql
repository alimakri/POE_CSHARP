use AdventureWorks2017
SELECT p.ProductID ID, p.Name Nom, c.Name
INTO #t
FROM Production.Product p
INNER JOIN Production.ProductSubcategory s on p.ProductSubcategoryID = s.ProductSubcategoryID
INNER JOIN Production.ProductCategory c on c.ProductCategoryID = s.ProductCategoryID
WHERE (c.Name = 'Bikes')

Select * from #t

SELECT *
FROM Sales.SalesOrderDetail sod
WHERE ProductID IN
(
	SELECT ID from #t1
)

-- avec cte

WITH t1(ID, Nom)
AS
(
	SELECT p.ProductID ID, p.Name Nom
	FROM Production.Product p
	INNER JOIN Production.ProductSubcategory s on p.ProductSubcategoryID = s.ProductSubcategoryID
	INNER JOIN Production.ProductCategory c on c.ProductCategoryID = s.ProductCategoryID
	WHERE (c.Name = 'Bikes')
)
SELECT *
FROM Sales.SalesOrderDetail sod
WHERE ProductID IN
(
SELECT ID from t1
)

SELECT * from t1

drop table #TopVendeur

select top 3 p.BusinessEntityID, SUM(OrderQty * UnitPrice) CA
INTO #TopVendeur
from Sales.SalesOrderDetail d
inner join Sales.SalesOrderHeader h on d.SalesOrderID = h.SalesOrderID
inner join Person.Person p on h.SalesPersonID = p.BusinessEntityID
GROUP BY p.BusinessEntityID
ORDER BY SUM(OrderQty * UnitPrice) desc


SELECT * 
from Sales.SalesPerson 
where BusinessEntityID in 
( 
	select BusinessEntityID 
	from #TopVendeur
)

WITH TopVendeur(ID)
AS
(
	select TOP 3 p.BusinessEntityID
	from Sales.SalesOrderDetail d
	inner join Sales.SalesOrderHeader h on d.SalesOrderID = h.SalesOrderID
	inner join Person.Person p on h.SalesPersonID = p.BusinessEntityID
	GROUP BY p.BusinessEntityID
	ORDER BY SUM(OrderQty * UnitPrice) desc
)
SELECT *
FROM Sales.SalesPerson p
WHERE BusinessEntityID IN
(
	SELECT ID from TopVendeur
)

-- Moyenne de produits vendus par les vendeurs

WITH PrdVendeur(SalesPersonID, NumberOfOrders)
AS
(
	SELECT SalesPersonID, COUNT(*)
	FROM Sales.SalesOrderHeader
	WHERE SalesPersonID IS NOT NULL
	GROUP BY SalesPersonID
)
SELECT AVG(NumberOfOrders) AS "Moyenne de ventes des vendeurs"
FROM PrdVendeur

-- Moyenne de vente des produits
--> Sales.SalesOrderDetail -> ProductID

WITH AvgProduit(IdProduit, NumberOfOrders)
AS
(
	SELECT ProductID, SUM(OrderQty)
	FROM Sales.SalesOrderDetail
	GROUP BY ProductID
)
/*
SELECT p.Name, NumberOfOrders
FROM AvgProduit a
INNER JOIN Production.Product p on a.IdProduit = p.ProductID
*/
SELECT AVG(NumberOfOrders) AS "Moyenne de ventes des produits"
FROM AvgProduit

