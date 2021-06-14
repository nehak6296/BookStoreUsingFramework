using ManagerLayer.Interfaces;
using ModelsLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookStore.Controllers
{
    [Authorize(Roles = "Admin,Customer")]
    public class OrdersController : Controller
    {
        private readonly IOrdersManager ordersManager;
        public OrdersController(IOrdersManager ordersManager)
        {
            this.ordersManager = ordersManager;
        }
        // GET: Orders
        public ActionResult PlaceOrder()
        {
            return View();
        }

        [HttpPost]
        public ActionResult PlaceOrder(Orders orders)
        {
            try
            {
                var result = this.ordersManager.PlaceOrder(orders);
                ViewBag.Message = "";
                return View(result);
            }           
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}