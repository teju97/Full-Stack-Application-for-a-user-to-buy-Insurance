using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InsuranceProject.Models
{
    public class DetailedCarInsuranceViewModel
    {
        public String InsuranceId { get; set; }

        public String StartDate { get; set; }

        public String EndDate { get; set; }

        public String Status { get; set; }

        public String Brand { get; set; }

        public String Model { get; set; }

        public String Year { get; set; }

        public String InvoiceId { get; set; }

        public String Price { get; set; }

        public String DueDate { get; set; }

        public Boolean IsPaid { get; set; }
        public List<DriversCarInsuranceViewModel> Drivers { get; set; }
    }
}