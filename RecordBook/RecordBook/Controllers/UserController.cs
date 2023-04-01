using RecordBook.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RecordBook.Models;

namespace RecordBook.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        RecordBookEntities db = new RecordBookEntities();
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(User user)
        {
            var informations = db.User.FirstOrDefault(x => x.Email == user.Email && x.Password == user.Password);
            if (informations != null) //gelen değerler boş değilse
            {
                return RedirectToAction("Index", "Admin");
            }
            else
            {
                return RedirectToAction("Login", "User");

            }

        }
    }
}