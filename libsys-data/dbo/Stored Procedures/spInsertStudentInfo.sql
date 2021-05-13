CREATE PROCEDURE [dbo].[spInsertStudentInfo]
	@Id INT OUTPUT, 
	@StudentId NVARCHAR(128), 
	@FirstName NVARCHAR(50), 
	@LastName NVARCHAR(50), 
	@Gender NVARCHAR(50), 
	@GradeLevel NVARCHAR(50), 
	@PhoneNumber NVARCHAR(MAX), 
	@EmailAddress NVARCHAR(MAX),
	@BorrowLimit INT,
	@ModifiedBy NVARCHAR(50), 
	@LastModified DATETIME2

AS
BEGIN
	SET NOCOUNT ON
	INSERT INTO dbo.Students(StudentId, FirstName, LastName, Gender, GradeLevel, PhoneNumber, EmailAddress, BorrowLimit, ModifiedBy, LastModified)
	VALUES(@StudentId, @FirstName, @LastName, @Gender, @GradeLevel, @PhoneNumber, @EmailAddress, @BorrowLimit,  @ModifiedBy, @LastModified);

	SELECT @Id = SCOPE_IDENTITY();
END