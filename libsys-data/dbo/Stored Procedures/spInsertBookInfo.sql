﻿CREATE PROCEDURE [dbo].[spInsertBookInfo]
	@Id INT OUTPUT,
	@CallNumber NVARCHAR(128),
	@Classification NVARCHAR(128),
	@Title NVARCHAR(MAX),
	@Description NVARCHAR(MAX),
	@Edition NVARCHAR(50),
	@Volumes INT,
	@Pages INT,
	@Source NVARCHAR(50),
	@Price MONEY,
	@Publisher NVARCHAR(50),
	@Location NVARCHAR(50),
	@Year INT,
	@Author NVARCHAR(128),
	@Status NVARCHAR(50),
	@CreatedBy NVARCHAR(50),
	@CreatedAt DATETIME2,
	@ModifiedBy NVARCHAR(50),
	@LastModified DATETIME2

AS
BEGIN
	SET NOCOUNT ON;

	INSERT INTO dbo.BookInformations(CallNumber, [Classification], Title, [Description], Edition, [Volumes], Pages, [Source], Price, Publisher, [Location], [Year], Author, [Status], CreatedBy, CreatedAt, ModifiedBy, LastModified)
	VALUES (@CallNumber, @Classification, @Title, @Description, @Edition, @Volumes, @Pages, @Source, @Price, @Publisher, @Location, @Year, @Author, @Status, @CreatedBy, @CreatedAt, @ModifiedBy, @LastModified)

	SELECT @Id = @@IDENTITY;

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
		SET copies = copies + 1
		WHERE CallNumber = @CallNumber;
	END
END
