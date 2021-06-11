USE [BookStore]
GO
/****** Object:  StoredProcedure [dbo].[sp_GetAllCart]    Script Date: 11-06-2021 09:50:06 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
alter Procedure [dbo].[sp_GetAllRoles]  
	(
	
	@Email varchar(255)
	)
as  
begin  
   begin try
		if exists (select Email from [User] where Email=@Email )
		begin
		select [Roles].Role  from [User] inner join  [Roles] on [User].UserId=Roles.UserId
			where Email=@Email
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