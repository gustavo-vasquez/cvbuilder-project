using CVBuilder.Data;
using CVBuilder.Services.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CVBuilder.Services
{
    public class PersonalDetailsSL
    {
        private PersonalDetailsDL _dataLayer = new PersonalDetailsDL();

        public int Create(PersonalDetailsDTO dto)
        {
            PersonalDetails data = new PersonalDetails();
            data.Name = dto.Name;
            data.LastName = dto.LastName;
            data.Email = dto.Email;
            data.City = dto.City;
            data.Summary = dto.Summary;
            data.SummaryIsVisible = dto.SummaryIsVisible;
            data.ID_Curriculum = 1;

            return _dataLayer.Create(data);
        }

        public PersonalDetailsDTO GetPersonalDetailsByCurriculumId(int id)
        {
            PersonalDetails data = _dataLayer.GetPersonalDetailsByCurriculumId(id);

            return new PersonalDetailsDTO()
            {
                Name = data.Name,
                LastName = data.LastName,
                Photo = data.Photo,
                Summary = data.Summary,
                SummaryCustomTitle = data.SummaryCustomTitle,
                SummaryIsVisible = data.SummaryIsVisible,
                Email = data.Email,
                LinePhone = data.LinePhone,
                AreaCodeLP = data.AreaCodeLP,
                MobilePhone = data.MobilePhone,
                AreaCodeMP = data.AreaCodeMP,
                Address = data.Address,
                City = data.City,
                PostalCode = data.PostalCode,
                BirthDate = data.BirthDate,
                IdentityCard = data.IdentityCard,
                Country = data.Country,
                WebPageUrl = data.WebPageUrl,
                LinkedInUrl = data.LinkedInUrl,
                GithubUrl = data.GithubUrl,
                FacebookUrl = data.FacebookUrl,
                TwitterUrl = data.TwitterUrl
            };
        }
    }
}
