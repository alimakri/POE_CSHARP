-- Liste des produits vendus par les 3 meilleurs vendeurs 14 ms

-- les 3 meilleurs vendeurs
--select top 3
--	h.SalesPersonID vendeur, SUM(d.UnitPrice * d.OrderQty) total
--from 
--	Sales.SalesOrderDetail d
--	inner join Sales.SalesOrderHeader h on d.SalesOrderID = h.SalesOrderID
--group by
--	h.SalesPersonID
--having
--	h.SalesPersonID IS NOT NULL
--order by
--	total desc

-- Liste des produits vendus avec vendeur (nom produit, id vendeur)
set statistics time on 
go
select distinct
	p.Name produit
from 
	Sales.SalesOrderDetail d
	inner join Production.Product p on d.ProductID = p.ProductID
	inner join Sales.SalesOrderHeader h on d.SalesOrderID = h.SalesOrderID
where
	h.SalesPersonID in
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
order by
	produit
go
set statistics time off
go

