using _SWCRM.Concrete;
using _SWCRM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _SWCRM.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }



        EmployersLogin el = new EmployersLogin();
        public ActionResult EmployerLogin()
        { return View(); }
        [HttpPost]
        public ActionResult EmployerLogin(Employer log)
        {
            var Login = el.EmployerLogin(log.UserName, log.Password);
            if (Login != null)
            {

                Session["UserName"] = log.UserName;
                Session["AdminId"] = log.SingUpId;


                return RedirectToAction("Index", "Employees");
            }
            else if (Login == null)
            {
                Response.Write("<script language='javascript' type='text/javascript'>alert('Hatalı Giriş...');</script>");
            }
            return View();
        }

        public ActionResult Exit()
        {
            if (Session["AdminId"] != null)
            {
                ViewBag.AdminName = Session["UserName"];
                Session.Abandon();
                Session.Clear();
                return RedirectToAction("EmployerLogin", "Login");
            }
            else
            {
                return RedirectToAction("EmployerLogin", "Login");
            }

        }
    }
}