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
    public class StudiesSL
    {
        private StudiesDL _dataLayer = new StudiesDL();

        public int Create(StudiesDTO dto)
        {
            Studies data = Mapping.Mapper.Map<StudiesDTO, Studies>(dto);
            return _dataLayer.Create(data);
        }

        public int Remove(int id)
        {
            return _dataLayer.Remove(id);
        }

        public StudiesDTO GetStudyById(int id)
        {
            Studies data = _dataLayer.GetStudyById(id);
            return new StudiesDTO()
            {
                Title = data.Title,
                Institute = data.Institute,
                City = data.City,
                StartMonth = data.StartMonth,
                StartYear = data.StartYear,
                EndMonth = data.EndMonth,
                EndYear = data.EndYear,
                Description = data.Description,
                IsVisible = data.IsVisible
            };
        }

        public List<StudiesDTO> GetAllStudies()
        {
            IQueryable<Studies> allStudies = _dataLayer.GetAllStudies();
            List<StudiesDTO> dto = new List<StudiesDTO>();
            
            foreach(Studies study in allStudies)
            {
                dto.Add(new StudiesDTO()
                {
                    Title = study.Title,
                    Institute = study.Institute,
                    City = study.City,
                    StartMonth = study.StartMonth,
                    StartYear = study.StartYear,
                    EndMonth = study.EndMonth,
                    EndYear = study.EndYear,
                    Description = study.Description,
                    IsVisible = study.IsVisible
                });
            }

            return dto;
        }

        public List<SummaryBlockDTO> GetStudyBlocks()
        {
            IQueryable<Studies> allStudies = _dataLayer.GetAllStudies();
            List<SummaryBlockDTO> studyBlocks = new List<SummaryBlockDTO>();

            foreach(Studies study in allStudies)
            {
                studyBlocks.Add(new SummaryBlockDTO()
                {
                    SummaryId = study.StudyID,
                    Title = study.Title,
                    StateInTime = "Completar luego"
                });
            }

            return studyBlocks;
        }

        public SummaryBlockDTO GetSummaryBlock()
        {
            Studies study = _dataLayer.GetLastStudy();

            return new SummaryBlockDTO()
            {
                SummaryId = study.StudyID,
                Title = study.Title,
                StateInTime = "(Completar después)"
            };
        }
    }
}
