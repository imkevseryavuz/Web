using _SWCRM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;
using System.Net;

namespace _SWCRM.Controllers
{
    public class CategoriesController : Controller
    {
        private SWCRMEntities db = new SWCRMEntities();

        // GET: Categories
        public ActionResult Index(string aranacakKelime)
        {
            var categories = from e in db.Categories
                            select e;
            if (!String.IsNullOrEmpty(aranacakKelime))
            {
                categories = categories.Where(a => a.Name.Contains(aranacakKelime));
            }
            return View(categories);

            var category = db.Categories.Include(cat => cat.Situation);
            return View(category.ToList());
        }


        public ActionResult CategoryDetails(int Id = 0)
        {
            Category category = db.Categories.Find(Id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }


        public ActionResult CategoryCreate()
        {
            ViewBag.StatusId = new SelectList(db.Situations, "StatusId", "StatusId");
            return View();
        }

        //

        [HttpPost]
        public ActionResult CategoryCreate(Category category)
        {
            if (ModelState.IsValid)
            {
                db.Categories.Add(category);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.StatusId = new SelectList(db.Situations, "StatusId", "Status", category.Situation);
            return View(category);
        }


        public ActionResult Edit(int Id = 0)
        {
            Category category = db.Categories.Find(Id);
            if (category == null)
            {
                return HttpNotFound();
            }
            ViewBag.StatusId = new SelectList(db.Situations, "StatusId", "Status", category.Situation);
            return View(category);
        }

        //
        // POST: /Categories/Edit/5
        [HttpPost]
        public ActionResult Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                db.Entry(category).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.StatusId = new SelectList(db.Situations, "StatusId", "Status", category.Situation);
            return View(category);
        }


        public ActionResult Delete(int Id = 0)
        {
            Category category = db.Categories.Find(Id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        //
        // POST: /Categories/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int Id)
        {
            Category category = db.Categories.Find(Id);
            db.Categories.Remove(category);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }



    }
}