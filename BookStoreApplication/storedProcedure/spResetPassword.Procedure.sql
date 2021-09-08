
CREATE PROCEDURE spResetPassword
(             
                @userEmail      VARCHAR(100),
                @newPassword      VARCHAR(50)
          
)
AS
BEGIN 

       UPDATE userRegistration SET Password=@newPassword WHERE userEmail=@userEmail
   
END



