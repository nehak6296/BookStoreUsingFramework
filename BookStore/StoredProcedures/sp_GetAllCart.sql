create Procedure [dbo].[sp_GetAllCart]  (
	@UserId int
)
as  
begin  
   begin try
		if exists (select * from Cart where UserId=@UserId)
		begin
		select * from Cart
		end
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
