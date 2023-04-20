CREATE PROCEDURE [dbo].[CreateAddress]
	@personId int,
	@address varchar

AS BEGIN
	INSERT INTO Addresses(PersonId, Address) VALUES (@personId, @address)
	SELECT CAST(scope_identity() AS int)
END
