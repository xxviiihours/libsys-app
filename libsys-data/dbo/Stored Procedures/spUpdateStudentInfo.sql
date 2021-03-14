CREATE PROCEDURE [dbo].[spUpdateStudentInfo]
	@Id INT OUTPUT, 
	@StudentId NVARCHAR(128), 
	@FirstName NVARCHAR(50), 
	@LastName NVARCHAR(50), 
	@Gender NVARCHAR(50), 
	@Course NVARCHAR(50), 
	@YearLevel NVARCHAR(50), 
	@Department NVARCHAR(50), 
	@PhoneNumber NVARCHAR(MAX), 
	@EmailAddress NVARCHAR(MAX)
AS
BEGIN
	SET NOCOUNT ON;
	DECLARE @BorrowLimit AS INT;
	SET @BorrowLimit = 2;

	UPDATE dbo.Students
	SET StudentId = @StudentId, 
		FirstName = @FirstName, 
		LastName = @LastName, 
		Gender = @Gender, 
		Course = @Course, 
		YearLevel = @YearLevel, 
		Department = @Department, 
		PhoneNumber = @PhoneNumber, 
		EmailAddress = @EmailAddress,
		BorrowLimit = @BorrowLimit
	WHERE Id = @Id;
END
