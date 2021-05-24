CREATE PROCEDURE [dbo].[spGetAllBookByTitle]
	@Title NVARCHAR(MAX)

AS
	SET NOCOUNT ON
	
	SELECT Id, CallNumber, [Classification], Title, [Description], Edition, [Volumes], Pages, [Source], Price, Publisher, [Location], [Year], Author, [Status], ModifiedBy, LastModified
	FROM dbo.BookInformations
	WHERE Title LIKE '%' + @Title + '%'
	ORDER BY LastModified
	DESC;
RETURN 0
