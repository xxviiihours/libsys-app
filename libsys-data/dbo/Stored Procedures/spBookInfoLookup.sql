CREATE PROCEDURE [dbo].[spBookInfoLookup]
	@Id INT
AS
BEGIN
	SET NOCOUNT ON;

	SELECT CallNumber, [Classification], Title, [Description], Edition, [Volumes], Pages, [Source], Price, Publisher, [Location], [Year], Author, [Status], CreatedBy, CreatedAt, ModifiedBy, LastModified
	FROM dbo.BookInformations
	WHERE Id = @Id 

END
