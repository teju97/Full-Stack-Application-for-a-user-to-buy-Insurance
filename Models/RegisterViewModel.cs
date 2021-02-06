using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InsuranceProject.Models
{
    public class RegisterViewModel
    {
        [Display(Name = "First Name")]
        [Required(ErrorMessage = "Please, enter the first name.")]
        public String FirstName { get; set; }

        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "Please, enter the last name.")]
        public String LastName { get; set; }

        [Display(Name = "Address")]
        [Required(ErrorMessage = "Please, enter an address.")]
        public String Address { get; set; }

        [Display(Name = "Gender")]
        [Required(ErrorMessage = "Please, choose your gender.")]
        public String Gender { get; set; }

        [Display(Name = "Marital Status")]
        [Required(ErrorMessage = "Please, choose your marital status.")]
        public String Marital_Status { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "Please, insert your email.")]
        public String Email { get; set; }

        [Display(Name = "Password")]
        [Required(ErrorMessage = "Please, insert your preferred password.")]
        [DataType(DataType.Password)]
        public String Password { get; set; }

        [Display(Name = "Confirm Password")]
        [Required(ErrorMessage = "Please, confirm your password.")]
        [DataType(DataType.Password)]
        [System.ComponentModel.DataAnnotations.Compare("Password")]
        public String ConfirmPassword { get; set; }


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