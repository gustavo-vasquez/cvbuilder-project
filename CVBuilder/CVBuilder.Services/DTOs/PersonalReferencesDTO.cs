using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CVBuilder.Services.DTOs
{
    public class PersonalReferencesDTO
    {
        public string Company { get; set; }
        public string ContactPerson { get; set; }
        public short AreaCode { get; set; }
        public int Telephone { get; set; }
        public string Email { get; set; }
        public bool IsVisible { get; set; }
    }
}
