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
    public class DealsController : Controller
    {
        private SWCRMEntities db = new SWCRMEntities();

        // GET: Deals
        public ActionResult Index(string aranacakKelime)
        {
            var deals = from e in db.Deals
                            select e;
            if (!String.IsNullOrEmpty(aranacakKelime))
            {
                deals = deals.Where(a => a.DealName.Contains(aranacakKelime));
            }
            return View(deals);

            var deal = db.Deals.Include(de => de.Contact).Include(de => de.Employee).Include(de => de.Currency).Include(de => de.DealStatu);
            return View(deal.ToList());
        }


        public ActionResult DealsDetails(int Id = 0)
        {
            Deal deal = db.Deals.Find(Id);
            if (deal == null)
            {
                return HttpNotFound();
            }
            return View(deal);
        }


        public ActionResult DealCreate()
        {
            ViewBag.ContactId = new SelectList(db.Contacts, "ContactId", "ContactId");
            ViewBag.EmployeeId = new SelectList(db.Employees, "EmployeeId", "EmployeeId");
            ViewBag.CurrencyId = new SelectList(db.Currencies, "CurrencyId", "CurrencyId");
            ViewBag.DealStatusId = new SelectList(db.DealStatus, "DealStatusId", "DealStatusId");
            return View();
        }

        //

        [HttpPost]
        public ActionResult DealCreate(Deal deal)
        {
            if (ModelState.IsValid)
            {
                db.Deals.Add(deal);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ContactId = new SelectList(db.Contacts, "ContactId", "NameSurname", deal.Contact);
            ViewBag.EmployeeId = new SelectList(db.Employees, "EmployeeId", "NameSurname", deal.Employee);
            ViewBag.CurrencyId = new SelectList(db.Currencies, "CurrencyId", "Name", deal.Currency);
            ViewBag.DealStatusId = new SelectList(db.DealStatus, "DealStatusId", "DealStatusName", deal.DealStatu);
            return View(deal);
        }


        public ActionResult Edit(int Id = 0)
        {
            Deal deal = db.Deals.Find(Id);
            if (deal == null)
            {
                return HttpNotFound();
            }
            ViewBag.ContactId = new SelectList(db.Contacts, "ContactId", "NameSurname", deal.Contact);
            ViewBag.EmployeeId = new SelectList(db.Employees, "EmployeeId", "NameSurname", deal.Employee);
            ViewBag.CurrencyId = new SelectList(db.Currencies, "CurrencyId", "Name", deal.Currency);
            ViewBag.DealStatusId = new SelectList(db.DealStatus, "DealStatusId", "DealStatusName", deal.DealStatu);
            return View(deal);
        }

        //
        // POST: /Deals/Edit/5
        [HttpPost]
        public ActionResult Edit(Deal deal)
        {
            if (ModelState.IsValid)
            {
                db.Entry(deal).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ContactId = new SelectList(db.Contacts, "ContactId", "NameSurname", deal.Contact);
            ViewBag.EmployeeId = new SelectList(db.Employees, "EmployeeId", "NameSurname", deal.Employee);
            ViewBag.CurrencyId = new SelectList(db.Currencies, "CurrencyId", "Name", deal.Currency);
            ViewBag.DealStatusId = new SelectList(db.DealStatus, "DealStatusId", "DealStatusName", deal.DealStatu);
            return View(deal);
        }


        public ActionResult Delete(int Id = 0)
        {
            Deal deal = db.Deals.Find(Id);
            if (deal == null)
            {
                return HttpNotFound();
            }
            return View(deal);
        }

        //
        // POST: /Deals/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int Id)
        {
            Deal deal = db.Deals.Find(Id);
            db.Deals.Remove(deal);
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