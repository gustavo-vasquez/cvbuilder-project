using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CVBuilder.Data
{
    public class SkillsDL : DataLayerBase, ICurriculumData<Skills>
    {
        public int Create(Skills data)
        {
            int result = _db.Context.usp_Skills_Create(
                    data.Name,
                    data.Level,
                    data.IsVisible,
                    data.ID_Curriculum
                );

            return result;
        }

        public void Update(Skills data)
        {
            _db.Context.usp_Skills_Update(
                    data.SkillID,
                    data.Name,
                    data.Level,
                    data.IsVisible,
                    data.ID_Curriculum
                );
        }

        public int Delete(int id)
        {
            int result = _db.Context.usp_Skills_Delete(id);
            return result;
        }

        public Skills GetById(int id)
        {
            return _db.Context.Skills.Find(id);
        }

        public IQueryable<Skills> GetAll()
        {
            return _db.Context.Skills.Where(s => s.ID_Curriculum == 1);
        }

        public Skills GetLast()
        {
            return _db.Context.Skills.OrderByDescending(p => p.SkillID).First();
        }
    }
}
