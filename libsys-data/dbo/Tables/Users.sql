CREATE TABLE [dbo].[Users]
(
	[Id] NVARCHAR(128) NOT NULL PRIMARY KEY, 
    [FirstName] NVARCHAR(50) NOT NULL, 
    [LastName] NVARCHAR(50) NOT NULL, 
    [UserType] NVARCHAR(50) NOT NULL, 
    [EmailAddress] NVARCHAR(128) NOT NULL, 
    [UserName] NVARCHAR(250) NOT NULL, 
    [Password] NVARCHAR(MAX) NOT NULL, 
    [SecretQuestion] NVARCHAR(MAX) NOT NULL, 
    [SecretAnswer] NVARCHAR(50) NOT NULL
)
