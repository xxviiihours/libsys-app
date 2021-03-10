CREATE PROCEDURE [dbo].[spAvailableBookInfoLookup]
	@Title NVARCHAR(MAX)

AS
	SET NOCOUNT ON
	DECLARE @Status AS NVARCHAR(128);
	
	SET @Status = 'AVAILABLE';

	SELECT CallNumber, [Classification], Title, [Description], Edition, [Volumes], Pages, [Source], Price, Publisher, [Location], [Year], Author, [Status], ModifiedBy, LastModified
	FROM dbo.BookInformations
	WHERE Title LIKE '%' + @Title + '%' AND [Status] = @Status 
	ORDER BY LastModified
	DESC;
RETURN 0
