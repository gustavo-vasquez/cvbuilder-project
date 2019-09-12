using CVBuilder.Data;
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
            Studies data = new Studies();
            data.Title = dto.Title;
            data.Institute = dto.Institute;
            data.City = dto.City;
            data.StartMonth = dto.StartMonth;
            data.StartYear = dto.StartYear;
            data.EndMonth = dto.EndMonth;
            data.EndYear = dto.EndYear;
            data.Description = dto.Description;
            data.IsVisible = dto.IsVisible;
            data.ID_Curriculum = 1;

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
                Description = data.Description
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
