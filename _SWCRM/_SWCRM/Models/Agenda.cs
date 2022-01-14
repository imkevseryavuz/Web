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
    
    public partial class Agenda
    {
        public int AgendaId { get; set; }
        public string Descriptionn { get; set; }
        public Nullable<int> AgendaTypeId { get; set; }
        public Nullable<int> AgendaStatusId { get; set; }
        public Nullable<int> ImportanceId { get; set; }
        public string StartDate { get; set; }
        public string StartTime { get; set; }
        public string FinishDate { get; set; }
        public string FinisTime { get; set; }
        public Nullable<int> SingUpId { get; set; }
        public Nullable<int> ContactId { get; set; }
        public Nullable<int> ResultId { get; set; }
    
        public virtual AgendaStatu AgendaStatu { get; set; }
        public virtual AgendaType AgendaType { get; set; }
        public virtual Contact Contact { get; set; }
        public virtual ImportanceLevel ImportanceLevel { get; set; }
        public virtual Result Result { get; set; }
        public virtual SingUp SingUp { get; set; }
    }
}