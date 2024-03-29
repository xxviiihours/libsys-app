﻿CREATE PROCEDURE [dbo].[spBookInfoLookup]
	@Id INT
AS
BEGIN
	SET NOCOUNT ON;

	SELECT CallNumber, [Classification], Title, [Description], Edition, [Volumes], Pages, [Source], Price, Publisher, [Location], [Year], Author, [Status], ModifiedBy, LastModified
	FROM dbo.BookInformations
	WHERE Id = @Id
	ORDER BY LastModified
	DESC;


END
