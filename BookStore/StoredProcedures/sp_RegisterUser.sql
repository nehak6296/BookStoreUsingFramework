Create procedure [dbo].[sp_RegisterUser]  
(  
   @FirstName varchar (50), 
   @LastName varchar (50), 
   @Email varchar (255),  
   @Password varchar (50)  
)  
as  
begin 
	begin try
	 Insert into [User] values(@FirstName,@LastName,@Email,@Password)  
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
