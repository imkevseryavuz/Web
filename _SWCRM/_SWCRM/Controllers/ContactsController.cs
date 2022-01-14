using _SWCRM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;
using System.Net;
using _SWCRM.Concrete;
namespace _SWCRM.Controllers
{
    public class ContactsController : Controller
    {
       
        
        private SWCRMEntities db = new SWCRMEntities();

        // GET: Contacts
        public ActionResult Index(string aranacakKelime)
        {
            var contacts = from e in db.Contacts
                            select e;
            if (!String.IsNullOrEmpty(aranacakKelime))
            {
                contacts = contacts.Where(a => a.NameSurname.Contains(aranacakKelime));
            }
            return View(contacts);


            var contact = db.Contacts.Include(cont => cont.RecordType).Include(cont => cont.NumberOfEmployee).Include(cont => cont.Sector).Include(cont => cont.SingUp).Include(cont => cont.Gender);
            return View(contact.ToList());
        }


        public ActionResult ContactDetails(int Id = 0)
        {
            Contact contact = db.Contacts.Find(Id);
            if (contact == null)
            {
                return HttpNotFound();
            }
            return View(contact);
        }



        public ActionResult ContactCreate()
        {
            ViewBag.RecordTypeId = new SelectList(db.RecordTypes, "RecordTypeId", "RecordTypeId");
            ViewBag.NumberOfEmployeesId = new SelectList(db.NumberOfEmployees, "NumberOfEmployeesId", "NumberOfEmployeesId");
            ViewBag.SectorId = new SelectList(db.Sectors, "SectorId", "SectorId");
            ViewBag.SingUpId = new SelectList(db.SingUps, "SingUpId", "SingUpId");
            ViewBag.GenderId = new SelectList(db.Genders, "GenderId", "GenderId");
            return View();
        }

        //

        [HttpPost]
        public ActionResult ContactCreate(Contact contact)
        {
            if (ModelState.IsValid)
            {
                db.Contacts.Add(contact);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.RecordTypeId = new SelectList(db.RecordTypes, "RecordTypeId", "RecordTypeName", contact.RecordType);
            ViewBag.NumberOfEmployeesId = new SelectList(db.NumberOfEmployees, "NumberOfEmployeesId", "NumberOfEmployeeName", contact.NumberOfEmployee);
            ViewBag.SectorId = new SelectList(db.Sectors, "SectorId", "SectorsName", contact.Sector);
            ViewBag.SingUpId = new SelectList(db.SingUps, "SingUpId", "Name", contact.SingUp);
            ViewBag.GenderId = new SelectList(db.Genders, "GenderId", "GenderName", contact.Gender);
            return View(contact);
        }


        public ActionResult Edit(int Id = 0)
        {
            Contact contact = db.Contacts.Find(Id);
            if (contact == null)
            {
                return HttpNotFound();
            }
            ViewBag.RecordTypeId = new SelectList(db.RecordTypes, "RecordTypeId", "RecordTypeName", contact.RecordType);
            ViewBag.NumberOfEmployeesId = new SelectList(db.NumberOfEmployees, "NumberOfEmployeesId", "NumberOfEmployeeName", contact.NumberOfEmployee);
            ViewBag.SectorId = new SelectList(db.Sectors, "SectorId", "SectorsName", contact.Sector);
            ViewBag.SingUpId = new SelectList(db.SingUps, "SingUpId", "Name", contact.SingUp);
            ViewBag.GenderId = new SelectList(db.Genders, "GenderId", "GenderName", contact.Gender);
            return View(contact);
        }

        //
        // POST: /Contacts/Edit/5
        [HttpPost]
        public ActionResult Edit(Contact contact)
        {
            if (ModelState.IsValid)
            {
                db.Entry(contact).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RecordTypeId = new SelectList(db.RecordTypes, "RecordTypeId", "RecordTypeName", contact.RecordType);
            ViewBag.NumberOfEmployeesId = new SelectList(db.NumberOfEmployees, "NumberOfEmployeesId", "NumberOfEmployeeName", contact.NumberOfEmployee);
            ViewBag.SectorId = new SelectList(db.Sectors, "SectorId", "SectorsName", contact.Sector);
            ViewBag.SingUpId = new SelectList(db.SingUps, "SingUpId", "Name", contact.SingUp);
            ViewBag.GenderId = new SelectList(db.Genders, "GenderId", "GenderName", contact.Gender);
            return View(contact);
        }


        public ActionResult Delete(int Id = 0)
        {
            Contact contact = db.Contacts.Find(Id);
            if (contact == null)
            {
                return HttpNotFound();
            }
            return View(contact);
        }

        //
        // POST: /Contacts/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int Id)
        {
            Contact contact = db.Contacts.Find(Id);
            db.Contacts.Remove(contact);
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