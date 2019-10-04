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
    public class LanguagesSL : ICurriculumServices<LanguagesDTO>
    {
        private LanguagesDL _dataLayer = new LanguagesDL();

        public int Create(LanguagesDTO dto)
        {
            Languages data = Mapping.Mapper.Map<LanguagesDTO, Languages>(dto);
            return _dataLayer.Create(data);
        }

        public void Update(LanguagesDTO dto)
        {
            _dataLayer.Update(Mapping.Mapper.Map<LanguagesDTO, Languages>(dto));
        }

        public int Delete(int id)
        {
            return _dataLayer.Delete(id);
        }

        public LanguagesDTO GetById(int id)
        {
            Languages data = _dataLayer.GetById(id);
            return Mapping.Mapper.Map<Languages, LanguagesDTO>(data);
        }

        public List<SummaryBlockDTO> GetAllBlocks()
        {
            IQueryable<Languages> allLanguages = _dataLayer.GetAll();
            List<SummaryBlockDTO> languageBlocks = new List<SummaryBlockDTO>();

            foreach (Languages language in allLanguages)
            {
                languageBlocks.Add(new SummaryBlockDTO()
                {
                    SummaryId = language.LanguageID,
                    Title = language.Name,
                    StateInTime = "(" + LevelOptions.LevelComboBox[language.Level] + ")"
                });
            }

            return languageBlocks;
        }

        public SummaryBlockDTO GetSummaryBlock(int id)
        {
            Languages language;
            if (id > 0)
                language = _dataLayer.GetById(id);
            else
                language = _dataLayer.GetLast();

            return new SummaryBlockDTO()
            {
                SummaryId = language.LanguageID,
                Title = language.Name,
                StateInTime = "(" + LevelOptions.LevelComboBox[language.Level] + ")"
            };
        }
    }
}
