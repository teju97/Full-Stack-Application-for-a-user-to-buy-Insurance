using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InsuranceProject.Models
{
    public class InsurancePaymentViewModel
    {
        [Display(Name = "Card Holder")]
        public String CardHolder { get; set; }

        [Display(Name = "Card Expiry")]
        public String CardExpiry { get; set; }

        [Display(Name = "Card Number")]
        public String CardNumber { get; set; }

        [Display(Name = "CVC")]
        public String CVC { get; set; }

        [Display(Name = "Paypal Email")]
        public String PaypalMail { get; set; }

        public String InsuranceId { get; set; }

        public String StartDate { get; set; }

        public String EndDate { get; set; }

        public String Price { get; set; }

        public String InsuranceType { get; set; }

        public String PaymentType { get; set; }
    }
}