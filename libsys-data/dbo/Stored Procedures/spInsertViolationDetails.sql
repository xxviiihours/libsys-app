CREATE PROCEDURE [dbo].[spInsertViolationDetails]
	@Id INT OUTPUT, 
    @ClassificationId NVARCHAR(50), 
    @BookId INT, 
    @UserId NVARCHAR(50), 
    @OrNumber NVARCHAR(50), 
    @CashierName NVARCHAR(50), 
    @TotalDays INT, 
    @TotalFine DECIMAL, 
    @ModifiedAt DATETIME2
AS
BEGIN
    SET NOCOUNT ON

    INSERT INTO dbo.ViolationDetails(ClassificationId, BookId, UserId, OrNumber, CashierName, TotalDays, TotalFine, ModifiedAt)
    VALUES(@ClassificationId, @BookId, @UserId, @OrNumber, @CashierName, @TotalDays, @TotalFine, @ModifiedAt);

    SELECT @Id = @@IDENTITY;
END
