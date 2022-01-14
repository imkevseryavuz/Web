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
    public class BrandsController : Controller
    {
        private SWCRMEntities db = new SWCRMEntities();

        // GET: Brands
        public ActionResult Index(string aranacakKelime)
        {
            var brands = from e in db.Brands
                            select e;
            if (!String.IsNullOrEmpty(aranacakKelime))
            {
                brands = brands.Where(a => a.Name.Contains(aranacakKelime));
            }
            return View(brands);

            var brand = db.Brands.Include(brn => brn.Situation);
            return View(brand.ToList());
        }


        public ActionResult BrandDetails(int Id = 0)
        {
            Brand brand = db.Brands.Find(Id);
            if (brand == null)
            {
                return HttpNotFound();
            }
            return View(brand);
        }


        public ActionResult BrandCreate()
        {
            ViewBag.StatusId = new SelectList(db.Situations, "StatusId", "StatusId");
            return View();
        }

        //

        [HttpPost]
        public ActionResult BrandCreate(Brand brand)
        {
            if (ModelState.IsValid)
            {
                db.Brands.Add(brand);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.StatusId = new SelectList(db.Situations, "StatusId", "Status", brand.Situation);
            return View(brand);
        }


        public ActionResult Edit(int Id = 0)
        {
            Brand brand = db.Brands.Find(Id);
            if (brand == null)
            {
                return HttpNotFound();
            }
            ViewBag.StatusId = new SelectList(db.Situations, "StatusId", "Status", brand.Situation);
            return View(brand);
        }

        //
        // POST: /Brand/Edit/5
        [HttpPost]
        public ActionResult Edit(Brand brand)
        {
            if (ModelState.IsValid)
            {
                db.Entry(brand).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.StatusId = new SelectList(db.Situations, "StatusId", "Status", brand.Situation);
            return View(brand);
        }


        public ActionResult Delete(int Id = 0)
        {
            Brand brand = db.Brands.Find(Id);
            if (brand == null)
            {
                return HttpNotFound();
            }
            return View(brand);
        }

        //
        // POST: /Brands/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int Id)
        {
            Brand brand = db.Brands.Find(Id);
            db.Brands.Remove(brand);
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