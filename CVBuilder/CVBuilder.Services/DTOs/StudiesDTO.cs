using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CVBuilder.Services.DTOs
{
    public class StudiesDTO
    {
        public int StudyID { get; set; }
        public string Title { get; set; }
        public string Institute { get; set; }
        public string City { get; set; }
        public string StartMonth { get; set; }
        public int? StartYear { get; set; }
        public string EndMonth { get; set; }
        public int? EndYear { get; set; }
        public string Description { get; set; }
        public bool IsVisible { get; set; }

        //public int studyid = 0;
    }
}
