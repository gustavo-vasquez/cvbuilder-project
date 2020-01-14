using CVBuilder.custom_validations;
using CVBuilder.enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CVBuilder.ViewModels.Curriculum
{
    public class WorkExperiencesViewModel : SectionViewModelBase
    {
        public readonly DateDropdownList StartPeriod = new DateDropdownList(DateType.START_PERIOD);
        public readonly DateDropdownList EndPeriod = new DateDropdownList(DateType.END_PERIOD);

        public int WorkExperienceID { get; set; }

        [Required(ErrorMessage = "Completar este campo.")]
        [MaxLength(100, ErrorMessage = "Máximo 100 caracteres.")]
        public string Job { get; set; }

        [Required(ErrorMessage = "Completar este campo.")]
        [MaxLength(100, ErrorMessage = "Máximo 100 caracteres.")]
        public string City { get; set; }

        [Required(ErrorMessage = "Completar este campo.")]
        [MaxLength(100, ErrorMessage = "Máximo 100 caracteres.")]
        public string Company { get; set; }
        public string StartMonth { get; set; }

        [StartYearLessThan("EndYear")]
        public int? StartYear { get; set; }
        public string EndMonth { get; set; }

        [EndYearGreaterThan("StartYear")]
        public int? EndYear { get; set; }
        
        [MaxLength(300, ErrorMessage = "Máximo 300 caracteres.")]
        public string Description { get; set; }
        public bool IsVisible { get; set; }

        public WorkExperiencesViewModel()
        {
            base.FormId = FormIds.WorkExperiences;
            base.Type = FormType.ADD;
            this.IsVisible = true;
        }
    }
}
