using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CVBuilder.Services.DTOs
{
    public class WorkExperiencesDTO
    {
        public int WorkExperienceID { get; set; }
        public string Job { get; set; }
        public string City { get; set; }
        public string Company { get; set; }
        public string StartMonth { get; set; }
        public int? StartYear { get; set; }
        public string EndMonth { get; set; }
        public int? EndYear { get; set; }
        public string Description { get; set; }
        public bool IsVisible { get; set; }
    }
}
