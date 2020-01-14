using CVBuilder.enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CVBuilder.ViewModels.Curriculum
{
    public class InterestsViewModel : SectionViewModelBase
    {
        public int InterestID { get; set; }

        [Required(ErrorMessage = "Completar este campo.")]
        [MaxLength(100, ErrorMessage = "Máximo 100 caracteres.")]
        public string Name { get; set; }
        public bool IsVisible { get; set; }

        public InterestsViewModel()
        {
            base.FormId = FormIds.Interests;
            base.Type = FormType.ADD;
            this.IsVisible = true;
        }
    }
}
