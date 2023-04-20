CREATE PROCEDURE [dbo].[GetPersonById]
	@param1 int = 0
AS BEGIN
	SELECT * FROM People WHERE People.PeopleId = @param1
END
