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
                    StateInTime = GenerateStateInTimeFormat(study.StartMonth, study.StartYear, study.EndMonth, study.EndYear)
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
                StateInTime = GenerateStateInTimeFormat(study.StartMonth, study.StartYear, study.EndMonth, study.EndYear)
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
