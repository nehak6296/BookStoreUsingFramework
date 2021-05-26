Alter Procedure [dbo].[sp_DeleteBook]
(
	@BookId int
)
as  
begin  
   begin try
	if exists(select * from Book where BookId=@BookId)
		delete from Book where BookId=@BookId
	end try
	begin catch
		 SELECT
    ERROR_NUMBER() AS ErrorNumber,
    ERROR_STATE() AS ErrorState,
    ERROR_PROCEDURE() AS ErrorProcedure,
    ERROR_LINE() AS ErrorLine,
    ERROR_MESSAGE() AS ErrorMessage;
	end catch 
End
