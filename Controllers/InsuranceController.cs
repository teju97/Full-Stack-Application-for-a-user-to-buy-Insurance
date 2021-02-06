using InsuranceProject.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InsuranceProject.Controllers
{
    public class InsuranceController : Controller
    {

        public ActionResult InsurancePurchase()
        {
            if (Session["userId"] == null)
                return RedirectToAction("Login", "Account");
            PurchaseInsuranceViewModel pivm = new PurchaseInsuranceViewModel();
            pivm.ErrorMessage = "";
            return View(pivm);
        }
        [HttpPost]
        public ActionResult InsurancePurchase(PurchaseInsuranceViewModel pivm)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    string format = "dd/MM/yyyy";
                    DateTime startDate;
                    DateTime endDate;
                    Boolean validDate = true;
                    if (!DateTime.TryParseExact(pivm.StartDate, format, CultureInfo.InvariantCulture,
                        DateTimeStyles.None, out startDate))
                    {
                        pivm.ErrorMessage = "You entered invalid start date, or the format is wrong./n";
                        validDate = false;
                    }
                    if (!DateTime.TryParseExact(pivm.EndDate, format, CultureInfo.InvariantCulture,
                        DateTimeStyles.None, out endDate))
                    {
                        pivm.ErrorMessage = "You entered invalid start date, or the format is wrong./n";
                        validDate = false;
                    }
                    if (!validDate)
                        return View(pivm);
                    var insuranceId = ORM.DbMethods.AddNewInsurancePurchase(pivm.InsuranceType, startDate, endDate, Session["userId"].ToString());
                    if(pivm.InsuranceType == "Home")
                        return RedirectToAction("HomeInsurancePurchase", "Insurance", new { id = insuranceId });
                    else
                        return RedirectToAction("CarInsurancePurchase", "Insurance", new { id = insuranceId });

                }
                catch(Exception ex)
                {

                }
            }
            return View(pivm);
        }
        // GET: Insurance
        public ActionResult HomeInsurancePurchase(String id)
        {
            if (Session["userId"] == null)
                return RedirectToAction("Login", "Account");
            HomeInsurancePurchaseViewModel hipvm = new HomeInsurancePurchaseViewModel();
            hipvm.InsuranceId = id;
            hipvm.SubmitMethod = "";

            return View(hipvm);
        }

        [HttpPost]
        public ActionResult HomeInsurancePurchase(HomeInsurancePurchaseViewModel hipvm)
        {
            if (ModelState.IsValid)
            {
                ORM.DbMethods.AddHouseToInsurance(hipvm);
                if(hipvm.SubmitMethod == "AddMore")
                {
                    hipvm.AutoFire = "";
                    hipvm.Security = "";
                    hipvm.Pool = "";
                    hipvm.Basement = "";
                    hipvm.Date = "";
                    hipvm.HomeArea = "";
                    hipvm.HomeValue = "";
                    hipvm.SubmitMethod = "";
                    hipvm.Type = "";
                    return Json(hipvm, JsonRequestBehavior.DenyGet);
                }
                else
                {
                    ORM.DbMethods.CreateAnInvoiceForHomeInsurance(hipvm.InsuranceId);
                }
                return RedirectToAction("DetailedHomeInsurance", "Insurance", new { id = hipvm.InsuranceId } );
            }
            else
            {
                return Json(hipvm, JsonRequestBehavior.DenyGet);
            }
        }

        public ActionResult DetailedHomeInsurance(string id)
        {
            if (Session["userId"] == null)
                return RedirectToAction("Login", "Account");
            DetailedHomeInsuranceViewModel dhivm = new DetailedHomeInsuranceViewModel();
            dhivm = ORM.DbMethods.GetHomeInsuranceDetails(id);
            return View(dhivm);
        }

        [HttpPost]
        public ActionResult DetailedHomeInsurance(DetailedHomeInsuranceViewModel dhivm)
        {
            return RedirectToAction("InsurancePayment", "Insurance", new { id = dhivm.InsuranceId });
        }

        public ActionResult InsurancePayment(String id)
        {
            if (Session["userId"] == null)
                return RedirectToAction("Login", "Account");
            InsurancePaymentViewModel ipvm = ORM.DbMethods.GetInsurancePaymentData(id);
            return View(ipvm);
        }

        [HttpPost]
        public ActionResult InsurancePayment(InsurancePaymentViewModel ipvm)
        {
            ORM.DbMethods.MakeInsurancePayment(ipvm);
            if (ipvm.InsuranceType == "Car insurance")
                return RedirectToAction("DetailedCarInsuranceView", "Insurance", new { id = ipvm.InsuranceId });
            else
                return RedirectToAction("DetailedHomeInsurance", "Insurance", new { id = ipvm.InsuranceId });
        }

        public ActionResult CarInsurancePurchase(string id)
        {
            if (Session["userId"] == null)
                return RedirectToAction("Login", "Account");
            VehicleInsurancePurchaseViewModel vipvm = new VehicleInsurancePurchaseViewModel();
            vipvm.InsuranceId = id;
            return View(vipvm);
        }

        [HttpPost]
        public ActionResult CarInsurancePurchase(VehicleInsurancePurchaseViewModel vipvm)
        {
            if (ModelState.IsValid)
            {
                int vehicleId = ORM.DbMethods.CreateCarInsurance(vipvm);
                return RedirectToAction("AddInsuredDrivers", "Insurance", new { id = vipvm.InsuranceId, vehicle_id = vehicleId });
            }
            else
            {
                return View(vipvm);
            }
        }

        public ActionResult AddInsuredDrivers(string id, string vehicle_id)
        {
            if (Session["userId"] == null)
                return RedirectToAction("Login", "Account");
            InsuredDriversViewModel idvm = new InsuredDriversViewModel();
            idvm.InsuranceID = id;
            idvm.VehicleId = vehicle_id;
            idvm.SubmitMethod = "";
            return View(idvm);
        }

        [HttpPost]
        public ActionResult AddInsuredDrivers(InsuredDriversViewModel idvm)
        {
            ORM.DbMethods.AddDriverToInsuredCar(idvm);
            if (idvm.SubmitMethod == "AddMore")
                return Json(idvm, JsonRequestBehavior.DenyGet);
            else
            {
                ORM.DbMethods.CreateAnInvoiceForCarInsurance(idvm.InsuranceID);
                return RedirectToAction("DetailedCarInsuranceView", "Insurance", new { id = idvm.InsuranceID });
            }
        }

        public ActionResult DetailedCarInsuranceView(string id)
        {
            if (Session["userId"] == null)
                return RedirectToAction("Login", "Account");
            DetailedCarInsuranceViewModel dcivm = ORM.DbMethods.GetDetailedCarInsuranceDate(id);
            dcivm.InsuranceId = id;
            return View(dcivm);
        }

        [HttpPost]
        public ActionResult DetailedCarInsuranceView(DetailedCarInsuranceViewModel dcivm)
        {
            return RedirectToAction("InsurancePayment", "Insurance", new { id = dcivm.InsuranceId });
        }
    }
}