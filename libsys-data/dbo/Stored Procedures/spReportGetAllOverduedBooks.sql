CREATE PROCEDURE [dbo].[spReportGetAllOverduedBooks]

AS
BEGIN
	SET NOCOUNT ON
	
	SELECT [Id], 
	   [BookId], 
	   [CallNumber], 
	   [BookTitle], 
	   [ClassificationId], 
	   [ClassificationType], 
	   [Status], 
	   [DateBorrowed], 
	   [DueDate], 
	   [CreatedAt] 
	FROM dbo.TransactionDetails 
	WHERE [Status] = 'PENDING' AND [DueDate] < GETDATE()
	ORDER BY CreatedAt 
	DESC
END