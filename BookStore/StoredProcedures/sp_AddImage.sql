create procedure sp_AddImage(
	@BookId int,	
	@Image varchar(50)
)
as
begin
	begin try
	if exists (select * from Book where BookId=@BookId)
		update Book
		set Image=@Image		
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
select * from [User]