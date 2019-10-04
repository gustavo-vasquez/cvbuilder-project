using CVBuilder.enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CVBuilder.ViewModels.Curriculum
{
    public class CustomSectionsViewModel : SectionViewModelBase
    {
        public int CustomSectionID { get; set; }

        [Required(ErrorMessage = "Completar este campo.")]
        [MaxLength(100, ErrorMessage = "Máximo 100 caracteres.")]
        public string SectionName { get; set; }

        [Required(ErrorMessage = "Completar este campo.")]
        public string Description { get; set; }
        public bool IsVisible { get; set; }

        public CustomSectionsViewModel()
        {
            base.FormId = FormIds.CustomSections;
            base.Type = FormType.ADD;
        }
    }
}
