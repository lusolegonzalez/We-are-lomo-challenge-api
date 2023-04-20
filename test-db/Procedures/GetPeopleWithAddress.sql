CREATE PROCEDURE [dbo].[GetPeopleWithAddress]
AS BEGIN
	SELECT  People.PeopleId, People.[Name], People.Lastname, People.Phone, Addresses.[Address] FROM People INNER JOIN Addresses ON People.PeopleId = Addresses.PersonId
END
