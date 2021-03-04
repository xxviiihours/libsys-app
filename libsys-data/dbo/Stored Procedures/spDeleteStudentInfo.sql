CREATE PROCEDURE [dbo].[spDeleteStudentInfo]
	@Id INT
AS
BEGIN
	SET NOCOUNT ON;

	DELETE FROM dbo.Students
	WHERE Id = @Id;
END
