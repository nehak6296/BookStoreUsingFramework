using ManagerLayer.Interfaces;
using ManagerLayer.Managers;
using ModelsLayer;
using RepositoryLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace BookStore.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserManager userManager= new UserManager();
        public UserController()
        {
        }
        
        public ActionResult Register()
        {
            return View();
        }     
        [HttpPost]
        public ActionResult Register(Registration register)
        {
            try
            {
                var result = this.userManager.RegisterUser(register);
                ViewBag.Message = "User registered successfully";
                return View();                
            }
            catch(Exception)
            {
                return ViewBag.Message = "User registered unsuccessfully";
            }
        }
    }
}