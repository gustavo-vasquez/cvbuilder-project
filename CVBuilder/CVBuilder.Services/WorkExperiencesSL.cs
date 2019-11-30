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
                    StateInTime = GenerateStateInTimeFormat(workExperience.StartMonth, workExperience.StartYear, workExperience.EndMonth, workExperience.EndYear)
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
                StateInTime = GenerateStateInTimeFormat(workExperience.StartMonth, workExperience.StartYear, workExperience.EndMonth, workExperience.EndYear)
            };
        }

        private string GenerateStateInTimeFormat(string startMonth, int? startYear, string endMonth, int? endYear)
        {
            string stateInTime = string.Empty;

            if (startMonth != MonthOptions.None && endMonth != MonthOptions.None)
            {
                string startMonthFormatted = MonthOptions.MonthsComboBox[startMonth];
                string endMonthFormatted = MonthOptions.MonthsComboBox[endMonth];

                switch (startMonth)
                {
                    case MonthOptions.NotShow:
                        if (endMonth != MonthOptions.None && endMonth != MonthOptions.NotShow)
                        {
                            switch (endMonth)
                            {
                                case MonthOptions.Present:
                                    stateInTime = "(" + endMonthFormatted + ")";
                                    break;
                                case MonthOptions.OnlyYear:
                                    stateInTime = "(" + endYear + ")";
                                    break;
                                default:
                                    stateInTime = "(" + endMonthFormatted + " " + endYear + ")";
                                    break;
                            }
                        }
                        break;
                    case MonthOptions.OnlyYear:
                        if (endMonth != MonthOptions.None && endMonth != MonthOptions.NotShow)
                        {
                            switch (endMonth)
                            {
                                case MonthOptions.Present:
                                    stateInTime = "(" + startYear + "-" + endMonthFormatted + ")";
                                    break;
                                case MonthOptions.OnlyYear:
                                    stateInTime = "(" + startYear + "-" + endYear + ")";
                                    break;
                                default:
                                    stateInTime = "(" + startYear + "-" + endMonthFormatted + " " + endYear + ")";
                                    break;
                            }
                        }
                        break;
                    default:
                        if (endMonth != MonthOptions.None && endMonth != MonthOptions.NotShow)
                        {
                            switch (endMonth)
                            {
                                case MonthOptions.Present:
                                    stateInTime = "(" + startMonthFormatted + " " + startYear + "-" + endMonthFormatted + ")";
                                    break;
                                case MonthOptions.OnlyYear:
                                    stateInTime = "(" + startMonthFormatted + " " + startYear + "-" + endYear + ")";
                                    break;
                                default:
                                    stateInTime = "(" + startMonthFormatted + " " + startYear + "-" + endMonthFormatted + " " + endYear + ")";
                                    break;
                            }
                        }
                        break;
                }
            }

            return stateInTime;
        }
    }
}
