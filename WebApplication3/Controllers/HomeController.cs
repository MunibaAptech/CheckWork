using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication3.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Category()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Category(tbl_Category category)
        {
            WebAppEntities db = new WebAppEntities();
            db.tbl_Category.Add(category);
            db.SaveChanges();
            return View();
        }
        public ActionResult ShowList()
        {
            WebAppEntities db = new WebAppEntities();
            var list = db.tbl_Category.ToList();
            return View(list);
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            WebAppEntities db = new WebAppEntities();
            var category = db.tbl_Category.Find(id);
            return View(category);
        }
        [HttpPost]
        public ActionResult Edit(tbl_Category category)
        {
            WebAppEntities db = new WebAppEntities();
            db.Entry(category).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("ShowList");

        }

        public ActionResult Delete(int cateegory_id)
        {
            WebAppEntities db = new WebAppEntities();
            var category = db.tbl_Category.Find(cateegory_id);
            db.tbl_Category.Remove(category);
            db.SaveChanges();
            return RedirectToAction("ShowList");


        }









        //[HttpGet]
        //public ActionResult Edit(int id)
        //{
        //    WebAppEntities db = new WebAppEntities();
        //    var category = db.tbl_Category.Find(id);
        //    return View(category);
        //}
        //[HttpPost]
        //public ActionResult Edit(tbl_Category cat)
        //{
        //    WebAppEntities db = new WebAppEntities();
        //    db.Entry(cat).State = System.Data.Entity.EntityState.Modified;
        //    db.SaveChanges();

        //    return RedirectToAction("ShowList");
        //}

        //public ActionResult Delete(int category_id)
        //{
        //    WebAppEntities db = new WebAppEntities();
        //    var category = db.tbl_Category.Find(category_id);
        //    db.tbl_Category.Remove(category);
        //    db.SaveChanges();
        //    return RedirectToAction("ShowList");
        //}
    }
}