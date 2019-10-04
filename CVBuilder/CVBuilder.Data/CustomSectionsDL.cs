using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CVBuilder.Data
{
    public class CustomSectionsDL : DataLayerBase, ICurriculumData<CustomSections>
    {
        public int Create(CustomSections data)
        {
            int result = _db.Context.usp_CustomSections_Create(
                    data.SectionName,
                    data.Description,
                    data.IsVisible,
                    data.ID_Curriculum
                );

            return result;
        }

        public void Update(CustomSections data)
        {
            _db.Context.usp_CustomSections_Update(
                    data.CustomSectionID,
                    data.SectionName,
                    data.Description,
                    data.IsVisible,
                    data.ID_Curriculum
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

        public IQueryable<CustomSections> GetAll()
        {
            return _db.Context.CustomSections.Where(s => s.ID_Curriculum == 1);
        }

        public CustomSections GetLast()
        {
            return _db.Context.CustomSections.OrderByDescending(p => p.CustomSectionID).First();
        }
    }
}
