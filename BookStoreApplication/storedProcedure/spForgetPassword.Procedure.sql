

Create procedure [spforgetPassword]

(
        @userEmail varchar(50)
)
as
declare @status int

BEGIN TRY
if exists(select * from userRegistration where userEmail=@userEmail )
      set @status=1
else
       set @status=0
select @status
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
  END CATCH
GO