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
    [Authorize(Roles = "Admin,Customer")]
    public class WishListController : Controller
    {
        private readonly IWishListManager wishListManager;
        public WishListController(IWishListManager wishListManager)
        {
            this.wishListManager = wishListManager;
        }
        // GET: WishList
        
        [HttpGet]
        public ActionResult GetWishList()
        {
            try
            {
                var result = this.wishListManager.GetWishList();
                ViewBag.Message = "";
                return View(result);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPost]
        public JsonResult AddToWishList(WishList wishList)
        {
            try
            {
                var result = this.wishListManager.AddToWishList(wishList);
                if (result != null)
                {
                    return Json(new { status = true, Message = "Book added to wishList", Data = result });
                }
                else
                {
                    return Json(new { status = false, Message = "Book not added to wishList", Data = result });
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
               //return ViewBag.Message = "sucessfully";
            }
        }
        [HttpPost]
        public JsonResult RemoveFromWishList(int wishListId)
        {
            try
            {
                var result = this.wishListManager.RemoveFromWishList(wishListId);
                if (result >0)
                {
                    return Json(new { status = true, Message = "Book removed from wishList", Data = result });
                }
                else
                {
                    return Json(new { status = false, Message = "can't remove from wishList", Data = result });
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);                
            }
        }
    }
}