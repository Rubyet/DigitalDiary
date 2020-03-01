using DigitalDiary.Models;
using DigitalDiary.Repository;
using System;
using System.Collections.Generic;
using System.IO;
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
            var id = Int32.Parse(Session["UserID"].ToString());
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
        public ActionResult Create(Diary d, HttpPostedFileBase file)
        {
            d.CreatedAt = DateTime.Now;
            d.ModifiedAt = DateTime.Now;
            d.UserID = Int32.Parse(Session["UserID"].ToString());
            if (file != null && file.ContentLength > 0)
            {
                try
                {
                    string path = Path.Combine(Server.MapPath("~/Content/Images"),
                                               Path.GetFileName(file.FileName));
                    file.SaveAs(path);
                    TempData["Message"] = "File uploaded successfully";
                    d.Image = file.FileName;
                }
                catch (Exception ex)
                {
                    TempData["Message"] = "ERROR:" + ex.Message.ToString();
                }
            }
            //return Content(d.ID+" "+d.CreatedAt + " " +d.ModifiedAt + " " +d.Heading + " " +d.DailyContent + " " +d.Image + " " +d.UserID);
            DiaryRepo.Insert(d);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            return View(DiaryRepo.Get(id));
        }

        [HttpPost]
        public ActionResult Edit(Diary d, HttpPostedFileBase file)
        {
            d.ModifiedAt = DateTime.Now;
            if (file != null && file.ContentLength > 0)
            {
                try
                {
                    string path = Path.Combine(Server.MapPath("~/Content/Images"),
                                               Path.GetFileName(file.FileName));
                    file.SaveAs(path);
                    TempData["Message"] = "File uploaded successfully";
                    d.Image = file.FileName;
                }
                catch (Exception ex)
                {
                    TempData["Message"] = "ERROR:" + ex.Message.ToString();
                }
            }
            //return Content(d.ID+" "+d.CreatedAt + " " +d.ModifiedAt + " " +d.Heading + " " +d.DailyContent + " " +d.Image + " " +d.UserID);
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