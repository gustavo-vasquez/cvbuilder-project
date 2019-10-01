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
    public class CertificatesViewModel : SectionViewModelBase
    {
        public readonly DateDropdownList Period = new DateDropdownList(DateType.CERTIFICATE);

        public int CertificateID { get; set; }

        [Required(ErrorMessage = "Completar este campo.")]
        [MaxLength(100, ErrorMessage = "Máximo 100 caracteres.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Completar este campo.")]
        [MaxLength(100, ErrorMessage = "Máximo 100 caracteres.")]
        public string Institute { get; set; }
        public bool OnlineMode { get; set; }
        public bool InProgress { get; set; }

        [RequiredIfNot("InProgress")]
        public int? Year { get; set; }
        
        [MaxLength(300, ErrorMessage = "Máximo 300 caracteres.")]
        public string Description { get; set; }
        public bool IsVisible { get; set; }

        public CertificatesViewModel()
        {
            base.FormId = FormIds.Certificates;
            base.Type = FormType.ADD;
        }
    }
}
