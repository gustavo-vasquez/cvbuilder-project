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

        public int Create(InterestsDTO dto, int curriculumId)
        {
            Interests data = Mapping.Mapper.Map<InterestsDTO, Interests>(dto);
            return _dataLayer.Create(data, curriculumId);
        }

        public void Update(InterestsDTO dto, int curriculumId)
        {
            _dataLayer.Update(Mapping.Mapper.Map<InterestsDTO, Interests>(dto), curriculumId);
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

        public List<InterestsDTO> GetAll(int curriculumId)
        {
            return Mapping.Mapper.Map<List<Interests>, List<InterestsDTO>>(_dataLayer.GetAll(curriculumId).ToList());
        }

        public List<SummaryBlockDTO> GetAllBlocks(int curriculumId)
        {
            IQueryable<Interests> allInterests = _dataLayer.GetAll(curriculumId);
            List<SummaryBlockDTO> interestBlocks = new List<SummaryBlockDTO>();

            foreach (Interests interest in allInterests)
            {
                interestBlocks.Add(new SummaryBlockDTO()
                {
                    SummaryId = interest.InterestID,
                    Title = interest.Name,
                    IsVisible = interest.IsVisible
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
                Title = interest.Name,
                IsVisible = interest.IsVisible
            };
        }

        public void ToggleVisibility(int curriculumId)
        {
            _dataLayer.ToggleVisibility(curriculumId);
        }
    }
}
