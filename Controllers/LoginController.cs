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
            try
            {
                var login = context.Set<User>().SingleOrDefault(x => x.Name == u.Name && x.Password == u.Password);
                Session["UserID"] = login.ID;
                return RedirectToAction("Index", "Diary");
            }
            catch (Exception e)
            {

                TempData["Error"] = "Login Attempt Failed";
                return RedirectToAction("Index");
            }

        }
    }
}