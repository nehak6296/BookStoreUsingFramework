create table Roles(
RoleId int primary key identity,
UserId int foreign key references [User](UserId),
Role varchar(50) not null
)