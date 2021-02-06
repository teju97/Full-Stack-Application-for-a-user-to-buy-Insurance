using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InsuranceProject.Models
{
    public class ProfileInsurancesViewModel
    {
        public int InsuranceNumber { get; set; }
        public String InsuranceType { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public String Status { get; set; }
    }
}