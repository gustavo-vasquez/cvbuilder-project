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
    
    public partial class Certificates
    {
        public int CertificateID { get; set; }
        public string Name { get; set; }
        public string Institute { get; set; }
        public bool OnlineMode { get; set; }
        public bool InProgress { get; set; }
        public Nullable<int> Year { get; set; }
        public string Description { get; set; }
        public bool IsVisible { get; set; }
        public int ID_Curriculum { get; set; }
    
        public virtual Curriculum Curriculum { get; set; }
    }
}
