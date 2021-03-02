CREATE PROCEDURE [dbo].[spDeleteBookInfo]
	@Id INT
AS

BEGIN
	DECLARE @Copies INT, @CallNumber NVARCHAR(128);
	SET NOCOUNT ON;

	SET @CallNumber = (SELECT CallNumber
	FROM dbo.BookInformations
	WHERE Id = @Id);
	
	SET @Copies = (SELECT Copies
	FROM dbo.Catalogue 
	WHERE CallNumber = @CallNumber);
	
	DELETE FROM dbo.BookInformations
	WHERE Id = @Id;

	IF @Copies > 0
	BEGIN
		UPDATE dbo.Catalogue
		SET Copies = Copies - 1
		WHERE CallNumber = @CallNumber;
	END
	ELSE
	RETURN NULL;
END
