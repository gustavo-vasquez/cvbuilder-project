using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CVBuilder.Data
{
    public class LanguagesDL : DataLayerBase, ICurriculumData<Languages>
    {
        public int Create(Languages data)
        {
            int result = _db.Context.usp_Languages_Create(
                    data.Name,
                    data.Level,
                    data.IsVisible,
                    data.ID_Curriculum
                );

            return result;
        }

        public void Update(Languages data)
        {
            _db.Context.usp_Languages_Update(
                    data.LanguageID,
                    data.Name,
                    data.Level,
                    data.IsVisible,
                    data.ID_Curriculum
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

        public IQueryable<Languages> GetAll()
        {
            return _db.Context.Languages.Where(s => s.ID_Curriculum == 1);
        }

        public Languages GetLast()
        {
            return _db.Context.Languages.OrderByDescending(p => p.LanguageID).First();
        }
    }
}
