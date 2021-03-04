CREATE TABLE [dbo].[Students]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
    [StudentId] NVARCHAR(128) NOT NULL,
    [FirstName] NVARCHAR(50) NOT NULL, 
    [LastName] NVARCHAR(50) NOT NULL, 
    [Gender] NVARCHAR(50) NOT NULL, 
    [Course] NVARCHAR(50) NOT NULL, 
    [YearLevel] NVARCHAR(50) NOT NULL, 
    [Department] NVARCHAR(50) NOT NULL, 
    [PhoneNumber] NVARCHAR(MAX) NOT NULL, 
    [EmailAddress] NVARCHAR(MAX) NOT NULL, 
    [BorrowLimit] INT NOT NULL DEFAULT 2
)
