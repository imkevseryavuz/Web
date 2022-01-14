//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace _SWCRM.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Deal
    {
        public int DealId { get; set; }
        public string DealName { get; set; }
        public string StartDate { get; set; }
        public string FinishDate { get; set; }
        public string Price { get; set; }
        public string Description { get; set; }
        public Nullable<int> ContactId { get; set; }
        public Nullable<int> EmployeeId { get; set; }
        public Nullable<int> CurrencyId { get; set; }
        public Nullable<int> DealStatusId { get; set; }
    
        public virtual Contact Contact { get; set; }
        public virtual Currency Currency { get; set; }
        public virtual DealStatu DealStatu { get; set; }
        public virtual Employee Employee { get; set; }
    }
}
