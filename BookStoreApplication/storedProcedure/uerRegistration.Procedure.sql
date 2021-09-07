CREATE PROCEDURE [dbo].[spuserRegistration]

	@fullName varchar(100),
	@userEmail varchar(100),
	@Password varchar(50),
	@PhoneNumber bigint
AS
	Insert into userRegistration(fullName, userEmail, password, PhoneNumber)
	values (@fullName, @userEmail, @password, @PhoneNumber);
RETURN 0
