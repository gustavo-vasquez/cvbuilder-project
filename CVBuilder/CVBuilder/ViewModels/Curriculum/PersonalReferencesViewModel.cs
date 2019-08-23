using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CVBuilder.ViewModels.Curriculum
{
    public class PersonalReferencesViewModel
    {
        [Required(ErrorMessage = "Completar este campo.")]
        [MaxLength(100, ErrorMessage = "Máximo 100 caracteres.")]
        public string Company { get; set; }

        [Required(ErrorMessage = "Completar este campo.")]
        [MaxLength(200, ErrorMessage = "Máximo 200 caracteres.")]
        public string ContactPerson { get; set; }

        [MaxLength(4, ErrorMessage = "Cod. área no válido.")]
        public short? AreaCode { get; set; }

        [MaxLength(10, ErrorMessage = "Máximo 10 números.")]
        public int? Telephone { get; set; }

        [Required(ErrorMessage = "Completar este campo.")]
        public string Email { get; set; }
        public bool IsVisible { get; set; }
    }
}
