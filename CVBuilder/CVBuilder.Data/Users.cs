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
    
    public partial class Users
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Users()
        {
            this.Curriculum = new HashSet<Curriculum>();
        }
    
        public int UserID { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public Nullable<int> IdentityCard { get; set; }
        public byte[] Photo { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public Nullable<int> PostalCode { get; set; }
        public Nullable<short> AreaCodeLP { get; set; }
        public Nullable<int> LinePhone { get; set; }
        public Nullable<short> AreaCodeMP { get; set; }
        public Nullable<int> MobilePhone { get; set; }
        public Nullable<System.DateTime> BirthDate { get; set; }
        public string Nationality { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Curriculum> Curriculum { get; set; }
    }
}