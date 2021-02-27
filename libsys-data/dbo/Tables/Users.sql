CREATE TABLE [dbo].[Users]
(
	[Id] NVARCHAR(128) NOT NULL PRIMARY KEY, 
    [FirstName] NVARCHAR(50) NOT NULL, 
    [LastName] NVARCHAR(50) NOT NULL, 
    [UserType] NVARCHAR(50) NOT NULL, 
    [EmailAddress] NVARCHAR(128) NOT NULL, 
    [CreatedAt] DATETIME2 NULL DEFAULT getutcdate() 
)
