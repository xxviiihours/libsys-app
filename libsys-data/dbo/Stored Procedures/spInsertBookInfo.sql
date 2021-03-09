CREATE PROCEDURE [dbo].[spInsertBookInfo]
	@Id INT OUTPUT,
	@CallNumber NVARCHAR(128),
	@Classification NVARCHAR(128),
	@Title NVARCHAR(MAX),
	@Description NVARCHAR(MAX),
	@Edition NVARCHAR(50),
	@Volumes NVARCHAR(50),
	@Pages INT,
	@Source NVARCHAR(50),
	@Price MONEY,
	@Publisher NVARCHAR(50),
	@Location NVARCHAR(50),
	@Year INT,
	@Author NVARCHAR(128),
	@Status NVARCHAR(50),
	--@CreatedBy NVARCHAR(50),
	--@CreatedAt DATETIME2,
	@ModifiedBy NVARCHAR(50),
	@LastModified DATETIME2

AS
BEGIN
	SET NOCOUNT ON;
	--DECLARE @Status AS NVARCHAR(50);
	
	IF NOT EXISTS(
	SELECT @CallNumber
	FROM dbo.BookInformations
	WHERE CallNumber = @CallNumber AND [Status] = 'ORIGINAL')
	BEGIN
	SET @Status = 'ORIGINAL';
		INSERT INTO dbo.BookInformations(CallNumber, [Classification], Title, [Description], Edition, [Volumes], Pages, [Source], Price, Publisher, [Location], [Year], Author, [Status], ModifiedBy, LastModified)
		VALUES (@CallNumber, @Classification, @Title, @Description, @Edition, @Volumes, @Pages, @Source, @Price, @Publisher, @Location, @Year, @Author, @Status, @ModifiedBy, @LastModified)

		SELECT @Id = @@IDENTITY;
	END
	ELSE
	BEGIN
		SET @Status = 'AVAILABLE';
		INSERT INTO dbo.BookInformations(CallNumber, [Classification], Title, [Description], Edition, [Volumes], Pages, [Source], Price, Publisher, [Location], [Year], Author, [Status], ModifiedBy, LastModified)
		VALUES (@CallNumber, @Classification, @Title, @Description, @Edition, @Volumes, @Pages, @Source, @Price, @Publisher, @Location, @Year, @Author, @Status, @ModifiedBy, @LastModified)

		SELECT @Id = @@IDENTITY;
	END

	IF NOT EXISTS(
	SELECT CallNumber 
	FROM dbo.Catalogue 
	WHERE CallNumber = @CallNumber)
	BEGIN
		INSERT INTO dbo.Catalogue(CallNumber, Copies)
		VALUES (@CallNumber, 1);

		SELECT @Id = @@IDENTITY;
	END
	ELSE
	BEGIN
		UPDATE dbo.Catalogue
		SET Copies = Copies + 1
		WHERE CallNumber = @CallNumber;
	END
END
