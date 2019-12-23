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
    public class WorkExperiencesSL : ICurriculumServices<WorkExperiencesDTO>
    {
        private WorkExperiencesDL _dataLayer = new WorkExperiencesDL();

        public int Create(WorkExperiencesDTO dto, int curriculumId)
        {
            WorkExperiences data = Mapping.Mapper.Map<WorkExperiencesDTO, WorkExperiences>(dto);

            return _dataLayer.Create(data, curriculumId);
        }

        public void Update(WorkExperiencesDTO dto, int curriculumId)
        {
            _dataLayer.Update(Mapping.Mapper.Map<WorkExperiencesDTO, WorkExperiences>(dto), curriculumId);
        }

        public int Delete(int id)
        {
            return _dataLayer.Delete(id);
        }

        public WorkExperiencesDTO GetById(int id)
        {
            WorkExperiences data = _dataLayer.GetById(id);
            return Mapping.Mapper.Map<WorkExperiences, WorkExperiencesDTO>(data);
        }

        public List<WorkExperiencesDTO> GetAll(int curriculumId)
        {
            return Mapping.Mapper.Map<List<WorkExperiences>, List<WorkExperiencesDTO>>(_dataLayer.GetAll(curriculumId).ToList());
        }

        public List<WorkExperiencesDTO> GetAllVisible(int curriculumId)
        {
            return Mapping.Mapper.Map<List<WorkExperiences>, List<WorkExperiencesDTO>>(_dataLayer.GetAllVisible(curriculumId).ToList());
        }

        public List<SummaryBlockDTO> GetAllBlocks(int curriculumId)
        {
            IQueryable<WorkExperiences> allWorkExperiences = _dataLayer.GetAll(curriculumId);
            List<SummaryBlockDTO> workExperienceBlocks = new List<SummaryBlockDTO>();

            foreach (WorkExperiences workExperience in allWorkExperiences)
            {
                workExperienceBlocks.Add(new SummaryBlockDTO()
                {
                    SummaryId = workExperience.WorkExperienceID,
                    Title = workExperience.Job + " en " + workExperience.Company,
                    StateInTime = CurriculumGlobals.GenerateStateInTimeFormat(workExperience.StartMonth, workExperience.StartYear, workExperience.EndMonth, workExperience.EndYear),
                    IsVisible = workExperience.IsVisible
                });
            }

            return workExperienceBlocks;
        }

        public SummaryBlockDTO GetSummaryBlock(int id)
        {
            WorkExperiences workExperience;
            if (id > 0)
                workExperience = _dataLayer.GetById(id);
            else
                workExperience = _dataLayer.GetLast();

            return new SummaryBlockDTO()
            {
                SummaryId = workExperience.WorkExperienceID,
                Title = workExperience.Job + " en " + workExperience.Company,
                StateInTime = CurriculumGlobals.GenerateStateInTimeFormat(workExperience.StartMonth, workExperience.StartYear, workExperience.EndMonth, workExperience.EndYear),
                IsVisible = workExperience.IsVisible
            };
        }

        public void ToggleVisibility(int curriculumId)
        {
            _dataLayer.ToggleVisibility(curriculumId);
        }
    }
}
