CREATE PROCEDURE [dbo].[spStudentInfoLookup]
	@StudentId NVARCHAR (128)
AS
BEGIN
	SET NOCOUNT ON

	SELECT Id, StudentId, FirstName, LastName, Gender, GradeLevel, PhoneNumber, EmailAddress, BorrowLimit, ModifiedBy, LastModified
	FROM dbo.Students
	WHERE StudentId = @StudentId;
END