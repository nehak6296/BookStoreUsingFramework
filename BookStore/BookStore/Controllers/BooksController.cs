using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using ManagerLayer.Interfaces;
using ManagerLayer.Managers;
using Microsoft.AspNetCore.Http;
using ModelsLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookStore.Controllers
{   
    //[Authorize]
    public class BooksController : Controller
    {
       private readonly IBookManager booksManager ;
        public BooksController(IBookManager booksManager)
        {
            this.booksManager = booksManager;
        }
        //GET: Books
        public ActionResult GetAllBooks()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpGet]
        public ActionResult GetAllBooks(Books book)
        {
            try
            {
                var result = this.booksManager.GetAllBooks();
                ViewBag.Message = "";
                return View(result);
            }
            catch (Exception)
            {
                return ViewBag.Message = "sucessfully";
            }
        }       
    }
}