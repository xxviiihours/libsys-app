CREATE PROCEDURE [dbo].[spStudentInfoLookup]
	@StudentId NVARCHAR (128)
AS
BEGIN
	SET NOCOUNT ON

	SELECT Id, StudentId, FirstName, LastName, Gender, Course, YearLevel, Department, PhoneNumber, EmailAddress, BorrowLimit
	FROM DBO.Students
	WHERE StudentId = @StudentId;
END