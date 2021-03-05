CREATE PROCEDURE [dbo].[spUpdateBookInfo]
	@Id INT,
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
	--@Status NVARCHAR(50),
	@CreatedBy NVARCHAR(50),
	@CreatedAt DATETIME2,
	@ModifiedBy NVARCHAR(50),
	@LastModified DATETIME2
AS
BEGIN
	UPDATE dbo.BookInformations
	SET CallNumber = @CallNumber, 
		[Classification] = @Classification, 
		Title = @Title, 
		[Description] = @Description, 
		Edition = @Edition,
		Volumes = @Volumes, 
		Pages = @Pages, 
		[Source] = @Source, 
		Price = @Price, 
		Publisher = @Publisher, 
		[Location] = @Location, 
		[Year] = @Year,
		Author = @Author, 
		--[Status] = @Status, 
		CreatedBy = @CreatedBy, 
		CreatedAt = @CreatedAt, 
		ModifiedBy = @ModifiedBy, 
		LastModified = @LastModified
	WHERE Id = @Id;
END
