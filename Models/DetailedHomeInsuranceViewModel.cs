using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InsuranceProject.Models
{
    public class DetailedHomeInsuranceViewModel
    {
        public String InsuranceId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public String Status { get; set; }

        public String InvoiceID { get; set; }

        public String DueDate { get; set; }

        public String Price { get; set; }

        public bool IsPaid { get; set; }

        public List<DetailedHomeInsuranceHomeInsured> HomesInsured { get; set; }


    }
}