using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CVBuilder.Services.DTOs
{
    public class LanguagesDTO
    {
        public int LanguageID { get; set; }
        public string Name { get; set; }
        public string Level { get; set; }
        public bool IsVisible { get; set; }
    }
}
