using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CVBuilder.Data
{
    public class LanguagesDL : DataLayerBase, ICurriculumData<Languages>
    {
        public int Create(Languages data, int curriculumId)
        {
            int result = _db.Context.usp_Languages_Create(
                    data.Name,
                    data.Level,
                    data.IsVisible,
                    curriculumId
                );

            return result;
        }

        public void Update(Languages data, int curriculumId)
        {
            _db.Context.usp_Languages_Update(
                    data.LanguageID,
                    data.Name,
                    data.Level,
                    data.IsVisible,
                    curriculumId
                );
        }

        public int Delete(int id)
        {
            int result = _db.Context.usp_Languages_Delete(id);
            return result;
        }

        public Languages GetById(int id)
        {
            return _db.Context.Languages.Find(id);
        }

        public IQueryable<Languages> GetAll(int curriculumId)
        {
            return _db.Context.Languages.Where(s => s.ID_Curriculum == curriculumId);
        }

        public IQueryable<Languages> GetAllVisible(int curriculumId)
        {
            return _db.Context.Languages.Where(s => s.ID_Curriculum == curriculumId && s.IsVisible);
        }

        public Languages GetLast()
        {
            return _db.Context.Languages.OrderByDescending(p => p.LanguageID).First();
        }

        public void ToggleVisibility(int curriculumId)
        {
            Curriculum curriculum = _db.Context.Curriculum.SingleOrDefault(c => c.CurriculumID == curriculumId);
            curriculum.LanguagesIsVisible = curriculum.LanguagesIsVisible == true ? false : true;
            _db.Context.SaveChanges();
        }
    }
}
