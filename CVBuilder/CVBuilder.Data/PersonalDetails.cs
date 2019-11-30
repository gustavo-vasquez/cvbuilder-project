//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CVBuilder.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class PersonalDetails
    {
        public int PersonalDetailsID { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public byte[] Photo { get; set; }
        public string MimeType { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public Nullable<int> PostalCode { get; set; }
        public Nullable<short> AreaCodeLP { get; set; }
        public Nullable<int> LinePhone { get; set; }
        public Nullable<short> AreaCodeMP { get; set; }
        public Nullable<int> MobilePhone { get; set; }
        public Nullable<System.DateTime> BirthDate { get; set; }
        public Nullable<int> IdentityCard { get; set; }
        public string Country { get; set; }
        public string Summary { get; set; }
        public string SummaryCustomTitle { get; set; }
        public bool SummaryIsVisible { get; set; }
        public string WebPageUrl { get; set; }
        public string LinkedInUrl { get; set; }
        public string GithubUrl { get; set; }
        public string FacebookUrl { get; set; }
        public string TwitterUrl { get; set; }
        public int ID_Curriculum { get; set; }
    
        public virtual Curriculum Curriculum { get; set; }
    }
}
