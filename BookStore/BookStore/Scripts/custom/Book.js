////function AddToCart(bookId) {

////    var addToCartId = "cartBtn-".concat(bookId);
////    var addToWishId = "wishBtn-".concat(bookId);
////    var addedToCart = "addedCartBtn-".concat(bookId);

////    //Onclick AddToCart button hide AddToCart button
////    var AddToCartButton = document.getElementById(addToCartId);
////    AddToCartButton.style.display = "none";   

////    //Onclick AddToCart button hide WishList button
////    var AddToWishListButton = document.getElementById(addToWishId);
////    AddToWishListButton.style.display = "none";

////    //Onclick AddToCart button show AddedToCart button
////    var AddedToCartButton = document.getElementById(addedToCart);
////    AddedToCartButton.style.display = "block"
////}

////function AddToWishList(bookId) {
////    var addToWishId = "wishBtn-".concat(bookId);
////    var x = document.getElementById(addToWishId);
////    x.style.display = "none";
////}



function AddToCart(bookId) {

    var addToCartId = "cartBtn-".concat(bookId);
    var addToWishId = "wishBtn-".concat(bookId);
    var addedToCart = "addedCartBtn-".concat(bookId);

    var requestObject = {};
    requestObject.UserId = 1;
    requestObject.BookId = bookId;
    requestObject.CartBookQuantity = 1;
    console.log(JSON.stringify(requestObject));
    $.ajax({
        type: "POST",
        url: 'https://localhost:44375/Cart/AddToCart',
        data:  JSON.stringify(requestObject),
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: function () {
            //Onclick AddToCart button hide AddToCart button
            var AddToCartButton = document.getElementById(addToCartId);
            AddToCartButton.style.display = "none";

            //Onclick AddToCart button hide WishList button
            var AddToWishListButton = document.getElementById(addToWishId);
            AddToWishListButton.style.display = "none";

            //Onclick AddToCart button show AddedToCart button
            var AddedToCartButton = document.getElementById(addedToCart);
            AddedToCartButton.style.display = "block"
            // alert("Data has been added successfully.");  

        },
        error: function () {
            alert("Error while inserting data");
        }
    });
}

//function AddToWishList(bookId) {
//    var addToWishId = "wishBtn-".concat(bookId);
//    var x = document.getElementById(addToWishId);
//    x.style.display = "none";
//}



