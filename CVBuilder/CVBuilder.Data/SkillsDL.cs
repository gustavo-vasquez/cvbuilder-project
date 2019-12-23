using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CVBuilder.Data
{
    public class SkillsDL : DataLayerBase, ICurriculumData<Skills>
    {
        public int Create(Skills data, int curriculumId)
        {
            int result = _db.Context.usp_Skills_Create(
                    data.Name,
                    data.Level,
                    data.IsVisible,
                    curriculumId
                );

            return result;
        }

        public void Update(Skills data, int curriculumId)
        {
            _db.Context.usp_Skills_Update(
                    data.SkillID,
                    data.Name,
                    data.Level,
                    data.IsVisible,
                    curriculumId
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

        public IQueryable<Skills> GetAll(int curriculumId)
        {
            return _db.Context.Skills.Where(s => s.ID_Curriculum == curriculumId);
        }

        public IQueryable<Skills> GetAllVisible(int curriculumId)
        {
            return _db.Context.Skills.Where(s => s.ID_Curriculum == curriculumId && s.IsVisible);
        }

        public Skills GetLast()
        {
            return _db.Context.Skills.OrderByDescending(p => p.SkillID).First();
        }

        public void ToggleVisibility(int curriculumId)
        {
            Curriculum curriculum = _db.Context.Curriculum.SingleOrDefault(c => c.CurriculumID == curriculumId);
            curriculum.SkillsIsVisible = curriculum.SkillsIsVisible == true ? false : true;
            _db.Context.SaveChanges();
        }
    }
}