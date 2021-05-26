Create procedure [sp_UpdateBook]
(
	@BookId int,
	@BookName varchar(50),
	@Author varchar(50),
	@Details varchar(255),
	@Price money,
	@Image varchar(50),
	@Quantity int
)
as
begin
	begin try
	if exists (select * from Book where BookId=@BookId)
		update Book
		set BookName=@BookName,
		Author=@Author,
		Details=@Details,
		Price=@Price,
		Image=@Image,
		Quantity=@Quantity
		where BookId=@BookId
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
