CREATE PROCEDURE spGetAllBooks
AS BEGIN
BEGIN TRY
	SELECT *  FROM Books;
END TRY
BEGIN CATCH
	PRINT 'no book are abilable in table.Please Add book'
END CATCH
END;
