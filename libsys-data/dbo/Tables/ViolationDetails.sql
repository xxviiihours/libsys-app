CREATE TABLE [dbo].[ViolationDetails]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [ClassificationId] NVARCHAR(50) NULL, 
    [BookId] INT NULL, 
    [UserId] NVARCHAR(50) NULL, 
    [OrNumber] NVARCHAR(50) NULL, 
    [CashierName] NVARCHAR(50) NULL, 
    [TotalDays] INT NULL, 
    [TotalFine] DECIMAL NULL, 
    [ModifiedAt] DATETIME2 NULL DEFAULT getutcdate()
)
