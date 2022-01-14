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
    public class ProductsController : Controller
    {
        private SWCRMEntities db = new SWCRMEntities();

        // GET: Products
        public ActionResult Index(string aranacakKelime)
        {
            var products = from e in db.Products
                            select e;
            if (!String.IsNullOrEmpty(aranacakKelime))
            {
                products = products.Where(a => a.ProductName.Contains(aranacakKelime));
            }
            return View(products);

            var product = db.Products.Include(pd => pd.Brand).Include(pd => pd.Category).Include(pd => pd.Currency).Include(pd => pd.Situation);
            return View(product.ToList());
        }


        public ActionResult ProductDetails(int Id = 0)
        {
            Product product = db.Products.Find(Id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }


        public ActionResult ProductCreate()
        {
            ViewBag.BrandId = new SelectList(db.Brands, "BrandId", "BrandId");
            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "CategoryId");
            ViewBag.CurrencyId = new SelectList(db.Currencies, "CurrencyId", "CurrencyId");
            ViewBag.StatusId = new SelectList(db.Situations, "StatusId", "StatusId");
            return View();
        }

        //

        [HttpPost]
        public ActionResult ProductCreate(Product product)
        {
            if (ModelState.IsValid)
            {
                db.Products.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BrandId = new SelectList(db.Brands, "BrandId", "Name", product.Brand);
            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "Name", product.Category);
            ViewBag.CurrencyId = new SelectList(db.Currencies, "CurrencyId", "Name", product.Currency);
            ViewBag.StatusId = new SelectList(db.Situations, "StatusId", "Status", product.Situation);
            return View(product);
        }


        public ActionResult Edit(int Id = 0)
        {
            Product product = db.Products.Find(Id);
            if (product == null)
            {
                return HttpNotFound();
            }
            ViewBag.BrandId = new SelectList(db.Brands, "BrandId", "Name", product.Brand);
            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "Name", product.Category);
            ViewBag.CurrencyId = new SelectList(db.Currencies, "CurrencyId", "Name", product.Currency);
            ViewBag.StatusId = new SelectList(db.Situations, "StatusId", "Status", product.Situation);
            return View(product);
        }

        //
        // POST: /Products/Edit/5
        [HttpPost]
        public ActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BrandId = new SelectList(db.Brands, "BrandId", "Name", product.Brand);
            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "Name", product.Category);
            ViewBag.CurrencyId = new SelectList(db.Currencies, "CurrencyId", "Name", product.Currency);
            ViewBag.StatusId = new SelectList(db.Situations, "StatusId", "Status", product.Situation);
            return View(product);
        }


        public ActionResult Delete(int Id = 0)
        {
            Product product = db.Products.Find(Id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        //
        // POST: /Products/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int Id)
        {
            Product product = db.Products.Find(Id);
            db.Products.Remove(product);
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