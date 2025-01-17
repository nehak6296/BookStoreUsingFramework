﻿using ManagerLayer.Interfaces;
using ManagerLayer.Managers;
using ModelsLayer;
using RepositoryLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace BookStore.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserManager userManager;
        public UserController(IUserManager userManager)
        {
            this.userManager = userManager;
        }
       
        public ActionResult Register()
        {            
            return View();
        }

        public ActionResult Login()
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
                // return View();
                return RedirectToAction("Login");
            }
            catch(Exception)
            {
                return ViewBag.Message = "User registration unsuccessfull";
            }
        }        
        [HttpPost]
        public ActionResult Login(Login login ,string ReturnUrl)
        {
            try
            {
                if (IsValid(login))
                {
                    FormsAuthentication.SetAuthCookie(login.Email,false);
                    ViewBag.Message = "User Logged in successfully";
                    return Redirect(ReturnUrl);
                }
                else
                {
                    return View();
                }                               
            }
            catch (Exception)
            {
                return ViewBag.Message = "User Login unsuccessfull";
            }
        }

        public bool IsValid(Login login)
        {
            return this.userManager.LoginUser(login);
        }

    }
}