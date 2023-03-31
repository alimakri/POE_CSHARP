-- CA par année
select SUM(orderQty * UnitPrice) CA, YEAR(OrderDate) Annee
from 
	Sales.SalesOrderDetail d 
	inner join Sales.SalesOrderHeader h on h.SalesOrderID = d.SalesOrderID
group by
	YEAR(OrderDate)
Order by Annee

-- Liste des vendeurs (nom, prenom, ville)
select p.LastName, p.FirstName, a.City
from 
	Sales.SalesPerson sp
	inner join Person.Person p on p.BusinessEntityID = sp.BusinessEntityID
	inner join Person.BusinessEntityAddress ba on ba.BusinessEntityID = sp.BusinessEntityID
	inner join Person.Address a on a.AddressID = ba.AddressID
order by p.LastName, p.FirstName

-- Produit le plus vendu (qté) sur internet
select TOP 1
	d.ProductID, p.Name produit, SUM(d.OrderQty) Qte
from 
	Sales.SalesOrderDetail d
	inner join Sales.SalesOrderHeader h on d.SalesOrderID=h.SalesOrderID
	inner join Production.Product p on d.ProductID=p.ProductID
where
	h.SalesPersonID IS NULL
Group by
	d.ProductID, p.Name
Order by 
	Qte desc

-- Liste des employés par magasin
select s.Name magasin, p.LastName + ' ' + p.FirstName Nom
from Sales.Store s 
inner join Person.Person p on s.SalesPersonID = p.BusinessEntityID 
order by Nom

-- Liste des no de commandes de la meilleure catégorie
SELECT  h.SalesOrderNumber
 FROM Sales.SalesOrderDetail d
 INNER JOIN Sales.SalesOrderHeader h ON h.SalesOrderID = d.SalesOrderID
 INNER JOIN PRODUCTION.Product p on p.ProductID = d.ProductID
 INNER JOIN Production.ProductSubcategory s ON s.ProductSubcategoryID = p.ProductSubcategoryID
 INNER JOIN Production.ProductCategory c ON c.ProductCategoryID = s.ProductCategoryID
 WHERE c.ProductCategoryID IN
 (
  SELECT TOP 1 c.ProductCategoryID
  FROM Sales.SalesOrderDetail d
 inner join PRODUCTION.Product p on p.ProductID = d.ProductID
 INNER JOIN Production.ProductSubcategory s ON s.ProductSubcategoryID = p.ProductSubcategoryID
 INNER JOIN Production.ProductCategory c ON c.ProductCategoryID = s.ProductCategoryID
 GROUP BY c.ProductCategoryID
 ORDER BY SUM(OrderQty * UnitPrice) DESC
 )
 -- Version Temp
  SELECT TOP 1 c.ProductCategoryID categorie, SUM(OrderQty * UnitPrice) CA
  INTO #tab_tempo
  FROM Sales.SalesOrderDetail d
  inner join PRODUCTION.Product p on p.ProductID = d.ProductID
  INNER JOIN Production.ProductSubcategory s ON s.ProductSubcategoryID = p.ProductSubcategoryID
  INNER JOIN Production.ProductCategory c ON c.ProductCategoryID = s.ProductCategoryID
  GROUP BY c.ProductCategoryID  
  ORDER BY SUM(OrderQty * UnitPrice) DESC

 

  SELECT  h.SalesOrderNumber
 FROM Sales.SalesOrderDetail d
 INNER JOIN Sales.SalesOrderHeader h ON h.SalesOrderID = d.SalesOrderID
 INNER JOIN PRODUCTION.Product p on p.ProductID = d.ProductID
 INNER JOIN Production.ProductSubcategory s ON s.ProductSubcategoryID = p.ProductSubcategoryID
 INNER JOIN Production.ProductCategory c ON c.ProductCategoryID = s.ProductCategoryID
 WHERE c.ProductCategoryID IN 
 (
  SELECT categorie
  FROM #tab_tempo
 )
-- Version CTE
 WITH t1 (categorie,CA)
as
(
Select top 1 pc.ProductCategoryID categorie , SUM (OrderQty * UnitPrice) CA
FROM Sales.SalesOrderDetail sod
INNER JOIN Production.Product p on p.ProductID = sod.ProductID
INNER JOIN Production.ProductSubcategory ps on ps.ProductSubcategoryID = p.ProductSubcategoryID
INNER JOIN Production.ProductCategory pc on pc.ProductCategoryID = ps.ProductCategoryID
GROUP BY pc.ProductCategoryID
ORDER BY SUM (OrderQty * UnitPrice)  desc
)
select h.SalesOrderNumber
from Sales.SalesOrderDetail sod
INNER JOIN Sales.SalesOrderHeader h on h.SalesOrderID  = sod.SalesOrderID
INNER JOIN Production.Product p on p.ProductID = sod.ProductID
Inner join Production.ProductSubcategory ps on ps.ProductSubcategoryID = p.ProductSubcategoryID
inner join Production.ProductCategory pc on pc.ProductCategoryID = ps.ProductCategoryID
WHERE pc.ProductCategoryID in
(
Select categorie
FROM t1
)