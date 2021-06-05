
function increment() {
    document.getElementById('demoInput').stepUp();
}
function decrement() {
    document.getElementById('demoInput').stepDown();
}

function place_order() {
    var place_order = document.getElementById('placeid');
    place_order.style.display = "none";

    var form_name = document.getElementById('form-div-cart');
    form_name.style.display = "block";
}



//function continue_order() {

//    var requestObject = {};
//    requestObject.Name = "Mansi";
//    requestObject.PhoneNumber = 8879218009;
//    requestObject.Pincode = 400058;
//    requestObject.Locality = "andheri";
//    requestObject.Address = "andheri-west";
//    requestObject.AddressType = "home";
//    requestObject.City = "mumbai";
//    requestObject.Landmark = "bmwshowroom";
//    console.log(JSON.stringify(requestObject));
//    $.ajax({
//        type: "POST",
//        url: 'https://localhost:44375/Customer/AddCustomerDetails',
//        data: JSON.stringify(requestObject),
//        dataType: "json",
//        contentType: "application/json; charset=utf-8",
//        success: function () {
//            var place_order = document.getElementById('cont-id');
//            place_order.style.display = "none";
//        },
//        error: function () {
//            alert("Error while inserting data");
//        }
//    });
//}