using ManagerLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookStore.Controllers
{
    public class OrdersController : Controller
    {
        private readonly IOrdersManager ordersManager;
        public OrdersController(IOrdersManager ordersManager)
        {
            this.ordersManager = ordersManager;
        }
        // GET: Orders
        public ActionResult PlaceOrder(int userId,int cartId)
        {
            try
            {
                var result = this.ordersManager.PlaceOrder(userId,cartId);
                if (result >=1)
                {
                    return View();
                   // return Json(new { status = true, Message = "Order Placed", Data = result });
                }
                else
                {
                    return Json(new { status = false, Message = "Sorry order not placed", Data = result });
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}