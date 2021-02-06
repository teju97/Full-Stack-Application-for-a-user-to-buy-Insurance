using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InsuranceProject.Models
{
    public class CustomerViewModel
    {
        public int Id { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String Address { get; set; }
        public String Gender { get; set; }

        public String Marital_Status { get; set; }
        public String Type { get; set; }
        public String Email { get; set; }
        public String Password { get; set; }
    }
}