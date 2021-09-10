

CREATE procedure spAddToCart

(
        @userId int,
        @BookId int
)
AS
DECLARE @Count INT
BEGIN TRY
BEGIN TRANSACTION
	IF exists(SELECT * FROM CartAndWishList WHERE userId=@userId and BookId=@BookId)
	BEGIN
       select @Count=Count from CartAndWishList where userId=@userId and BookId=@BookId
	   SET @Count = @Count + 1
	   UPDATE CartAndWishList SET Count = @Count where userId=@userId and BookId=@BookId
	 END
	ELSE
	BEGIN
       INSERT INTO CartAndWishList (userId, BookID, Count, IsCart, IsWishList) values (@userId, @BookId, 1, 'Y','N')
	END 
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

   -- Transaction uncommittable
    IF (XACT_STATE()) = -1
      ROLLBACK TRANSACTION
 
-- Transaction committable
    IF (XACT_STATE()) = 1
      COMMIT TRANSACTION
END CATCH
