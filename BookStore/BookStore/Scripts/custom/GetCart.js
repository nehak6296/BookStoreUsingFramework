
function increment() {
    document.getElementById('demoInput').stepUp();
}
function decrement() {
    document.getElementById('demoInput').stepDown();
}
function Remove_Cart(CartId) {
    var removeFromCart = "remove-".concat(CartId);
    var requestObject = {};
    requestObject.CartId = CartId;
   
    $.ajax({
        type: "POST",
        url: 'https://localhost:44375/Cart/RemoveFromCart',
        data: JSON.stringify(requestObject),
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success:
            function () {
                //Onclick REMOVE button hide AddToCart button
                var RemoveButton = document.getElementById('placeid');
                RemoveButton.style.display = "none";
                window.location.reload();
            },
        error: function () {
            alert("Error while REMOVING data");
        }
    });
}


function place_order() {
    getCustomers();
    var place_order = document.getElementById('placeid');
    place_order.style.display = "none";

    var form_name = document.getElementById('form-div-cart');
    form_name.style.display = "block";
}

var customerList ;
function getCustomers() {
    var customers = {};
    var userId = 1;
    //int userId = ;
    //console.log(JSON.stringify(customers));
    $.ajax({
        type: "GET",
        url: 'https://localhost:44375/Customer/GetAllCustomerDetails?UserId=1',
      //  data: userId,
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: function (response) {            
            console.log("response=" + response);
            customerList = response.Data;
           //continue_order()
        } ,
        error: function () {
            alert("Error while inserting data");
        }
    });
}
function continue_order() {
    getCustomers()
    var isPresent = false;
    var customersObject = {};
    var getSelectedValue = document.querySelector('input[name="type"]:checked').value;

    customersObject.Name = $("#Name").val();
    customersObject.PhoneNumber = $("#Num").val();
    customersObject.Pincode = $("#Pin").val();
    customersObject.Locality = $("#Locality").val();
    customersObject.Address = $("#Address").val();
    customersObject.City = $("#City").val();
    customersObject.Landmark = $("#Landmark").val();
    customersObject.type = getSelectedValue;

    for (i = 0; i < customerList.length; i++) {
        if (customerList[i].Name == customersObject.Name && customerList[i].PhoneNumber == customersObject.PhoneNumber) {
            isPresent = true;
            customersObject.CustomerId = customerList[i].CustomerId;
        }
    } 
    

    if (isPresent === false) {
        $.ajax({
            type: "POST",
            url: 'https://localhost:44375/Customer/AddCustomerDetails',
            data: JSON.stringify(customersObject),
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            success: function () {
                document.getElementById("cont-id").style.display = "none";                
                document.getElementById('oder-details').style.display = "block";                
            },
            error: function () {
                alert("Error while inserting data");
            }
        });
    } else {
        $.ajax({
            type: "POST",
            url: 'https://localhost:44375/Customer/UpdateCustomerDetails',
            data: JSON.stringify(customersObject),
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            success: function () {
                var place_order = document.getElementById('cont-id');
                place_order.style.display = "none";
                var Order_details = document.getElementById('oder-details');
                Order_details.style.display = "block";
            },
            error: function () {
                alert("Error while inserting data");
            }
        });
    }   
}

function checkout() {
    var requestObject = {};
    requestObject.cartId = 24;
    requestObject.userId = 1;
    $.ajax({
        type: "POST",
        url: 'https://localhost:44375/Orders/PlaceOrder',
        data: JSON.stringify(requestObject),
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success:
            console.log("OrderPlaced"),
        error: function () {
            alert("Error ");
        }
    });
}