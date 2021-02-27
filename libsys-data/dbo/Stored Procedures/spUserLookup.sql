CREATE PROCEDURE [dbo].[spUserLookup]
	@Id nvarchar(128)
AS
BEGIN
	SELECT Id, FirstName, LastName, UserType, EmailAddress, CreatedAt
	FROM dbo.Users
	WHERE Id = @Id
END