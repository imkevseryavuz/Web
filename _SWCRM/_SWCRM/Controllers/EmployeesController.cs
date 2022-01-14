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
    public class EmployeesController : Controller
    {

      
        private SWCRMEntities db = new SWCRMEntities();

        // GET: Employees
        public ActionResult Index(string aranacakKelime)
        {
            var employees = from e in db.Employees
                            select e;
            if(!String.IsNullOrEmpty(aranacakKelime))
            {
                employees = employees.Where(a => a.NameSurname.Contains(aranacakKelime));
            }
            

            if (Session["AdminId"] != null)
            {
                var employee = db.Employees.Include(emp => emp.Department).Include(emp => emp.Gender).Include(emp => emp.WorkingSituation).Include(emp => emp.Situation).Include(emp => emp.Currency);
                return View(employee.ToList());
            }
            else
            {
                return RedirectToAction("EmployerLogin", "Login");
            }
            return View(employees);
        }


        public ActionResult EmployeeDetails(int EmployeeId = 0)
        {
            Employee employee = db.Employees.Find(EmployeeId);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        //
        // GET: /Employee/Create

        public ActionResult EmployeeCreate()
        {
            if (Session["AdminId"] != null)
            {
                ViewBag.DepartmentId = new SelectList(db.Departments, "DepartmentId", "DepartmentId");
                ViewBag.GenderId = new SelectList(db.Genders, "GenderId", "GenderId");
                ViewBag.WorkingStatusId = new SelectList(db.WorkingSituations, "WorkingStatusId", "WorkingStatusId");
                ViewBag.StatusId = new SelectList(db.Situations, "StatusId", "StatusId");
                ViewBag.CurrencyId = new SelectList(db.Currencies, "CurrencyId", "CurrencyId");
                return View();
            }
            else
            {
                return RedirectToAction("EmployerLogin", "Login");
            }
        }

        //
       
        [HttpPost]
        public ActionResult EmployeeCreate(Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Employees.Add(employee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DepartmentId = new SelectList(db.Departments, "DepartmentId", "Name", employee.Department);
            ViewBag.GenderId = new SelectList(db.Genders, "GenderId", "GenderName", employee.Gender);
            ViewBag.WorkingStatusId = new SelectList(db.WorkingSituations, "WorkingStatusId", "WorkingStatus", employee.WorkingSituation);
            ViewBag.StatusId = new SelectList(db.Situations, "StatusId", "Status", employee.Situation);
            ViewBag.CurrencyId = new SelectList(db.Currencies, "CurrencyId", "Name", employee.Currency);
            return View(employee);
        }

        //GET: /Employee/Edit/5

        public ActionResult Edit(int Id = 0)
        {
            if (Session["AdminId"] != null)
            {
                Employee employee = db.Employees.Find(Id);
                if (employee == null)
                {
                    return HttpNotFound();
                }
                ViewBag.DepartmentId = new SelectList(db.Departments, "DepartmentId", "Name", employee.Department);
                ViewBag.GenderId = new SelectList(db.Genders, "GenderId", "GenderName", employee.Gender);
                ViewBag.WorkingStatusId = new SelectList(db.WorkingSituations, "WorkingStatusId", "WorkingStatus", employee.WorkingSituation);
                ViewBag.StatusId = new SelectList(db.Situations, "StatusId", "Status", employee.Situation);
                ViewBag.CurrencyId = new SelectList(db.Currencies, "CurrencyId", "Name", employee.Currency);
                return View(employee);
            }
            else
            {
                return RedirectToAction("EmployerLogin", "Login");
            }
        }

        //
        // POST: /Employee/Edit/5
        [HttpPost]
        public ActionResult Edit(Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DepartmentId = new SelectList(db.Departments, "DepartmentId", "Name", employee.Department);
            ViewBag.GenderId = new SelectList(db.Genders, "GenderId", "GenderName", employee.Gender);
            ViewBag.WorkingStatusId = new SelectList(db.WorkingSituations, "WorkingStatusId", "WorkingStatus", employee.WorkingSituation);
            ViewBag.StatusId = new SelectList(db.Situations, "StatusId", "Status", employee.Situation);
            ViewBag.CurrencyId = new SelectList(db.Currencies, "CurrencyId", "Name", employee.Currency);
            return View(employee);
        }
        // GET: /Employee/Delete/5

        public ActionResult Delete(int Id = 0)
        {
            if (Session["AdminId"] != null)
            {
                Employee employee = db.Employees.Find(Id);
                if (employee == null)
                {
                    return HttpNotFound();
                }
                return View(employee);
            }
            else
            {
                return RedirectToAction("EmployerLogin", "Login");
            }
        }

        //
        // POST: /Employee/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int Id)
        {
            Employee employee = db.Employees.Find(Id);
            db.Employees.Remove(employee);
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