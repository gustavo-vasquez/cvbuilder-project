using CVBuilder.enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CVBuilder.ViewModels.Curriculum
{
    public class StudiesViewModel : BaseSectionViewModel
    {
        public int StudyID { get; set; }
        [Required(ErrorMessage = "Completar este campo.")]
        [MaxLength(100, ErrorMessage = "Máximo 100 caracteres.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Completar este campo.")]
        [MaxLength(100, ErrorMessage = "Máximo 100 caracteres.")]
        public string Institute { get; set; }

        [Required(ErrorMessage = "Completar este campo.")]
        [MaxLength(100, ErrorMessage = "Máximo 100 caracteres.")]
        public string City { get; set; }
        public string StartMonth { get; set; }
        public int? StartYear { get; set; }
        public string EndMonth { get; set; }
        public int? EndYear { get; set; }

        [MaxLength(300, ErrorMessage = "Máximo 300 caracteres.")]
        public string Description { get; set; }
        public bool IsVisible { get; set; }
        
        public DateDropdownList StartPeriod = new DateDropdownList(DateType.CurriculumStartPeriod);
        public DateDropdownList EndPeriod = new DateDropdownList(DateType.CurriculumEndPeriod);
    }
}
