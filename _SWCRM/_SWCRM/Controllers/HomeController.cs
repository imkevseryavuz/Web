using System;
using _SWCRM.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _SWCRM.Concrete;

namespace _SWCRM.Controllers
{
    public class HomeController : Controller
    {
        // Webciniz controller sayfaları
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ContactUs()
        {
            return View();
        }
        public ActionResult CRM()
        {
            return View();
        }
        public ActionResult EProCRM()
        {
            return View();
        }

        CompanyLogin cl = new CompanyLogin();
        public ActionResult EmployeeLogin()
        { return View(); }
        [HttpPost]
        public ActionResult EmployeeLogin(Employee log)
        {
            var Login = cl.Login(log.UserName, log.Password);
            if (Login != null)
            {

                Session["UserName"] = log.UserName;
                Session["EmploId"] = log.EmployeeId;


                return RedirectToAction("Index", "Dashboard");
            }
            else if (Login == null)
            {
                Response.Write("<script language='javascript' type='text/javascript'>alert('Hatalı Giriş...');</script>");
            }
            return View();
        }

        public ActionResult Exit()
        {
            if (Session["EmploId"] != null)
            {
                ViewBag.AdminName = Session["UserName"];
                Session.Abandon();
                Session.Clear();
                return RedirectToAction("EmployeeLogin", "Home");
            }
            else
            {
                return RedirectToAction("EmployeeLogin", "Home");
            }

        }

       
       

    }
}