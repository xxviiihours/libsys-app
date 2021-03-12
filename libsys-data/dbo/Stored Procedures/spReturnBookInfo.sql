CREATE PROCEDURE [dbo].[spReturnBookInfo]
	@BookId INT,
    @CallNumber NVARCHAR(128),
    @ClassificationId NVARCHAR(128),
    @Status NVARCHAR(128),
    @Id INT
AS
BEGIN
    SET NOCOUNT ON

    UPDATE dbo.TransactionDetails
    SET [Status] = @Status
    WHERE BookId = @BookId
    AND Id = @Id;

    UPDATE dbo.BookInformations
    SET [Status] = 'AVAILABLE'
    WHERE Id = @BookId;

    UPDATE dbo.Catalogue
    SET Copies = Copies + 1
    WHERE CallNumber = @CallNumber

    UPDATE dbo.Students
    SET BorrowLimit = BorrowLimit + 1
    WHERE StudentId = @ClassificationId

END
