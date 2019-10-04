using CVBuilder.Common;
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
    public class InterestsSL : ICurriculumServices<InterestsDTO>
    {
        private InterestsDL _dataLayer = new InterestsDL();

        public int Create(InterestsDTO dto)
        {
            Interests data = Mapping.Mapper.Map<InterestsDTO, Interests>(dto);
            return _dataLayer.Create(data);
        }

        public void Update(InterestsDTO dto)
        {
            _dataLayer.Update(Mapping.Mapper.Map<InterestsDTO, Interests>(dto));
        }

        public int Delete(int id)
        {
            return _dataLayer.Delete(id);
        }

        public InterestsDTO GetById(int id)
        {
            Interests data = _dataLayer.GetById(id);
            return Mapping.Mapper.Map<Interests, InterestsDTO>(data);
        }

        public List<SummaryBlockDTO> GetAllBlocks()
        {
            IQueryable<Interests> allInterests = _dataLayer.GetAll();
            List<SummaryBlockDTO> interestBlocks = new List<SummaryBlockDTO>();

            foreach (Interests interest in allInterests)
            {
                interestBlocks.Add(new SummaryBlockDTO()
                {
                    SummaryId = interest.InterestID,
                    Title = interest.Name
                });
            }

            return interestBlocks;
        }

        public SummaryBlockDTO GetSummaryBlock(int id)
        {
            Interests interest;
            if (id > 0)
                interest = _dataLayer.GetById(id);
            else
                interest = _dataLayer.GetLast();

            return new SummaryBlockDTO()
            {
                SummaryId = interest.InterestID,
                Title = interest.Name
            };
        }
    }
}
