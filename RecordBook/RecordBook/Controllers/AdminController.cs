using RecordBook.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace RecordBook.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        RecordBookEntities db = new RecordBookEntities();
        public ActionResult Index()
        {
            var degerler = db.User.ToList();
            return View(degerler);
        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "User");
        }
        public ActionResult DeleteUser(int id)
        {
            var delete = db.User.Find(id);
            db.User.Remove(delete);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult NewUser()
        {
            return View();
        }
        [HttpPost]
        public ActionResult NewUser(User t)
        {
            db.User.Add(t);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult BringUser(int id)
        {
            var bring = db.User.Find(id);
            return View("BringUser", bring);
        }
        public ActionResult UpdateUser(User p)
        {
            var uye = db.User.Find(p.Id);
            uye.Name = p.Name;
            uye.Surname = p.Surname;
            uye.Email = p.Email;

            uye.Password = p.Password;
            uye.Address = p.Address;
            uye.Phone = p.Phone;


            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}