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
    public class CustomSectionsSL : ICurriculumServices<CustomSectionsDTO>
    {
        private CustomSectionsDL _dataLayer = new CustomSectionsDL();

        public int Create(CustomSectionsDTO dto)
        {
            CustomSections data = Mapping.Mapper.Map<CustomSectionsDTO, CustomSections>(dto);
            return _dataLayer.Create(data);
        }

        public void Update(CustomSectionsDTO dto)
        {
            _dataLayer.Update(Mapping.Mapper.Map<CustomSectionsDTO, CustomSections>(dto));
        }

        public int Delete(int id)
        {
            return _dataLayer.Delete(id);
        }

        public CustomSectionsDTO GetById(int id)
        {
            CustomSections data = _dataLayer.GetById(id);
            return Mapping.Mapper.Map<CustomSections, CustomSectionsDTO>(data);
        }

        public List<SummaryBlockDTO> GetAllBlocks()
        {
            IQueryable<CustomSections> allCustomSections = _dataLayer.GetAll();
            List<SummaryBlockDTO> customSectionBlocks = new List<SummaryBlockDTO>();

            foreach (CustomSections customSection in allCustomSections)
            {
                customSectionBlocks.Add(new SummaryBlockDTO()
                {
                    SummaryId = customSection.CustomSectionID,
                    Title = customSection.SectionName
                });
            }

            return customSectionBlocks;
        }

        public SummaryBlockDTO GetSummaryBlock(int id)
        {
            CustomSections customSection;
            if (id > 0)
                customSection = _dataLayer.GetById(id);
            else
                customSection = _dataLayer.GetLast();

            return new SummaryBlockDTO()
            {
                SummaryId = customSection.CustomSectionID,
                Title = customSection.SectionName
            };
        }
    }
}
