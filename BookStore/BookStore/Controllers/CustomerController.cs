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
    [Authorize]
    public class CustomerController : Controller
    {
        private readonly ICustomerManager customerManager;
        public CustomerController(ICustomerManager customerManager)
        {
            this.customerManager = customerManager;
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
        [HttpGet]
        public ActionResult GetAllCustomerDetails(int userId)
        {
            try
            {
                //int UserId = 1;
                var result = this.customerManager.GetAllCustomerDetails(userId);
                if (result != null)
                {
                    return Json(new { status = true, Message = "Customers details fetched successfully ..!!!", Data = result },JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { status = false, Message = "No customer present..!!", Data = result }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
                //return ViewBag.Message = "";
            }
        }

        [HttpPost]
        public JsonResult UpdateCustomerDetails(Customer customer)
        {
            try
            {
                var result = this.customerManager.UpdateCustomerDetails(customer);
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