Create Procedure [dbo].[sp_GetAllCustomerDetails]  (
	@UserId int
)
as  
begin  
   begin try
		if exists (select UserId from Customer where UserId = @UserId)
	begin
		select [User].UserId, FirstName, LastName,Email,Password
		from [User] inner join Customer on [User].UserId = Customer.CustomerId 
		where [User].UserId = @UserId
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

select * from [User]