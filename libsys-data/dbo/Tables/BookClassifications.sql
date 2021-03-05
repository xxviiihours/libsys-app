CREATE TABLE [dbo].[BookClassifications]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	[CallNumber] NVARCHAR(MAX) NOT NULL,
	[Classification] NVARCHAR(MAX) NOT NULL
)
