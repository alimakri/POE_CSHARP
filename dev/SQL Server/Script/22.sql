-- CTE Common table expression 16 ms
-- Liste des produits vendus par les 3 meilleurs vendeurs
set statistics time on 
go
WITH temp(vendeur) AS
(
	select top 3
		h.SalesPersonID vendeur
	from 
		Sales.SalesOrderDetail d
		inner join Sales.SalesOrderHeader h on d.SalesOrderID = h.SalesOrderID
	group by
		h.SalesPersonID
	having
		h.SalesPersonID IS NOT NULL
	order by
		SUM(d.UnitPrice * d.OrderQty) desc
)
select distinct
	p.Name produit
from 
	Sales.SalesOrderDetail d
	inner join Production.Product p on d.ProductID = p.ProductID
	inner join Sales.SalesOrderHeader h on d.SalesOrderID = h.SalesOrderID
where
	h.SalesPersonID in
	(
	select vendeur from temp
	)
order by
	produit
go
set statistics time off
