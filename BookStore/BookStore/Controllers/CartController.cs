using ManagerLayer.Interfaces;
using ManagerLayer.Managers;
using ModelsLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace BookStore.Controllers
{
    public class CartController : Controller
    {
        private readonly ICartManager cartManager = new CartManager();
        public CartController()
        {

        }
        //GET: Cart
        public ActionResult GetAllCart()
        {
            return View();
        }

        [HttpPost]
        public JsonResult AddToCart(Cart cart)
        {
            try
            {
                var result = this.cartManager.AddToCart(cart);
                if (result != null)
                {
                    return Json(new { status = true, Message = "Book added to cart", Data = result });
                }
                else
                {
                    return Json(new { status = false, Message = "Book not added to cart", Data = result });
                }
            }
            catch (Exception)
            {
                return ViewBag.Message = "sucessfully";
            }
        }

        [HttpGet]
        public ActionResult GetCart()
        {
            try
            {
                var result = this.cartManager.GetCart();
                ViewBag.Message = "";
                return View(result);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //[HttpPost]
        //public JsonResult RemoveFromCart(int cartId, int userId)
        //{
        //    try
        //    {
        //        var result = this.cartManager.RemoveFromCart(cartId, userId);
        //        if (result != null)
        //        {
        //            return Json(new { status = true, Message = "Book added to cart", Data = result });
        //        }
        //        else
        //        {
        //            return Json(new { status = false, Message = "Book not added to cart", Data = result });
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        return ViewBag.Message = "sucessfully";
        //    }
        //}        
    }
}