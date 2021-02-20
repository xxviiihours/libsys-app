CREATE TABLE [dbo].[BookInformations]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [CallNumber] NVARCHAR(50) NOT NULL, 
    [Title] NVARCHAR(MAX) NOT NULL, 
    [Description] NVARCHAR(MAX) NULL,
    [Edition] NVARCHAR(50) NOT NULL, 
    [ Volumes] INT NOT NULL DEFAULT 1, 
    [Pages] INT NOT NULL DEFAULT 1, 
    [Source] NVARCHAR(50) NOT NULL, 
    [Price] MONEY NOT NULL, 
    [Publisher] NVARCHAR(50) NOT NULL, 
    [Location] NVARCHAR(50) NOT NULL, 
    [Year] INT NOT NULL, 
    [Author] NVARCHAR(128) NOT NULL, 
    [Status] NVARCHAR(50) NOT NULL DEFAULT ('ORIGINAL'), 
    [CreatedBy] NVARCHAR(50) NOT NULL,
    [CreatedAt] DATETIME2 NOT NULL DEFAULT getutcdate(),
    [ModifiedBy] NVARCHAR(50) NOT NULL,
    [LastModified] DATETIME2 NOT NULL DEFAULT getutcdate()  
)
