CREATE PROCEDURE [dbo].[spReportGetAllBorrowedBooks]

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
	WHERE [Status] = 'PENDING' 
	ORDER BY CreatedAt 
	DESC
END