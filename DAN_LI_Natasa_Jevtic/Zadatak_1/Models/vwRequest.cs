//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Zadatak_1.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class vwRequest
    {
        public int PatientId { get; set; }
        public int UserId { get; set; }
        public string HealthInsuranceCardNumber { get; set; }
        public Nullable<int> DoctorId { get; set; }
        public string EmergencyCase { get; set; }
        public string PatientCompany { get; set; }
        public System.DateTime PostingDate { get; set; }
        public string Reason { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}
