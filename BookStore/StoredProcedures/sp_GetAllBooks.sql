Create Procedure [dbo].[sp_GetAllBooks]  
as  
begin  
   begin try
		select * from Book
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
