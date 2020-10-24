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

        [Required(ErrorMessage = ValMessages.FIELD_REQUIRED)]
        [MaxLength(100, ErrorMessage = ValMessages.MAX + "100" + ValMessages.CHARACTERS)]
        public string Name { get; set; }

        [Required(ErrorMessage = ValMessages.FIELD_REQUIRED)]
        [MaxLength(100, ErrorMessage = ValMessages.MAX + "100" + ValMessages.CHARACTERS)]
        public string LastName { get; set; }

        [Required(ErrorMessage = ValMessages.FIELD_REQUIRED)]
        [MaxLength(100, ErrorMessage = ValMessages.MAX + "100" + ValMessages.CHARACTERS)]
        public string Email { get; set; }

        public string Profession { get; set; }

        [PostedFileExtensions("jpg,jpeg,png", ErrorMessage = "Permitido solamente: jpg, jpeg y png.")]
        [MaxFileSize(1048576)]
        public HttpPostedFileBase UploadedPhoto { get; set; }

        public string Photo { get; set; }

        [MaxLength(100, ErrorMessage = ValMessages.MAX + "100" + ValMessages.CHARACTERS)]
        public string Address { get; set; }

        [Required(ErrorMessage = ValMessages.FIELD_REQUIRED)]
        [MaxLength(100, ErrorMessage = ValMessages.MAX + "100" + ValMessages.CHARACTERS)]
        public string City { get; set; }

        [DataType(DataType.PostalCode)]
        [Range(1, 99999, ErrorMessage = ValMessages.MAX + "5" + ValMessages.NUMBERS)]
        public int? PostalCode { get; set; }

        [Range(1, 9999, ErrorMessage = ValMessages.MAX + "4" + ValMessages.NUMBERS)]
        public short? AreaCodeLP { get; set; }

        [DataType(DataType.PhoneNumber)]
        [Range(1, 99999999, ErrorMessage = ValMessages.MAX + "8" + ValMessages.NUMBERS)]
        public int? LinePhone { get; set; }

        [Range(1, 9999, ErrorMessage = ValMessages.MAX + "4" + ValMessages.NUMBERS)]
        public short? AreaCodeMP { get; set; }

        [DataType(DataType.PhoneNumber)]
        [Range(1, 99999999, ErrorMessage = ValMessages.MAX + "8" + ValMessages.NUMBERS)]
        public int? MobilePhone { get; set; }
        public int? Day { get; set; }
        public string Month { get; set; }
        public int? Year { get; set; }

        [MaxLength(100, ErrorMessage = ValMessages.MAX + "100" + ValMessages.CHARACTERS)]
        public string Country { get; set; }

        [Required(ErrorMessage = ValMessages.FIELD_REQUIRED)]
        [MaxLength(300, ErrorMessage = ValMessages.MAX + "300" + ValMessages.CHARACTERS)]
        public string Summary { get; set; }

        [MaxLength(50, ErrorMessage = ValMessages.MAX + "50" + ValMessages.CHARACTERS)]
        public string SummaryCustomTitle { get; set; }
        public bool SummaryIsVisible { get; set; }

        [MaxLength(300, ErrorMessage = ValMessages.MAX + "300" + ValMessages.CHARACTERS)]
        public string WebPageUrl { get; set; }

        [MaxLength(300, ErrorMessage = ValMessages.MAX + "300" + ValMessages.CHARACTERS)]
        public string LinkedInUrl { get; set; }

        [MaxLength(300, ErrorMessage = ValMessages.MAX + "300" + ValMessages.CHARACTERS)]
        public string GithubUrl { get; set; }

        [MaxLength(300, ErrorMessage = ValMessages.MAX + "300" + ValMessages.CHARACTERS)]
        public string FacebookUrl { get; set; }

        [MaxLength(300, ErrorMessage = ValMessages.MAX + "300" + ValMessages.CHARACTERS)]
        public string TwitterUrl { get; set; }

        public PersonalDetailsViewModel()
        {
            base.FormId = FormIds.PersonalDetails;
            base.Type = FormType.ADD;
            this.SummaryIsVisible = true;
        }
    }
}
