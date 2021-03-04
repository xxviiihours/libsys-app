CREATE PROCEDURE [dbo].[spGetAllBookInfo]

AS
BEGIN
	SET NOCOUNT ON

	SELECT *
	FROM dbo.BookInformations
	ORDER BY CreatedAt
	DESC
END
