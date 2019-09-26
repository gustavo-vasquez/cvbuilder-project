using CVBuilder.Data;
using CVBuilder.Services.automapper;
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
            PersonalDetails data = Mapping.Mapper.Map<PersonalDetailsDTO, PersonalDetails>(dto);

            return _dataLayer.Create(data);
        }

        public int Update(PersonalDetailsDTO dto)
        {
            PersonalDetails data = Mapping.Mapper.Map<PersonalDetailsDTO, PersonalDetails>(dto);

            return _dataLayer.Update(data);
        }

        public PersonalDetailsDTO GetPersonalDetailsByCurriculumId(int id)
        {
            PersonalDetails data = _dataLayer.GetPersonalDetailsByCurriculumId(id);
            
            if (data != null)
                return Mapping.Mapper.Map<PersonalDetails, PersonalDetailsDTO>(data);

            return null;
        }
    }
}
