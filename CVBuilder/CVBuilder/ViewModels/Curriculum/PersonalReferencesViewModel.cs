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

        [Required(ErrorMessage = ValMessages.FIELD_REQUIRED)]
        [MaxLength(100, ErrorMessage = ValMessages.MAX + "100" + ValMessages.CHARACTERS)]
        public string Company { get; set; }

        [Required(ErrorMessage = ValMessages.FIELD_REQUIRED)]
        [MaxLength(200, ErrorMessage = ValMessages.MAX + "200" + ValMessages.CHARACTERS)]
        public string ContactPerson { get; set; }

        [Range(1, 9999, ErrorMessage = ValMessages.MAX + "4" + ValMessages.NUMBERS)]
        public short? AreaCode { get; set; }

        [DataType(DataType.PhoneNumber)]
        [Range(1, 99999999, ErrorMessage = ValMessages.MAX + "8" + ValMessages.NUMBERS)]
        public int? Telephone { get; set; }

        [Required(ErrorMessage = ValMessages.FIELD_REQUIRED)]
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
