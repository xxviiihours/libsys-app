CREATE PROCEDURE [dbo].[spGetAllBookClassification]

AS
BEGIN
	SET NOCOUNT ON
	
	SELECT Id, CallNumber, [Classification]
	FROM dbo.BookClassifications

END
