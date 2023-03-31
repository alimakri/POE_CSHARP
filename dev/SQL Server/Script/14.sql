use AdventureWorks2017
WITH Semaine(n, weekday)
AS 
(
	SELECT 0, DATENAME(DW,0)
	UNION ALL
	SELECT n+1, DATENAME(DW, n + 1)
	FROM
		Semaine
	WHERE n < 6
)
SELECT weekday
FROM Semaine

CREATE TABLE dbo.MyEmployees
(
EmployeeID SMALLINT NOT NULL,
FirstName NVARCHAR(30) NOT NULL,
LastName NVARCHAR(40) NOT NULL,
Title NVARCHAR(50) NOT NULL,
DeptID SMALLINT NOT NULL,
ManagerID SMALLINT NULL,
CONSTRAINT PK_EmployeeID PRIMARY KEY CLUSTERED (EmployeeID ASC),
CONSTRAINT FK_MyEmployees_ManagerID_EmployeeID FOREIGN KEY (ManagerID) REFERENCES dbo.MyEmployees (EmployeeID)
);
-- Populate the table with values.
INSERT INTO dbo.MyEmployees VALUES
(1, N'Ken', N'Sánchez', N'Chief Executive Officer',16, NULL)
,(273, N'Brian', N'Welcker', N'Vice President of Sales', 3, 1)
,(274, N'Stephen', N'Jiang', N'North American Sales Manager', 3, 273)
,(275, N'Michael', N'Blythe', N'Sales Representative', 3, 274)
,(276, N'Linda', N'Mitchell', N'Sales Representative', 3, 274)
,(285, N'Syed', N'Abbas', N'Pacific Sales Manager', 3, 273)
,(286, N'Lynn', N'Tsoflias', N'Sales Representative', 3, 285)
,(16, N'David', N'Bradley', N'Marketing Manager', 4, 273)
,(23, N'Mary', N'Gibson', N'Marketing Specialist', 4, 16);

SELECT * from dbo.MyEmployees

SELECT *,1 level from MyEmployees where ManagerID IS NULL
UNION ALL
SELECT *,2 level from MyEmployees where ManagerID = 1
UNION ALL
SELECT *,3 level from MyEmployees where ManagerID = 273
UNION ALL
SELECT *,4 level from MyEmployees where ManagerID IN (16,274,285)
UNION ALL
SELECT *,5 level from MyEmployees where ManagerID IN (23,275,276,286)

WITH Niveau(ManagerID,EmployeeID, Title, EmployeeLevel)
AS
(
	SELECT ManagerID,EmployeeID, Title, 1 AS EmployeeLevel
	FROM MyEmployees
	WHERE ManagerID IS NULL

	UNION ALL

	SELECT e.ManagerID, e.EmployeeID, e.Title, EmployeeLevel + 1
	FROM MyEmployees e
	INNER JOIN Niveau AS n ON e.ManagerID = n.EmployeeID
)
SELECT ManagerID,EmployeeID, Title, EmployeeLevel
FROM Niveau
WHERE EmployeeLevel <=2
ORDER BY EmployeeLevel

CREATE TABLE dbo.Felins
(
FelinID SMALLINT NOT NULL,
Name NVARCHAR(30) NOT NULL,
ParentID SMALLINT NULL,
CONSTRAINT PK_FelinID PRIMARY KEY CLUSTERED (FelinID ASC),
CONSTRAINT FK_MyEmployees_ParentID_FelinID FOREIGN KEY (ParentID) REFERENCES Felins (FelinID)
);
-- Populate the table with values.
INSERT INTO dbo.Felins VALUES
(1, 'Felidae',NULL),
(2, 'Phanterinae',1),
(3, 'Phanthère',2),
(4, 'Leopard',3),
(5, 'Lion',3),
(6, 'Jaguar',3),
(7, 'Leopard des Neiges',3),
(8, 'Tigre',3),
(9, 'Felinae',1),
(10, 'Acinonyx',9),
(11, 'Hyène',10),
(12, 'Acinonyxa',9),
(13, 'Cougar',12)

SELECT * FROM Felins

WITH ArbreFelins(FelinID, Name, ParentID, FelinLevel) AS 
(
	SELECT FelinID, Name, ParentID, 0 AS FelinLevel
	From Felins
	WHERE ParentID is NULL
	UNION ALL
	SELECT f.FelinID, f.Name, f.ParentID, FelinLevel +1
	FROM Felins AS f
	INNER JOIN ArbreFelins AS a ON f.ParentID = a.FelinID
)
SELECT FelinID, Name, ParentID, FelinLevel
FROM ArbreFelins
ORDER BY FelinLevel

WITH cte (EmployeeID, ManagerID, Title) AS
(
    SELECT EmployeeID, ManagerID, Title
    FROM dbo.MyEmployees
    WHERE ManagerID IS NOT NULL
  UNION ALL
    SELECT cte.EmployeeID, cte.ManagerID, cte.Title
    FROM cte
    JOIN dbo.MyEmployees AS e
        ON cte.ManagerID = e.EmployeeID
)
SELECT EmployeeID, ManagerID, Title
FROM cte
OPTION (MAXRECURSION 500);


WITH Vires(ID) AS
(
	SELECT BusinessEntityID from Sales.SalesPerson
	WHERE SalesLastYear < 150000
)
UPDATE HumanResources.EmployeeDepartmentHistory
SET
	EndDate = GETDATE()
FROM HumanResources.EmployeeDepartmentHistory h
INNER JOIN Vires on Vires.ID = h.BusinessEntityID

-- Reduction des BK de 10%

WITH Reduction(ID) AS 
(	
	SELECT ProductID from Production.Product
	WHERE LEFT(ProductNumber,2) = 'BK'
)
UPDATE Production.Product
SET
	Production.Product.ListPrice = Production.Product.ListPrice * 0.9
FROM 
	Production.Product
INNER JOIN
	Reduction on Reduction.ID = Production.Product.ProductID

SELECT * FROM Production.Product 
--771 -> 3399,99 -> 3059,991

-- On veut récupérer tous les composants et sous-composants du Produit 801
SELECT * from Production.BillOfMaterials where ProductAssemblyID = 801

WITH Composants(ProductAssembly, Component, Date, Level) AS
(
	SELECT ProductAssemblyID, ComponentID, ModifiedDate, BOMLevel
	FROM Production.BillOfMaterials bom
	WHERE bom.ProductAssemblyID = 801
		AND EndDate IS NULL
	UNION ALL
	SELECT ProductAssemblyID, ComponentID, ModifiedDate, BOMLevel
	FROM Production.BillOfMaterials bom2
	INNER JOIN Composants ON Composants.Component = bom2.ProductAssemblyID AND EndDate IS NULL
)
SELECT ProductAssembly , Component, Date, Level
FROM Composants c
ORDER BY Level

-- Update ModifiedDate avec GETDATE()

WITH Composants(ProductAssembly, Component, Date, Level) AS
(
	SELECT ProductAssemblyID, ComponentID, ModifiedDate, BOMLevel
	FROM Production.BillOfMaterials bom
	WHERE bom.ProductAssemblyID = 801
		AND EndDate IS NULL
	UNION ALL
	SELECT ProductAssemblyID, ComponentID, ModifiedDate, BOMLevel
	FROM Production.BillOfMaterials bom2
	INNER JOIN Composants ON Composants.Component = bom2.ProductAssemblyID AND EndDate IS NULL
)
UPDATE Production.BillOfMaterials
SET ModifiedDate = GETDATE()
FROM Production.BillOfMaterials bom
INNER JOIN Composants c on c.ProductAssembly = bom.ProductAssemblyID

SELECT * from Production.BillOfMaterials

SELECT * from Production.UnitMeasure
select Name from Production.Product where ProductID = 801