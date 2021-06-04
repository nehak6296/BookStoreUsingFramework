USE [BookStore]
GO
/****** Object:  StoredProcedure [dbo].[sp_GetAllCart]    Script Date: 03-06-2021 05:01:58 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER Procedure [dbo].[sp_GetAllCart]  (
	@UserId int
)
as  
begin  
   begin try
		if exists (select UserId from Cart where UserId=@UserId)
		begin
		select Book.BookId as BookId, Book.BookName as BookName,Book.Author as Author,Book.Price as Price,Book.Image as Image,
		Cart.CartBookQuantity as CartBookQuantity,
		Cart.CartId as CartId from Book inner join  Cart on Book.BookId=Cart.BookId
		where UserId=@UserId	
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
select * from [Cart]

select * from [Cart]