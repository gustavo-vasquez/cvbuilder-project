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

        [Required(ErrorMessage = ValMessages.FIELD_REQUIRED)]
        [MaxLength(100, ErrorMessage = ValMessages.MAX + "100" + ValMessages.CHARACTERS)]
        public string SectionName { get; set; }

        [Required(ErrorMessage = ValMessages.FIELD_REQUIRED)]
        public string Description { get; set; }
        public bool IsVisible { get; set; }

        public CustomSectionsViewModel()
        {
            base.FormId = FormIds.CustomSections;
            base.Type = FormType.ADD;
            this.IsVisible = true;
        }
    }
}
