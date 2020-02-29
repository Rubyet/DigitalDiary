using DigitalDiary.Models;
using DigitalDiary.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DigitalDiary.Controllers
{
    public class UserController : Controller
    {
        IRepository<User> userRepo = new UserRepository();
        
        public ActionResult Index()
        {
            return View(userRepo.GetAll());
        }
        [HttpGet]
        public ActionResult Details(int id)
        {
            return View(userRepo.Get(id));

        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(User u)
        {
            userRepo.Insert(u);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            return View(userRepo.Get(id));
        }

        [HttpPost]
        public ActionResult Edit(User u)
        {
            userRepo.Update(u);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            return View(userRepo.Get(id));
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult ConfirmDelete(int id)
        {
            userRepo.Delete(id);
            return RedirectToAction("Index");
        }

    }
}