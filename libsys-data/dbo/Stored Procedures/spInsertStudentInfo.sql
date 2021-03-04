CREATE PROCEDURE [dbo].[spInsertStudentInfo]
	@Id INT OUTPUT, 
	@StudentId NVARCHAR(128), 
	@FirstName NVARCHAR(50), 
	@LastName NVARCHAR(50), 
	@Gender NVARCHAR(50), 
	@Course NVARCHAR(50), 
	@YearLevel NVARCHAR(50), 
	@Department NVARCHAR(50), 
	@PhoneNumber NVARCHAR(MAX), 
	@EmailAddress NVARCHAR(MAX),
	@BorrowLimit INT

AS
BEGIN
	SET NOCOUNT ON
	INSERT INTO dbo.Students(StudentId, FirstName, LastName, Gender, Course, YearLevel, Department, PhoneNumber, EmailAddress, BorrowLimit)
	VALUES(@StudentId, @FirstName, @LastName, @Gender, @Course, @YearLevel, @Department, @PhoneNumber, @EmailAddress, @BorrowLimit);

	SELECT @Id = @@IDENTITY;
END