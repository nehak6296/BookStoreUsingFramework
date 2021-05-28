Create procedure [dbo].[sp_AddCustomerDetails]
(
@UserId int,
@Name varchar,
@PhoneNumber int ,
@Address varchar,
@Locality varchar,
@Landmark varchar,
@Pincode int,
@City varchar,
@Type varchar
)
as
begin
	begin try
	 Insert into [Customer] values(@UserId,@Name,@PhoneNumber,@Address,@Locality,@Landmark,@Pincode,@City,@Type)  
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

