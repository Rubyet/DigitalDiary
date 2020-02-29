using DigitalDiary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DigitalDiary.Controllers
{
    public class LoginController : Controller
    {
        DigitalDiaryContext context = new DigitalDiaryContext();
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(User u)
        {
            //var login = context.Set<User>().Where(x => x.Name == u.Name && x.Password == u.Password);
            var login = context.Users.Where(x => x.Name == u.Name && x.Password == u.Password);
            return Content(login.ToString());
            if (login != null)
            {
                //Session["UserID"] = login.;
                return RedirectToAction("Index", "Diary");
            }
            else
            {
                ViewBag.Error = "Login Attempt Failed";
                return RedirectToAction("Login");
            }

        }
    }
}