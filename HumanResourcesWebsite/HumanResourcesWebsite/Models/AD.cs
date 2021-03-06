//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HumanResourcesWebsite.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class AD
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public AD()
        {
            this.ApplicantAds = new HashSet<ApplicantAd>();
        }
    
        public int AdID { get; set; }
        public string Title { get; set; }
        public Nullable<int> NumberOfApplications { get; set; }
        public string Information { get; set; }
        public Nullable<System.DateTime> AdStartDate { get; set; }
        public Nullable<System.DateTime> AdEndDate { get; set; }
        public string Experiences { get; set; }
        public string EducationLevel { get; set; }
        public Nullable<bool> MilitaryState { get; set; }
        public string Price { get; set; }
        public Nullable<int> CompanyID { get; set; }
        public Nullable<int> SectorID { get; set; }
        public string Criterion1 { get; set; }
        public string Criterion2 { get; set; }
        public string Criterion3 { get; set; }
        public string Criterion4 { get; set; }
        public string Criterion5 { get; set; }
    
        public virtual Company Company { get; set; }
        public virtual Sector Sector { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ApplicantAd> ApplicantAds { get; set; }
    }
}
