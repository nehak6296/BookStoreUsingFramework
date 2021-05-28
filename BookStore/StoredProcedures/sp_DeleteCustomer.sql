Create procedure [dbo].[sp_DeleteCustomer](
	@CustomerId int	
)
as
begin	
	begin try
		if exists(select CustomerId from [Customer] where CustomerId=@CustomerId)
		delete from [Customer] where CustomerId=@CustomerId
	end try
	begin catch
		 SELECT
    ERROR_NUMBER() AS ErrorNumber,
    ERROR_STATE() AS ErrorState,
    ERROR_PROCEDURE() AS ErrorProcedure,
    ERROR_LINE() AS ErrorLine,
    ERROR_MESSAGE() AS ErrorMessage;
	end catch
end