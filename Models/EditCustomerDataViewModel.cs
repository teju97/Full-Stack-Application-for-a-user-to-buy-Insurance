using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InsuranceProject.Models
{
    public class EditCustomerDataViewModel
    {
        [Display(Name = "Gender")]
        [Required(ErrorMessage = "Please, choose your gender.")]
        public String Gender { get; set; }

        [Display(Name = "Marital Status")]
        [Required(ErrorMessage = "Please, choose your marital status.")]
        public String Marital_Status { get; set; }
        public IEnumerable<SelectListItem> GenderList
        {
            get
            {
                return new List<SelectListItem>
            {
                new SelectListItem { Text = "Please, select gender.", Value = ""},
                new SelectListItem { Text = "Male", Value = "Male"},
                new SelectListItem { Text = "Female", Value = "Female"}
            };
            }
        }

        public IEnumerable<SelectListItem> MarritalStatusList
        {
            get
            {
                return new List<SelectListItem>
            {
                new SelectListItem { Text = "Please, select status.", Value = ""},
                new SelectListItem { Text = "Single", Value = "Single"},
                new SelectListItem { Text = "Married", Value = "Married"},
                new SelectListItem { Text = "Widow/Widower", Value = "Widow"}
            };
            }
        }
    }
}