using RecordBook.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RecordBook.Controllers
{
    public class RegisterController : Controller
    {
        // GET: Register
        RecordBookEntities db = new RecordBookEntities();
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(User user)
        {
            if (!ModelState.IsValid)
            {
                return View("Index");
            }
            db.User.Add(user);
            db.SaveChanges();
            return RedirectToAction("Login", "User");

        }
    }
}