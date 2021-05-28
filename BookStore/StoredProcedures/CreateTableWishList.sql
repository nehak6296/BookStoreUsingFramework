create table WishList
(
	WishListId int IDENTITY(1,1) PRIMARY KEY,
	UserId int,
	BookId int,
	WishListQuantity int,
	IsWishListed bit not null
	FOREIGN KEY (UserId) REFERENCES [User](UserId),
	FOREIGN KEY (BookId) REFERENCES [Book](BookId)
)

select * from WishList