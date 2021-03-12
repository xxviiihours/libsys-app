CREATE TABLE [dbo].[TransactionDetails]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
    [BookId] INT NOT NULL, 
    [CallNumber] NVARCHAR(128) NOT NULL,
    [BookTitle] NVARCHAR(MAX) NOT NULL,
    [UserId] NVARCHAR(128) NOT NULL,
    [ClassificationId] NVARCHAR(128) NOT NULL,
    [ClassificationType] NVARCHAR(50) NOT NULL,
    [Status] NVARCHAR(50) NOT NULL, 
    [DateBorrowed] DATETIME2 NOT NULL DEFAULT getutcdate(), 
    [DueDate] DATETIME2 NOT NULL, 
    [CreatedAt] DATETIME2 NOT NULL DEFAULT getutcdate(), 
    CONSTRAINT [FK_TransactionDetails_ToBookInformations] FOREIGN KEY (BookId) REFERENCES BookInformations(Id), 
    CONSTRAINT [FK_TransactionDetails_ToUsers] FOREIGN KEY (UserId) REFERENCES [Users](Id) 
)
