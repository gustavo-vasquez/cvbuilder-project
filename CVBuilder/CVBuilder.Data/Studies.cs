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
    
    public partial class Studies
    {
        public int StudyID { get; set; }
        public string Title { get; set; }
        public string Institute { get; set; }
        public string City { get; set; }
        public string StartMonth { get; set; }
        public Nullable<int> StartYear { get; set; }
        public string EndMonth { get; set; }
        public Nullable<int> EndYear { get; set; }
        public string Description { get; set; }
        public bool IsVisible { get; set; }
        public int ID_Curriculum { get; set; }
    
        public virtual Curriculum Curriculum { get; set; }
    }
}
