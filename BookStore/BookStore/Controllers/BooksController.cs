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
        [HttpPost]
        public ActionResult UploadImage(int BookId, HttpPostedFileBase image)
        {
            try
            {
                var imageUpload = CloudImageLink(image);
                bool result = this.booksManager.UploadImage(BookId, imageUpload);
                if (result == true)
                {
                    return Json(new { status = true, Message = "Image added " ,Data=result});
                }
                else
                {
                    return Json(new { status = false, Message = "image not added " });
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private string CloudImageLink(HttpPostedFileBase file)
        {
            if (file == null)
            {
                return null;
            }
            var filepath = file.InputStream;
            string uniquename = Guid.NewGuid().ToString() + "_" + file.FileName;
            Account account = new Account("dywhtr8hk", "371652781151548", "1aVBjz0E-GdsHlguqwgk_spEyCo");
            Cloudinary cloud = new Cloudinary(account);
            var uploadparam = new ImageUploadParams()
            {
                File = new FileDescription(uniquename, filepath)
            };
            var uploadResult = cloud.Upload(uploadparam);
            return uploadResult.Url.ToString();
        }
    }
}