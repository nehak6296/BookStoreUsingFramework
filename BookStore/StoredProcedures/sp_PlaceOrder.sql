create procedure sp_PlaceOrder(
	@UserId int,
	@CartId int
)as
begin
	begin try
		if exists(select UserId from [User] where UserId=@UserId)
		begin
			if exists (select CartId from [Cart] where CartId=@CartId)
			begin 
				insert into [Orders] values (@UserId,@CartId)				
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
end