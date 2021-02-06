using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InsuranceProject.Models
{
    public class VehicleInsurancePurchaseViewModel
    {
        [Display(Name = "Model")]
        [Required(ErrorMessage = "Please, enter the model name.")]
        public String Model { get; set; }

        [Display(Name = "Brand")]
        [Required(ErrorMessage = "Please, enter the brand name.")]
        public String Brand { get; set; }

        [Display(Name = "Date")]
        [Required(ErrorMessage = "Please, enter the year of the car.")]
        [RegularExpression("([1-9][0-9]*)", ErrorMessage = "Value must be a year.")]
        public String Year { get; set; }

        public String Status { get; set; }

        public String InsuranceId { get; set; }

        public IEnumerable<SelectListItem> StatusList
        {
            get
            {
                return new List<SelectListItem>
            {
                new SelectListItem { Text = "Please, select status.", Value = ""},
                new SelectListItem { Text = "Owned", Value = "Owned"},
                new SelectListItem { Text = "Financed", Value = "Financed"},
                new SelectListItem { Text = "Leased", Value = "Leadsed" }
            };
            }
        }
    }
}