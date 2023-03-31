select 
	ISNULL(c.Name, '(Autres)') Cat, COUNT(p.Name) n 
from 
	Production.ProductCategory c
	right join Production.ProductSubcategory s on s.ProductCategoryID = c.ProductCategoryID
	right join Production.Product p on p.ProductSubcategoryID = s.ProductSubcategoryID
group by
	c.Name
