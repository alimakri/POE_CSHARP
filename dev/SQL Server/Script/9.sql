use BD3

select * 
from Pret,Musicien
where Pret.Musicien = Musicien.id and Nom = 'Jacques'

select * 
from Pret
inner join Musicien on Musicien.id = Pret.Musicien
where Nom = 'Jacques'

select *
from Personne
inner join Ville on Personne.Ville = Ville.CodePostal

select *
from Personne
left outer join Ville on Personne.Ville = Ville.CodePostal

select *
from Personne
right outer join Ville on Personne.Ville = Ville.CodePostal

select CodePostal, Libelle, COUNT(Personne.id) Nombre
from Personne
right outer join Ville on Personne.Ville = Ville.CodePostal
group by CodePostal, Libelle

use AdventureWorks2017

ALTER AUTHORIZATION ON DATABASE::AdventureWorks2017 TO [PITOU\alima];

select * from Person.Person
select * from Person.BusinessEntityAddress
select * from Person.Address

/* LastName, FirstName, City
Person -> BusinessEntityAddress : BusinessEntityID
BusinessEntityAddress -> Addres : AddressID
*/
select City, COUNT(p.BusinessEntityID) NbrPerson
from Person.Person p
left outer join Person.BusinessEntityAddress bea on bea.BusinessEntityID = p.BusinessEntityID
left outer join Person.Address a on bea.AddressID = a.AddressID
GROUP BY City
ORDER BY NbrPerson DESC

Select * from Production.Product
select * from Sales.SalesOrderDetail
Select * from Sales.SalesOrderHeader

/*Colonnes -> SalesOrderNumber, Name, OrderQty, UnitPrice
Tables :
Production.Product -> ProductID <- Sales.SalesOrderDetail
Sales.SalesOrderDetail -> SalesOrderID <-Sales.SalesOrderHeader
*/
SELECT Name, OrderQty, UnitPrice, SalesOrderNumber
FROM Production.Product p
LEFT JOIN Sales.SalesOrderDetail sod ON p.ProductID = sod.ProductID
LEFT JOIN Sales.SalesOrderHeader soh ON sod.SalesOrderID = soh.SalesOrderID
ORDER BY SalesOrderNumber

SELECT SUM(OrderQty * UnitPrice) CA, SalesOrderNumber
FROM Production.Product p
INNER JOIN Sales.SalesOrderDetail sod ON p.ProductID = sod.ProductID
INNER JOIN Sales.SalesOrderHeader soh ON sod.SalesOrderID = soh.SalesOrderID
GROUP BY SalesOrderNumber

SELECT SalesOrderNumber , SUM(OrderQty * UnitPrice) CA --5
FROM Production.Product p --1
INNER JOIN Sales.SalesOrderDetail sod ON p.ProductID = sod.ProductID
INNER JOIN Sales.SalesOrderHeader soh ON sod.SalesOrderID = soh.SalesOrderID
WHERE OrderQty > 1 --2
GROUP BY SalesOrderNumber -- 3
HAVING SUM(OrderQty * UnitPrice) > 100000 --4
ORDER BY CA DESC --6

SELECT SalesOrderNumber, OrderDate , SUM(OrderQty * UnitPrice) CA --5
FROM Production.Product p --1
INNER JOIN Sales.SalesOrderDetail sod ON p.ProductID = sod.ProductID
INNER JOIN Sales.SalesOrderHeader soh ON sod.SalesOrderID = soh.SalesOrderID
--WHERE OrderQty > 1 --2
GROUP BY OrderDate, SalesOrderNumber -- 3
HAVING SUM(OrderQty * UnitPrice) > 100000 --4
ORDER BY OrderDate DESC --6

--FirstName,LastName, CA 
-- Les vendeurs qui ont apportés plus de 1.000.000

--Person.Person
--		BusinessEntityID -> SalesPersonID
--Sales.SalesOrderHeader 
--		SalesOrderID -> SalesOrderID
--Sales.SalesOrderDetail

select p.FirstName, p.LastName, SUM(OrderQty * UnitPrice)
from Sales.SalesOrderDetail d
inner join Sales.SalesOrderHeader h on d.SalesOrderID = h.SalesOrderID
inner join Person.Person p on h.SalesPersonID = p.BusinessEntityID
GROUP BY p.FirstName, p.LastName
having SUM(OrderQty * UnitPrice) > 1000000
ORDER BY SUM(OrderQty * UnitPrice) desc

--CA par magasin (BusinessEntityID) et par année (YEAR(OrderDate))
SELECT BusinessEntityID, YEAR(OrderDate) Annee, SUM(OrderQty * UnitPrice) CA
FROM Sales.Store st
INNER JOIN Sales.SalesOrderHeader h ON st.SalesPersonID = h.SalesPersonID
INNER JOIN Sales.SalesOrderDetail o ON o.SalesOrderID = h.SalesOrderID
GROUP BY st.BusinessEntityID, YEAR(OrderDate)
ORDER BY st.BusinessEntityID, YEAR(OrderDate)
--BusinessEntityID, YEAR(OrderDate) Annee, SUM(OrderQty * UnitPrice) CA
--Sales.Store
--		SalesPersonID -> SalesPersonID
--Sales.SalesOrderHeader 
--		SalesOrderID -> SalesOrderID
--Sales.SalesOrderDetail

SELECT BusinessEntityID
FROM 
(
SELECT TOP 3 BusinessEntityID, SUM(OrderQty * UnitPrice) CA
FROM Sales.Store st
INNER JOIN Sales.SalesOrderHeader h ON st.SalesPersonID = h.SalesPersonID
INNER JOIN Sales.SalesOrderDetail o ON o.SalesOrderID = h.SalesOrderID
GROUP BY st.BusinessEntityID, YEAR(OrderDate)
ORDER BY CA DESC
)t

select SalesPersonID, SalesQuota
FROM Sales.SalesPerson s
INNER JOIN Sales.SalesOrderHeader h on s.BusinessEntityID = h.SalesPersonID
INNER JOIN Sales.SalesOrderDetail d on d.SalesOrderID = h.SalesOrderID
WHERE s.BusinessEntityID IN
(
select top 3 p.BusinessEntityID
from Sales.SalesOrderDetail d
inner join Sales.SalesOrderHeader h on d.SalesOrderID = h.SalesOrderID
inner join Person.Person p on h.SalesPersonID = p.BusinessEntityID
GROUP BY p.BusinessEntityID
ORDER BY SUM(OrderQty * UnitPrice) desc
)
GROUP BY SalesPersonID, SalesQuota

select top 3 p.BusinessEntityID, SUM(OrderQty * UnitPrice) CA
INTO TopVendeur
from Sales.SalesOrderDetail d
inner join Sales.SalesOrderHeader h on d.SalesOrderID = h.SalesOrderID
inner join Person.Person p on h.SalesPersonID = p.BusinessEntityID
GROUP BY p.BusinessEntityID
ORDER BY SUM(OrderQty * UnitPrice) desc

select BusinessEntityID, SalesQuota 
from Sales.SalesPerson sp
Where sp.BusinessEntityID IN (SELECT TopVendeur.BusinessEntityID FROM TopVendeur)

SELECT * FROM TopVendeur
SELECT * FROM Sales.SalesPerson

--TOP 3 des meilleurs magasin par année -> Table
--Avec la nouvelle table on veut récupérer le nom du magasin

SELECT TOP 3 BusinessEntityID, YEAR(OrderDate) Annee, SUM(OrderQty * UnitPrice) CA
INTO TopMagasin
FROM Sales.Store st
INNER JOIN Sales.SalesOrderHeader h ON st.SalesPersonID = h.SalesPersonID
INNER JOIN Sales.SalesOrderDetail o ON o.SalesOrderID = h.SalesOrderID
GROUP BY st.BusinessEntityID, YEAR(OrderDate)
ORDER BY CA desc

select Name 
from Sales.Store s
WHERE s.BusinessEntityID IN (SELECT TopMagasin.BusinessEntityID FROM TopMagasin)

Select *
From Sales.Store s
WHERE s.BusinessEntityID IN
(
SELECT TOP 3 BusinessEntityID 
FROM Sales.Store st
INNER JOIN Sales.SalesOrderHeader h ON st.SalesPersonID = h.SalesPersonID
INNER JOIN Sales.SalesOrderDetail o ON o.SalesOrderID = h.SalesOrderID
GROUP BY st.BusinessEntityID, YEAR(OrderDate)
ORDER BY SUM(OrderQty * UnitPrice) desc
)

--Nom des produits qui sont dans le top 2 des catégories
--ayant fait les meilleures ventes
-- Afficher le noms des produits de ces catégories
-- JOINTURE AVEC SalesOrderDetail
--			ProductID
-- Production.Product 
--			ProductSubCategoryID
-- JOINTURE AVEC Production.ProductSubCategory
--			ProductCategoryID
-- JOINTURE AVEC ProductCategory
SELECT p.Name, c.Name
FROM Production.Product p
INNER JOIN Production.ProductSubcategory s ON p.ProductSubcategoryID = s.ProductSubcategoryID
INNER JOIN Production.ProductCategory c ON s.ProductCategoryID = c.ProductCategoryID
WHERE c.ProductCategoryID IN
(
SELECT TOP 2 c.ProductCategoryID
FROM Sales.SalesOrderDetail sod
INNER JOIN Production.ProductSubcategory s ON p.ProductSubcategoryID = s.ProductSubcategoryID
INNER JOIN Production.ProductCategory c ON s.ProductCategoryID = c.ProductCategoryID
INNER JOIN Production.Product p ON p.ProductID = sod.ProductID
GROUP BY c.ProductCategoryID
ORDER BY SUM(OrderQty * UnitPrice) DESC
)

select * from Person.Password
where BusinessEntityID = 4

SELECT * from HumanResources.EmployeeDepartmentHistory 
SELECT * from Sales.SalesPerson

-- Les vendeurs qui ont réalisés un CA < 150.000 sont virés
UPDATE HumanResources.EmployeeDepartmentHistory
SET
	EndDate = GETDATE()
WHERE 
	BusinessEntityID IN
(
SELECT BusinessEntityID from Sales.SalesPerson
where SalesLastYear < 150000
)