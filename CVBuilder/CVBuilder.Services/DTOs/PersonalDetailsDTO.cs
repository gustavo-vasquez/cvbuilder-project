using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CVBuilder.Services.DTOs
{
    public class PersonalDetailsDTO
    {
        public int PersonalDetailsID { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public byte[] Photo { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public int? PostalCode { get; set; }
        public short? AreaCodeLP { get; set; }
        public int? LinePhone { get; set; }
        public short? AreaCodeMP { get; set; }
        public int? MobilePhone { get; set; }
        public int? Day { get; set; }
        public string Month { get; set; }
        public int? Year { get; set; }
        public int? IdentityCard { get; set; }
        public string Country { get; set; }
        public string Summary { get; set; }
        public string SummaryCustomTitle { get; set; }
        public bool SummaryIsVisible { get; set; }
        public string WebPageUrl { get; set; }
        public string LinkedInUrl { get; set; }
        public string GithubUrl { get; set; }
        public string FacebookUrl { get; set; }
        public string TwitterUrl { get; set; }
    }
}
