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
    public class PersonalReferencesSL : ICurriculumServices<PersonalReferencesDTO>
    {
        private PersonalReferencesDL _dataLayer = new PersonalReferencesDL();

        public int Create(PersonalReferencesDTO dto, int curriculumId)
        {
            PersonalReferences data = Mapping.Mapper.Map<PersonalReferencesDTO, PersonalReferences>(dto);
            return _dataLayer.Create(data, curriculumId);
        }

        public void Update(PersonalReferencesDTO dto, int curriculumId)
        {
            _dataLayer.Update(Mapping.Mapper.Map<PersonalReferencesDTO, PersonalReferences>(dto), curriculumId);
        }

        public int Delete(int id)
        {
            return _dataLayer.Delete(id);
        }

        public PersonalReferencesDTO GetById(int id)
        {
            PersonalReferences data = _dataLayer.GetById(id);
            return Mapping.Mapper.Map<PersonalReferences, PersonalReferencesDTO>(data);
        }

        public List<SummaryBlockDTO> GetAllBlocks(int curriculumId)
        {
            IQueryable<PersonalReferences> allPersonalReferences = _dataLayer.GetAll(curriculumId);
            List<SummaryBlockDTO> personalReferenceBlocks = new List<SummaryBlockDTO>();

            foreach (PersonalReferences personalReference in allPersonalReferences)
            {
                personalReferenceBlocks.Add(new SummaryBlockDTO()
                {
                    SummaryId = personalReference.PersonalReferenceID,
                    Title = personalReference.ContactPerson + " desde " + personalReference.Company
                });
            }

            return personalReferenceBlocks;
        }

        public SummaryBlockDTO GetSummaryBlock(int id)
        {
            PersonalReferences personalReference;
            if (id > 0)
                personalReference = _dataLayer.GetById(id);
            else
                personalReference = _dataLayer.GetLast();

            return new SummaryBlockDTO()
            {
                SummaryId = personalReference.PersonalReferenceID,
                Title = personalReference.ContactPerson + " desde " + personalReference.Company
            };
        }
    }
}
