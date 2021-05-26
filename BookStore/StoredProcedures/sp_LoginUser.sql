CREATE procedure [dbo].[sp_LoginUser]
(
        @Email varchar(255),
        @Password varchar(50)
)
as
begin
	begin try
		declare @status int
		if exists(select * from [User] where @Email=@Email and @Password=@Password)
			set @status=1
		else
			set @status=0
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
GO
