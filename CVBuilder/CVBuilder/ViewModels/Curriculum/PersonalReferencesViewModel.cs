using CVBuilder.enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CVBuilder.ViewModels.Curriculum
{
    public class PersonalReferencesViewModel : SectionViewModelBase
    {
        public int PersonalReferenceID { get; set; }

        [Required(ErrorMessage = "Completar este campo.")]
        [MaxLength(100, ErrorMessage = "Máximo 100 caracteres.")]
        public string Company { get; set; }

        [Required(ErrorMessage = "Completar este campo.")]
        [MaxLength(200, ErrorMessage = "Máximo 200 caracteres.")]
        public string ContactPerson { get; set; }

        [Range(1, 9999, ErrorMessage = "Máximo 4 números.")]
        public short? AreaCode { get; set; }

        [DataType(DataType.PhoneNumber)]
        [Range(1, 9999999999, ErrorMessage = "Máximo 10 números.")]
        public int? Telephone { get; set; }

        [Required(ErrorMessage = "Completar este campo.")]
        public string Email { get; set; }
        public bool IsVisible { get; set; }

        public PersonalReferencesViewModel()
        {
            base.FormId = FormIds.PersonalReferences;
            base.Type = FormType.ADD;
            this.IsVisible = true;
        }
    }
}
