create procedure [sp_AddBook]
(
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
	 Insert into [Book] values(@BookName,@Author,@Details,@Price,@Image,@Quantity)  
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

