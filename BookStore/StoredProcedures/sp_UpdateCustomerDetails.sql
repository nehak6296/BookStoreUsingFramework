Create procedure [dbo].[sp_UpdateCustomerDetails](
	@CustomerId int,
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
		if exists(select CustomerId from [Customer] where CustomerId=@CustomerId)
		Update [Customer] 
		set Name=@Name ,
			PhoneNumber=@PhoneNumber,
			Address=@Address,
			Locality=@Locality,
			Landmark=@Landmark,
			Pincode=@Pincode,
			City=@City,
			Type=@Type 
		where CustomerId=@CustomerId
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