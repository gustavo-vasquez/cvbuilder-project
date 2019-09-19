using CVBuilder.enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CVBuilder.ViewModels.Curriculum
{
    public class PersonalDetailsViewModel
    {
        public readonly DateDropdownList BirthDate = new DateDropdownList(DateType.Birthday);

        [Required(ErrorMessage = "Completar este campo.")]
        [MaxLength(100, ErrorMessage = "Máximo 100 caracteres.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Completar este campo.")]
        [MaxLength(100, ErrorMessage = "Máximo 100 caracteres.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Completar este campo.")]
        [MaxLength(100, ErrorMessage = "Máximo 100 caracteres.")]
        public string Email { get; set; }
        
        public byte[] Photo { get; set; }

        [MaxLength(100, ErrorMessage = "Máximo 100 caracteres.")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Completar este campo.")]
        [MaxLength(100, ErrorMessage = "Máximo 100 caracteres.")]
        public string City { get; set; }

        [DataType(DataType.PostalCode)]
        [MaxLength(5, ErrorMessage = "Cod. postal no válido.")]
        public int? PostalCode { get; set; }

        [MaxLength(4, ErrorMessage = "Cod. área no válido.")]
        public short? AreaCodeLP { get; set; }

        [DataType(DataType.PhoneNumber)]
        [MaxLength(10, ErrorMessage = "Máximo 10 números.")]
        public int? LinePhone { get; set; }

        [MaxLength(4, ErrorMessage = "Cod. área no válido.")]
        public short? AreaCodeMP { get; set; }

        [MaxLength(10, ErrorMessage = "Máximo 10 números.")]
        public int? MobilePhone { get; set; }
        public int? Day { get; set; }
        public string Month { get; set; }
        public int? Year { get; set; }
        public int? IdentityCard { get; set; }

        [MaxLength(100, ErrorMessage = "Máximo 100 caracteres.")]
        public string Country { get; set; }

        [Required(ErrorMessage = "Completar este campo.")]
        [MaxLength(300, ErrorMessage = "Máximo 300 caracteres.")]
        public string Summary { get; set; }

        [MaxLength(50, ErrorMessage = "Máximo 50 caracteres.")]
        public string SummaryCustomTitle { get; set; }
        public bool SummaryIsVisible { get; set; }

        [MaxLength(300, ErrorMessage = "Máximo 300 caracteres.")]
        public string WebPageUrl { get; set; }

        [MaxLength(300, ErrorMessage = "Máximo 300 caracteres.")]
        public string LinkedInUrl { get; set; }

        [MaxLength(300, ErrorMessage = "Máximo 300 caracteres.")]
        public string GithubUrl { get; set; }

        [MaxLength(300, ErrorMessage = "Máximo 300 caracteres.")]
        public string FacebookUrl { get; set; }

        [MaxLength(300, ErrorMessage = "Máximo 300 caracteres.")]
        public string TwitterUrl { get; set; }
    }
}
