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
        public string Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Profession { get; set; }
        public byte[] Photo { get; set; }
        public string MimeType { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public Nullable<int> PostalCode { get; set; }
        public Nullable<short> AreaCodeLP { get; set; }
        public Nullable<int> LinePhone { get; set; }
        public Nullable<short> AreaCodeMP { get; set; }
        public Nullable<int> MobilePhone { get; set; }
        public string Country { get; set; }
    }
}
