using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InsuranceProject.Models
{
    public class HomeInsurancePurchaseViewModel
    {
        [Display(Name = "Home Value")]
        [Required(ErrorMessage = "Please, the home value.")]
        public String HomeValue { get; set; }

        [Display(Name = "Date")]
        [Required(ErrorMessage = "Please, enter the date in format dd/MM/yyyy.")]
        public String Date { get; set; }

        [Display(Name = "Type")]
        [Required(ErrorMessage = "Please, select the type.")]
        public String Type { get; set; }

        public String InsuranceId { get; set; }

        public String SubmitMethod { get; set; }

        [Display(Name = "Home Area in ft sq")]
        [Required(ErrorMessage = "Please, enter the home area.")]
        public String HomeArea { get; set; }

        public IEnumerable<SelectListItem> TypeList
        {
            get
            {
                return new List<SelectListItem>
            {
                new SelectListItem { Text = "Please, select type.", Value = ""},
                new SelectListItem { Text = "Single family", Value = "S"},
                new SelectListItem { Text = "Multi family", Value = "M"},
                new SelectListItem { Text = "Condominium", Value = "C" },
                new SelectListItem { Text = "Town house respectively", Value = "T" }
            };
            }
        }

        [Display(Name = "Auto-fire")]
        [Required(ErrorMessage = "Please, select the auto-fire.")]
        public String AutoFire { get; set; }

        public IEnumerable<SelectListItem> AutoFireList
        {
            get
            {
                return new List<SelectListItem>
            {
                new SelectListItem { Text = "Please, select value.", Value = ""},
                new SelectListItem { Text = "Yes", Value = "Yes"},
                new SelectListItem { Text = "No", Value = "No"}
            };
            }
        }

        [Display(Name = "Security")]
        [Required(ErrorMessage = "Please, select the security.")]
        public String Security { get; set; }

        public IEnumerable<SelectListItem> SecurityList
        {
            get
            {
                return new List<SelectListItem>
            {
                new SelectListItem { Text = "Please, select value.", Value = ""},
                new SelectListItem { Text = "Yes", Value = "Yes"},
                new SelectListItem { Text = "No", Value = "No"}
            };
            }
        }

        [Display(Name = "Basement")]
        [Required(ErrorMessage = "Please, select the basement.")]
        public String Basement { get; set; }

        public IEnumerable<SelectListItem> BasementList
        {
            get
            {
                return new List<SelectListItem>
            {
                new SelectListItem { Text = "Please, select value.", Value = ""},
                new SelectListItem { Text = "Yes", Value = "Yes"},
                new SelectListItem { Text = "No", Value = "No"}
            };
            }
        }

        [Display(Name = "Pool")]
        [Required(ErrorMessage = "Please, select the pool value.")]
        public String Pool { get; set; }

        public IEnumerable<SelectListItem> PoolList
        {
            get
            {
                return new List<SelectListItem>
            {
                new SelectListItem { Text = "Please, select value.", Value = ""},
                new SelectListItem { Text = "Underground", Value = "U"},
                new SelectListItem { Text = "Overground", Value = "O"},
                new SelectListItem { Text = "Indoor", Value = "I" },
                new SelectListItem { Text = "Multiple", Value = "M" },
                new SelectListItem { Text = "No swimming pool", Value = "N" }
            };
            }
        }
    }
}