using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InsuranceProject.Models
{
    public class EditProfileViewModel
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

        [Display(Name = "Email")]
        [Required(ErrorMessage = "Please, insert your email.")]
        public String Email { get; set; }

        public EditCustomerDataViewModel ecdvm { get; set; }
    }
}