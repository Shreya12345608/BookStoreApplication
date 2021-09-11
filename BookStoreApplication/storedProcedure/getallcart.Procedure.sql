Create procedure spGetallCart
(
        @userId int
)
AS
DECLARE @status INT
BEGIN TRY
BEGIN TRANSACTION
	IF exists(SELECT * FROM CartAndWishList WHERE userId=@userId)
	BEGIN
	set @status = 1
		select * from CartAndWishList join userRegistration ON CartAndWishList.userId = @userId 
		join Books ON CartAndWishList.userId = @userId
		where (CartAndWishList.BookId = Books.BookId and CartAndWishList.userId = userRegistration.userId and CartAndWishList.IsCart = 'Y')
	 END
	ELSE
	BEGIN
       set @status = 0
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
