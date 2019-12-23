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
    public class StudiesSL : ICurriculumServices<StudiesDTO>
    {
        private StudiesDL _dataLayer = new StudiesDL();

        public int Create(StudiesDTO dto, int curriculumId)
        {
            Studies data = Mapping.Mapper.Map<StudiesDTO, Studies>(dto);
            return _dataLayer.Create(data, curriculumId);
        }

        public void Update(StudiesDTO dto, int curriculumId)
        {
            _dataLayer.Update(Mapping.Mapper.Map<StudiesDTO, Studies>(dto), curriculumId);
        }

        public int Delete(int id)
        {
            return _dataLayer.Delete(id);
        }

        public StudiesDTO GetById(int id)
        {
            Studies data = _dataLayer.GetById(id);
            return Mapping.Mapper.Map<Studies, StudiesDTO>(data);
        }

        public List<StudiesDTO> GetAll(int curriculumId)
        {
            return Mapping.Mapper.Map<List<Studies>, List<StudiesDTO>>(_dataLayer.GetAll(curriculumId).ToList());
        }

        public List<StudiesDTO> GetAllVisible(int curriculumId)
        {
            return Mapping.Mapper.Map<List<Studies>, List<StudiesDTO>>(_dataLayer.GetAllVisible(curriculumId).ToList());
        }

        public List<SummaryBlockDTO> GetAllBlocks(int curriculumId)
        {
            IQueryable<Studies> allStudies = _dataLayer.GetAll(curriculumId);
            List<SummaryBlockDTO> studyBlocks = new List<SummaryBlockDTO>();

            foreach(Studies study in allStudies)
            {
                studyBlocks.Add(new SummaryBlockDTO()
                {
                    SummaryId = study.StudyID,
                    Title = study.Title,
                    StateInTime = CurriculumGlobals.GenerateStateInTimeFormat(study.StartMonth, study.StartYear, study.EndMonth, study.EndYear),
                    IsVisible = study.IsVisible
                });
            }

            return studyBlocks;
        }

        public SummaryBlockDTO GetSummaryBlock(int id)
        {
            Studies study;
            if (id > 0)
                study = _dataLayer.GetById(id);
            else
                study = _dataLayer.GetLast();

            return new SummaryBlockDTO()
            {
                SummaryId = study.StudyID,
                Title = study.Title,
                StateInTime = CurriculumGlobals.GenerateStateInTimeFormat(study.StartMonth, study.StartYear, study.EndMonth, study.EndYear),
                IsVisible = study.IsVisible
            };
        }

        public void ToggleVisibility(int curriculumId)
        {
            _dataLayer.ToggleVisibility(curriculumId);
        }
    }
}
