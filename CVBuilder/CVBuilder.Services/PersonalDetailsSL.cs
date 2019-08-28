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
    }
}
