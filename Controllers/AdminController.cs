using InsuranceProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InsuranceProject.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Customers()
        {
            if (Session["admin"] == null)
                return RedirectToAction("Login", "Account");
            if (Session["user"] != null)
                return RedirectToAction("Logout", "Account");
            List<CustomerViewModel> cvm = ORM.DbMethods.GetAllCustomers();
            return View(cvm);
        }

        public ActionResult DeleteUser(string id)
        {
            if (Session["admin"] == null)
                return RedirectToAction("Login", "Account");
            if (Session["user"] != null)
                return RedirectToAction("Logout", "Account");
            ORM.DbMethods.DeleteUser(id);
            return RedirectToAction("Customers", "Admin");
        }
    }
}