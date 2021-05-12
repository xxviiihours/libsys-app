CREATE PROCEDURE [dbo].[spUpdateStudentInfo]
	@Id INT OUTPUT, 
	@StudentId NVARCHAR(128), 
	@FirstName NVARCHAR(50), 
	@LastName NVARCHAR(50), 
	@Gender NVARCHAR(50), 
	@GradeLevel NVARCHAR(50), 
	@PhoneNumber INT, 
	@EmailAddress NVARCHAR(MAX),
	@ModifiedBy NVARCHAR(50), 
	@LastModified DATETIME2
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
		GradeLevel = @GradeLevel, 
		PhoneNumber = @PhoneNumber, 
		EmailAddress = @EmailAddress,
		BorrowLimit = @BorrowLimit,
		ModifiedBy = @ModifiedBy, 
		LastModified = @LastModified
	WHERE Id = @Id;
END
