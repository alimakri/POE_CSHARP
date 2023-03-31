USE BD3

select * from Ville
select * from Personne

BEGIN TRAN
delete Personne where id = 8
ROLLBACK TRAN --Retourne avant l'execution de la transaction
COMMIT TRAN -- Fini l'execution

select * from Personne

DECLARE @json NVARCHAR(MAX)

SET @json = 
'{
	"name":"John",
	"surname":"Doe",
	"age":45
}'

SELECT *
INTO #t1
FROM OPENJSON(@json);

select * from #t1