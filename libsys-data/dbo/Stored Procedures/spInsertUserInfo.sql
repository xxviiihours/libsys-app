CREATE PROCEDURE [dbo].[spInsertUserInfo]
	@Id NVARCHAR(128),
	@FirstName NVARCHAR(50),
	@LastName NVARCHAR(50),
	@UserType NVARCHAR(50),
	@EmailAddress NVARCHAR(50),
	@CreatedAt DATETIME2
AS
BEGIN
	SET NOCOUNT ON

	INSERT INTO dbo.Users(Id, FirstName, LastName, UserType, EmailAddress, CreatedAt)
	VALUES (@Id, @FirstName, @LastName, @UserType, @EmailAddress, @CreatedAt)
END
