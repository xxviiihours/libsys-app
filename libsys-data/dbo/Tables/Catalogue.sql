CREATE TABLE [dbo].[Catalogue]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [BookInformationId] INT NOT NULL, 
    [Copies] INT NOT NULL DEFAULT 1
)
