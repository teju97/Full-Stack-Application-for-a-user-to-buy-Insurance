//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace InsuranceProject
{
    using System;
    using System.Collections.Generic;
    
    public partial class HomeInsured
    {
        public int HomeInsuredID { get; set; }
        public System.DateTime PurchaseDate { get; set; }
        public decimal PurchaseValue { get; set; }
        public decimal HomeArea { get; set; }
        public string Type { get; set; }
        public bool AutoFire { get; set; }
        public bool Security { get; set; }
        public bool Basement { get; set; }
        public string Pool { get; set; }
        public int InsuranceId { get; set; }
    
        public virtual Insurance Insurance { get; set; }
    }
}