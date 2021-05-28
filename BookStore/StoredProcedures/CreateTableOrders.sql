create table Orders(
	OrderId int IDENTITY(1,1) PRIMARY KEY,
	UserId int foreign key references [User](UserId),
	CartId int foreign key references [Cart](CartId)
);
select * from Orders