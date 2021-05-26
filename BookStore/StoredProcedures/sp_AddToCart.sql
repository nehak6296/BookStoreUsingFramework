
create procedure [sp_AddToCart](
	@UserId int,
	@BookId int,
	@CartBookQuantity int 
)
as
begin	
	begin try
		insert into [Cart] values(@UserId,@BookId,@CartBookQuantity)
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