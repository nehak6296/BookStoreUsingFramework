function Remove_WishList(WishListId) {
    var removeFromCart = "remove-".concat(WishListId);
    var requestObject = {};
    requestObject.WishListId = WishListId;

    $.ajax({
        type: "POST",
        url: 'https://localhost:44375/WishList/RemoveFromWishList',
        data: JSON.stringify(requestObject),
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: function () {
           
            console.log("REMOVED from WishList")
        },
           
        error: function () {
            alert("Error while REMOVING data");
        }
    });
}
