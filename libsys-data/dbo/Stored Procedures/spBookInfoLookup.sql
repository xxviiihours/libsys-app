CREATE PROCEDURE [dbo].[spBookInfoLookup]
	@Id INT
AS
BEGIN
	SET NOCOUNT ON;

	SELECT *
	FROM dbo.BookInformations
	WHERE Id = @Id;

END
