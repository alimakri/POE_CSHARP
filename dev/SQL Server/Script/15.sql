IF OBJECT_ID('dbo.Person','U') IS NOT NULL DROP TABLE dbo.Person;
GO
CREATE TABLE dbo.Person(ID int, Name VARCHAR(30), Mother INT, Father INT);
GO
INSERT dbo.Person
VALUES(1, 'Sue', NULL, NULL)
      ,(2, 'Ed', NULL, NULL)
      ,(3, 'Emma', 1, 2)
      ,(4, 'Jack', 1, 2)
      ,(5, 'Jane', NULL, NULL)
      ,(6, 'Bonnie', 5, 4)
      ,(7, 'Bill', 5, 4);
GO

SELECT * FROM Person

WITH Ancetre(ID) AS
(
	SELECT Mother
	FROM Person
	WHERE Name = 'Bonnie'
UNION
	SELECT Father
	FROM Person
	WHERE Name = 'Bonnie'
UNION ALL
	SELECT Person.Mother
	FROM Person
	INNER JOIN Ancetre ON Ancetre.ID = Person.ID
UNION ALL
	SELECT Person.Father
	FROM Person
	INNER JOIN Ancetre ON Ancetre.ID = Person.ID
)
SELECT Person.ID, Name, Mother, Father
From Ancetre
INNER JOIN Person on Ancetre.ID = Person.ID

SELECT * FROM Person