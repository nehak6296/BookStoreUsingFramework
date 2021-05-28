Create procedure [dbo].[sp_RemoveFromWishList](
	@WishListId int	
)
as
begin	
	begin try
		if exists(select WishListId from [WishList] where WishListId=@WishListId)
		delete from WishList where WishListId=@WishListId
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