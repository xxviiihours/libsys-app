CREATE PROCEDURE [dbo].[spInsertBorrowTransaction]
	@Id INT OUTPUT,
    @BookId INT, 
    @CallNumber NVARCHAR(128),
    @UserId NVARCHAR(128),
    @ClassificationId NVARCHAR(128),
    @ClassificationType NVARCHAR(50),
    @Status NVARCHAR(50), 
    @DateBorrowed DATETIME2, 
    @DueDate DATETIME2, 
    @CreatedAt DATETIME2
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO dbo.TransactionDetails(BookId, CallNumber, UserId, ClassificationId, ClassificationType, [Status], DateBorrowed, DueDate, CreatedAt)
    VALUES(@BookId, @CallNumber, @UserId, @ClassificationId, @ClassificationType, @Status, @DateBorrowed, @DueDate, @CreatedAt);
    SELECT @Id = @@IDENTITY;

    UPDATE dbo.BookInformations
    SET [Status] = 'UNAVAILABLE'
    WHERE Id = @BookId;

    UPDATE dbo.Catalogue
    SET Copies = Copies - 1
    WHERE CallNumber = @CallNumber;

    UPDATE dbo.Students
    SET BorrowLimit = BorrowLimit - 1
    WHERE StudentId = @ClassificationId;

END