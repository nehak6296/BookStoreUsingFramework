
create procedure [sp_UpdateCartBookQuantity]
(
	@CartId int	,
	@UserId int,
	@BookId int,
	@CartBookQuantity int,
	@BookQuantity int
)
as
begin	
	begin try
		if exists (select BookId , UserId from Cart where BookId = @BookId and UserId = @UserId )
				begin
					
					declare @count int
					select @count = @CartBookQuantity + @CartBookQuantity  from Cart where BookId = @BookId and UserId = @UserId

					if exists (select BookId from Book where BookId = @BookId )
					begin
						update cart
						set @CartBookQuantity = @count 
						where BookId = @BookId and UserId = @UserId 
						select * from Book inner join Cart on Book.BookId = Cart.BookId
						where UserId = @UserId 
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