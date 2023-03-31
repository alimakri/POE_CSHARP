-- Liste des produits vendus par les 3 meilleurs vendeurs
drop table #t
select top 3
	h.SalesPersonID vendeur
into
	#t
from 
	Sales.SalesOrderDetail d
	inner join Sales.SalesOrderHeader h on d.SalesOrderID = h.SalesOrderID
group by
	h.SalesPersonID
having
	h.SalesPersonID IS NOT NULL
order by
	SUM(d.UnitPrice * d.OrderQty) desc

select distinct
	p.Name produit
from 
	Sales.SalesOrderDetail d
	inner join Production.Product p on d.ProductID = p.ProductID
	inner join Sales.SalesOrderHeader h on d.SalesOrderID = h.SalesOrderID
where
	h.SalesPersonID in
	(
	select vendeur from #t
	)
order by
	produit
	
