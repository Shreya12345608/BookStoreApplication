
CREATE PROCEDURE spAddBooks(
  
	  @BookName VARCHAR(50), 
	@AuthorName VARCHAR(50),
	@Description     VARCHAR(100),  
	@Quantity      VARCHAR(10),
	@BookImage VARCHAR(200),
	@Rating DOUBLE PRECISION,
	@Price DOUBLE PRECISION
)
AS
DECLARE @status INT
BEGIN  
	BEGIN TRY
	BEGIN TRANSACTION
		IF exists(SELECT * FROM Books WHERE BookName=@BookName)
       SET @status=0
	ELSE
      insert into Books(BookName, AuthorName, Description, Quantity, BookImage, Rating,Price) 
	   values( @BookName, @AuthorName, @Description, @Quantity, @BookImage, @Rating,@Price) 
	   SET @status=1
SELECT @status
	COMMIT TRANSACTION
	END TRY
	BEGIN CATCH
	INSERT INTO dbo.DB_Errors
    VALUES
  (SUSER_SNAME(),
   ERROR_NUMBER(),
   ERROR_STATE(),
   ERROR_SEVERITY(),
   ERROR_LINE(),
   ERROR_PROCEDURE(),
   ERROR_MESSAGE(),
   GETDATE());

    -- Test XACT_STATE for 0, 1, or -1.  
    -- If 1, the transaction is committable.  
    -- If -1, the transaction is uncommittable and should   
    --     be rolled back.  
    -- XACT_STATE = 0 means there is no transaction and  
    --     a commit or rollback operation would generate an error.  
  
    -- Test whether the transaction is uncommittable.  
    IF (XACT_STATE()) = -1
      ROLLBACK TRANSACTION
 
  -- Test XACT_STATE for 0, 1, or -1.  
    -- If 1, the transaction is committable.  
    -- If -1, the transaction is uncommittable and should   
    --     be rolled back.  
    -- XACT_STATE = 0 means there is no transaction and  
    --     a commit or rollback operation would generate an error.  
  
    -- Test whether the transaction is uncommittable.  
    IF (XACT_STATE()) = 1
      COMMIT TRANSACTION
	END CATCH
END