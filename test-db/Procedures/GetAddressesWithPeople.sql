CREATE PROCEDURE [dbo].[GetAddressesWithPeople]
AS BEGIN
	SELECT Addresses.[Address], People.[Name], People.Lastname FROM People INNER JOIN Addresses ON People.PeopleId = Addresses.PersonId
END
