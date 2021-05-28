create table Customer
(
CustomerId int primary key identity(1,1),
UserId int not null,
Name varchar(50) not null,
PhoneNumber int not null,
Address varchar(255) not null,
Locality varchar(50),
Landmark varchar(50),
Pincode int not null,
City varchar(50) not null,
Type varchar(50) not null,
Foreign key (UserId) references [User](UserId)
)