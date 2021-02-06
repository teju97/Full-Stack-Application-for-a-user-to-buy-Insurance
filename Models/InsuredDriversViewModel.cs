using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InsuranceProject.Models
{
    public class InsuredDriversViewModel
    {
        [Display(Name = "First Name")]
        [Required(ErrorMessage = "Please, enter the first name.")]
        public String FirstName { get; set; }

        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "Please, enter the last name.")]
        public String LastName { get; set; }

        [Display(Name = "Date of Birth")]
        [Required(ErrorMessage = "Please, enter the date of birth.")]
        public String Birthdate { get; set; }

        [Display(Name = "Licence")]
        [Required(ErrorMessage = "Please, enter the licence.")]
        public String Licence { get; set; }

        public String VehicleId{ get; set; }

        public String InsuranceID { get; set; }

        public String SubmitMethod { get; set; }
    }
}