using CVBuilder.custom_validations;
using CVBuilder.enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace CVBuilder.ViewModels.Curriculum
{
    public class PersonalDetailsViewModel : SectionViewModelBase
    {
        public int PersonalDetailsID { get; set; }

        [Required(ErrorMessage = "Completar este campo.")]
        [MaxLength(100, ErrorMessage = "Máximo 100 caracteres.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Completar este campo.")]
        [MaxLength(100, ErrorMessage = "Máximo 100 caracteres.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Completar este campo.")]
        [MaxLength(100, ErrorMessage = "Máximo 100 caracteres.")]
        public string Email { get; set; }

        public string Profession { get; set; }

        [PostedFileExtensions("jpg,jpeg,png", ErrorMessage = "Permitido solamente: jpg, jpeg y png.")]
        [MaxFileSize(1048576)]
        public HttpPostedFileBase UploadedPhoto { get; set; }

        public string Photo { get; set; }

        [MaxLength(100, ErrorMessage = "Máximo 100 caracteres.")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Completar este campo.")]
        [MaxLength(100, ErrorMessage = "Máximo 100 caracteres.")]
        public string City { get; set; }

        [DataType(DataType.PostalCode)]
        [Range(1, 99999, ErrorMessage = "Máximo 5 números.")]
        public int? PostalCode { get; set; }

        [Range(1, 9999, ErrorMessage = "Máximo 4 números.")]
        public short? AreaCodeLP { get; set; }

        [DataType(DataType.PhoneNumber)]
        [Range(1, 9999999999, ErrorMessage = "Máximo 10 números.")]
        public int? LinePhone { get; set; }

        [Range(1, 9999, ErrorMessage = "Máximo 4 números.")]
        public short? AreaCodeMP { get; set; }

        [DataType(DataType.PhoneNumber)]
        [Range(1, 9999999999, ErrorMessage = "Máximo 10 números.")]
        public int? MobilePhone { get; set; }
        public int? Day { get; set; }
        public string Month { get; set; }
        public int? Year { get; set; }

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

        public PersonalDetailsViewModel()
        {
            base.FormId = FormIds.PersonalDetails;
            base.Type = FormType.ADD;
            this.SummaryIsVisible = true;
        }
    }
}
