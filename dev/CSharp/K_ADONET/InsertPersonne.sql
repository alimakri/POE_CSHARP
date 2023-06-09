USE [AdventureWorks2017]
GO
ALTER PROC [dbo].[InsertPersonne]( @prenom nvarchar(50), @nom nvarchar(50), @type nchar(2))
AS
	DECLARE @id int
	select @id = Max(BusinessEntityId) from Person.BusinessEntity

	Insert Person.BusinessEntity (rowguid, ModifiedDate) values(NEWID(), GETDATE()) 
	select @id=Max(BusinessEntityId) from Person.BusinessEntity
	Insert into Person.Person (BusinessEntityId, FirstName, LastName, PersonType) values(@id, @prenom, @nom, @type)
