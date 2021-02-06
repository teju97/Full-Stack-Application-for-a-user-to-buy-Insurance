using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InsuranceProject.Models
{
    public class PurchaseInsuranceViewModel
    {
        [Display(Name = "Insurance Type")]
        [Required(ErrorMessage = "Please, select the insurance type.")]
        public String InsuranceType { get; set; }

        [Display(Name = "Start Date")]
        [Required(ErrorMessage = "Please, select the start date.")]
        [DataType(DataType.Date)]
        public String StartDate { get; set; }

        [Display(Name = "End Date")]
        [Required(ErrorMessage = "Please, select the end date.")]
        [DataType(DataType.Date)]
        public String EndDate { get; set; }

        public String ErrorMessage { get; set; }
        public IEnumerable<SelectListItem> InsuranceTypeList
        {
            get
            {
                return new List<SelectListItem>
            {
                new SelectListItem { Text = "Please, select type.", Value = ""},
                new SelectListItem { Text = "Car Insurance", Value = "Car"},
                new SelectListItem { Text = "Home Insurance", Value = "Home"}
            };
            }
        }
    }
}