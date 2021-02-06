using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InsuranceProject.Models
{
    public class LoginViewModel
    {
        [Display(Name = "E-mail")]
        [Required(ErrorMessage = "Please, insert your email.")]
        public String Email { get; set; }

        [Display(Name = "Password")]
        [Required(ErrorMessage = "Please, insert your preferred password.")]
        [DataType(DataType.Password)]
        public String Password { get; set; }

        public String ErrorMessage { get; set; }
    }
}