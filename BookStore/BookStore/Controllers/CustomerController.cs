using ManagerLayer.Interfaces;
using ManagerLayer.Managers;
using ModelsLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookStore.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerManager customerManager = new CustomerManager();
        public CustomerController()
        {

        }
        // GET: CustomerDetails

        [HttpPost]
        public JsonResult AddCustomerDetails(Customer customer)
        {
            try
            {
                var result = this.customerManager.AddCustomerDetails(customer);
                if (result != null)
                {
                    return Json(new { status = true, Message = "Customer added..!!!", Data = result });
                }
                else
                {
                    return Json(new { status = false, Message = "Customer not added...!!", Data = result });
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
                //return ViewBag.Message = "sucessfully";
            }
        }
    }
}