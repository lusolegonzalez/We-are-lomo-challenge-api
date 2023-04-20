CREATE PROCEDURE [dbo].[CreatePerson]
	@name varchar,
	@lastName varchar,
	@phone varchar

AS BEGIN
	INSERT INTO People([Name], Lastname, Phone) VALUES (@name, @lastName, @phone)
	SELECT CAST(scope_identity() AS int)
END
