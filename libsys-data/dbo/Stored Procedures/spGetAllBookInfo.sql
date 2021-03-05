CREATE PROCEDURE [dbo].[spGetAllBookInfo]

AS
BEGIN
	SET NOCOUNT ON

	SELECT Id, CallNumber, [Classification], Title, [Description], Edition, [Volumes], Pages, [Source], Price, Publisher, [Location], [Year], Author, [Status], CreatedBy, CreatedAt, ModifiedBy, LastModified
	FROM dbo.BookInformations
	ORDER BY CreatedAt
	DESC
END
