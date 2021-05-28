Create procedure [dbo].[sp_AddToWishList](

@UserId int,
@BookId int,
@Quantity int
)
as
begin try
	if exists (select @BookId from Book where BookId = @BookId and Quantity>0)
		begin
			insert into [WishList] values(@UserId,@BookId,@Quantity);
			select * from Book inner join [WishList] on Book.BookId = WishList.BookId
			where UserId = @UserId
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

