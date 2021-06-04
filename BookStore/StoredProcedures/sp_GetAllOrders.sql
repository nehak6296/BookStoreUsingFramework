create Procedure [dbo].[sp_GetAllOrders]  (
	@UserId int,
	@CartId int
)
as  
begin  
   begin try
		if exists (select UserId from [Cart] where UserId=@UserId)
		begin
		if exists (select UserId from [Orders] where UserId = @UserId)
		begin
			select Orders.UserId, Orders.CartId
			from Orders inner join Cart on Orders.CartId = Cart.CartId 
			where Orders.UserId = @UserId
		end
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
