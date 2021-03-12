CREATE PROCEDURE [dbo].[spBorrowedBooksLookup]
	@ClassificationId NVARCHAR(128)
AS
BEGIN
	SET NOCOUNT ON
	DECLARE @Status AS NVARCHAR(50);
	SET @Status = 'PENDING';

	SELECT Id, BookId, CallNumber, BookTitle, UserId, ClassificationId, ClassificationType, [Status], DateBorrowed, DueDate, CreatedAt
	FROM dbo.TransactionDetails
	WHERE ClassificationId = @ClassificationId
	AND [Status] = @Status
	ORDER BY DateBorrowed
	DESC;

END
