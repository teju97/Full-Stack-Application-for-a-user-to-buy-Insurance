using InsuranceProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace InsuranceProject.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Login()
        {
            LoginViewModel lvm = new LoginViewModel();
            lvm.ErrorMessage = "";
            return View(lvm);
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel lvm)
        {
            if (ModelState.IsValid)
            {
                List<User> users = ORM.DbMethods.GetAllUsers();
                IEnumerable<User> user = users.Where(x => x.Email == lvm.Email);
                if (user.Any())
                {
                    MD5 md5 = new MD5CryptoServiceProvider();
                    Byte[] originalBytes = ASCIIEncoding.Default.GetBytes(lvm.Password);
                    Byte[] encodedBytes = md5.ComputeHash(originalBytes);

                    String hash = BitConverter.ToString(encodedBytes);
                    if (hash == user.First().Password)
                    {
                        if (user.First().IsAdmin)
                        {
                            Session["admin"] = user.First().Email;
                            Session["userId"] = user.First().UserID;
                            return RedirectToAction("AdminProfile", "Account");
                        }
                        else
                        {
                            Session["user"] = user.First().Email;
                            Session["userId"] = user.First().UserID;
                            return RedirectToAction("Profile", "Account");
                        }
                    }
                    else
                    {
                        lvm.ErrorMessage = "Wrong password! Please try again.";
                        return View(lvm);
                    }
                }
                lvm.ErrorMessage = "Wrong Email. User not found! Please try again.";
                return View(lvm);
            }
            else
            {
                return View(lvm);
            }
        }

        public ActionResult Register()
        {
            RegisterViewModel rvm = new RegisterViewModel();
            return View(rvm);
        }

        [HttpPost]
        public ActionResult Register(RegisterViewModel rvm)
        {
            if (ModelState.IsValid)
            {
                ORM.DbMethods.AddNewCustomer(rvm);
                return RedirectToAction("Login", "Account");
            }
            else
            {
                return View(rvm);
            }
        }

        public ActionResult Profile(string id)
        {
            if(id == null)
            {
                if (Session["admin"] != null)
                    return RedirectToAction("AdminProfile", "Account");
                if (Session["user"] == null)
                    return RedirectToAction("Login", "Account");
                ProfileViewModel pvm = ORM.DbMethods.GetAllProfileData(Session["userId"].ToString());
                return View(pvm);
            }
            else
            {
                ProfileViewModel pvm = ORM.DbMethods.GetAllProfileData(id);
                return View(pvm);
            }
        }

        public ActionResult EditProfile()
        {
            if (Session["user"] == null)
                return RedirectToAction("Login", "Account");
            EditProfileViewModel edvm = ORM.DbMethods.GetUserData(Session["userId"].ToString());
            return View(edvm);
        }

        [HttpPost]
        public ActionResult EditProfile(EditProfileViewModel epvm)
        {
            if (ModelState.IsValid)
            {
                ORM.DbMethods.GetUserData(Session["userId"].ToString());
                return RedirectToAction("Profile", "Home");
            }
            else
            {
                return View(epvm);
            }
        }

        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Login", "Account");
        }

        public ActionResult AdminProfile()
        {
            if (Session["admin"] == null || Session["user"] != null)
                return RedirectToAction("Login", "Account");
            ProfileViewModel pvm = ORM.DbMethods.GetAllProfileData(Session["userId"].ToString());
            return View(pvm);
        }

    }
}