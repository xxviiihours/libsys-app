﻿CREATE PROCEDURE [dbo].[spGetAllBookInfo]

AS
BEGIN
	SET NOCOUNT ON

	SELECT Id, CallNumber, [Classification], Title, [Description], Edition, [Volumes], Pages, [Source], Price, Publisher, [Location], [Year], Author, [Status], ModifiedBy, LastModified
	FROM dbo.BookInformations
	ORDER BY LastModified
	DESC
END
