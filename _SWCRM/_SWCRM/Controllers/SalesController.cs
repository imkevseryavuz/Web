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
    public class SalesController : Controller
    {

        private SWCRMEntities db = new SWCRMEntities();

        // GET: Sales
        public ActionResult Index(string aranacakKelime)
        {
            var sales = from e in db.Sales
                            select e;
            if (!String.IsNullOrEmpty(aranacakKelime))
            {
                sales = sales.Where(a => a.SalesName.Contains(aranacakKelime));
            }
            return View(sales);

            var sale = db.Sales.Include(sal => sal.Contact).Include(sal => sal.SingUp).Include(sal => sal.Currency);
            return View(sale.ToList());
        }


        public ActionResult SalesDetails(int Id = 0)
        {
            Sale sale = db.Sales.Find(Id);
            if (sale == null)
            {
                return HttpNotFound();
            }
            return View(sale);
        }


        public ActionResult SalesCreate()
        {
            ViewBag.ContactId = new SelectList(db.Contacts, "ContactId", "ContactId");
            ViewBag.SingUpId = new SelectList(db.SingUps, "SingUpId", "SingUpId");
            ViewBag.CurrencyId = new SelectList(db.Currencies, "CurrencyId", "CurrencyId");
            return View();
        }

        //

        [HttpPost]
        public ActionResult SalesCreate(Sale sale)
        {
            if (ModelState.IsValid)
            {
                db.Sales.Add(sale);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ContactId = new SelectList(db.Contacts, "ContactId", "NameSurname", sale.Contact);
            ViewBag.SingUpId = new SelectList(db.SingUps, "SingUpId", "Name", sale.SingUp);
            ViewBag.CurrencyId = new SelectList(db.Currencies, "CurrencyId", "Name", sale.Currency);
            return View(sale);
        }


        public ActionResult Edit(int Id = 0)
        {
            Sale sale = db.Sales.Find(Id);
            if (sale == null)
            {
                return HttpNotFound();
            }
            ViewBag.ContactId = new SelectList(db.Contacts, "ContactId", "NameSurname", sale.Contact);
            ViewBag.SingUpId = new SelectList(db.SingUps, "SingUpId", "Name", sale.SingUp);
            ViewBag.CurrencyId = new SelectList(db.Currencies, "CurrencyId", "Name", sale.Currency);
            return View(sale);
        }

        //
        // POST: /Sales/Edit/5
        [HttpPost]
        public ActionResult Edit(Sale sale)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sale).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ContactId = new SelectList(db.Contacts, "ContactId", "NameSurname", sale.Contact);
            ViewBag.SingUpId = new SelectList(db.SingUps, "SingUpId", "Name", sale.SingUp);
            ViewBag.CurrencyId = new SelectList(db.Currencies, "CurrencyId", "Name", sale.Currency);
            return View(sale);
        }


        public ActionResult Delete(int Id = 0)
        {
            Sale sale = db.Sales.Find(Id);
            if (sale == null)
            {
                return HttpNotFound();
            }
            return View(sale);
        }

        //
        // POST: /Sales/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int Id)
        {
            Sale sale = db.Sales.Find(Id);
            db.Sales.Remove(sale);
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