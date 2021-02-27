CREATE TABLE [dbo].[TransactionDetails]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
    [CatalogueId] INT NOT NULL, 
    [UserId] NVARCHAR(128) NOT NULL,
    [ClassificationId] NVARCHAR(128) NOT NULL,
    [ClassificationType] NVARCHAR(50) NOT NULL,
    [Status] NVARCHAR(50) NOT NULL, 
    [DateBorrowed] DATETIME2 NOT NULL DEFAULT getutcdate(), 
    [DueDate] DATETIME2 NOT NULL 
)
