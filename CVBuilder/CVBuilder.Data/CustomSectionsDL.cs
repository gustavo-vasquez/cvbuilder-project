using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CVBuilder.Data
{
    public class CustomSectionsDL : DataLayerBase, ICurriculumData<CustomSections>
    {
        public int Create(CustomSections data, int curriculumId)
        {
            int result = _db.Context.usp_CustomSections_Create(
                    data.SectionName,
                    data.Description,
                    data.IsVisible,
                    curriculumId
                );

            return result;
        }

        public void Update(CustomSections data, int curriculumId)
        {
            _db.Context.usp_CustomSections_Update(
                    data.CustomSectionID,
                    data.SectionName,
                    data.Description,
                    data.IsVisible,
                    curriculumId
                );
        }

        public int Delete(int id)
        {
            int result = _db.Context.usp_CustomSections_Delete(id);
            return result;
        }

        public CustomSections GetById(int id)
        {
            return _db.Context.CustomSections.Find(id);
        }

        public IQueryable<CustomSections> GetAll(int curriculumId)
        {
            return _db.Context.CustomSections.Where(s => s.ID_Curriculum == curriculumId);
        }

        public IQueryable<CustomSections> GetAllVisible(int curriculumId)
        {
            return _db.Context.CustomSections.Where(s => s.ID_Curriculum == curriculumId && s.IsVisible);
        }

        public CustomSections GetLast()
        {
            return _db.Context.CustomSections.OrderByDescending(p => p.CustomSectionID).First();
        }

        public void ToggleVisibility(int curriculumId)
        {
            Curriculum curriculum = _db.Context.Curriculum.SingleOrDefault(c => c.CurriculumID == curriculumId);
            curriculum.CustomSectionsIsVisible = curriculum.CustomSectionsIsVisible == true ? false : true;
            _db.Context.SaveChanges();
        }
    }
}
