CREATE TABLE [dbo].[Students]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
    [StudentId] NVARCHAR(128) NOT NULL,
    [FirstName] NVARCHAR(50) NOT NULL, 
    [LastName] NVARCHAR(50) NOT NULL, 
    [Gender] NVARCHAR(50) NOT NULL, 
    [GradeLevel] NVARCHAR(50) NOT NULL, 
    [PhoneNumber] INT NOT NULL, 
    [EmailAddress] NVARCHAR(MAX) NOT NULL, 
    [BorrowLimit] INT NOT NULL DEFAULT 2, 
    [ModifiedBy] NVARCHAR(50) NULL, 
    [LastModified] DATETIME2 NULL DEFAULT getutcdate()
)
