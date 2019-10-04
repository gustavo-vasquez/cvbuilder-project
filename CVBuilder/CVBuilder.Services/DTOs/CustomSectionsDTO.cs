using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CVBuilder.Services.DTOs
{
    public class CustomSectionsDTO
    {
        public int CustomSectionID { get; set; }
        public string SectionName { get; set; }
        public string Description { get; set; }
        public bool IsVisible { get; set; }
    }
}
