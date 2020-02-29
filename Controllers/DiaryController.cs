using DigitalDiary.Models;
using DigitalDiary.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DigitalDiary.Controllers
{
    public class DiaryController : Controller
    {
        //IRepository<Diary> DiaryRepo = new DiaryRepository();
        DiaryRepository DiaryRepo = new DiaryRepository();
        // GET: Home
        public ActionResult Index()
        {
            int id = 1000;
            return View(DiaryRepo.GetDiaries(id));
        }
        [HttpGet]
        public ActionResult Details(int id)
        {
            return View(DiaryRepo.Get(id));

        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Diary d)
        {
            DiaryRepo.Insert(d);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            return View(DiaryRepo.Get(id));
        }

        [HttpPost]
        public ActionResult Edit(Diary d)
        {
            DiaryRepo.Update(d);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            return View(DiaryRepo.Get(id));
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult ConfirmDelete(int id)
        {
            DiaryRepo.Delete(id);
            return RedirectToAction("Index");
        }
    }
}