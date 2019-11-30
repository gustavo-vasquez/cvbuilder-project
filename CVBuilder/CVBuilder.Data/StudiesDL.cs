using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CVBuilder.Data
{
    public class StudiesDL : DataLayerBase, ICurriculumData<Studies>
    {
        public int Create(Studies data, int curriculumId)
        {
            int result = _db.Context.usp_Studies_Create(
                    data.Title,
                    data.Institute,
                    data.City,
                    data.StartMonth,
                    data.StartYear,
                    data.EndMonth,
                    data.EndYear,
                    data.Description,
                    data.IsVisible,
                    curriculumId
                );

            return result;
        }

        public void Update(Studies data, int curriculumId)
        {
            _db.Context.usp_Studies_Update(
                    data.StudyID,
                    data.Title,
                    data.Institute,
                    data.City,
                    data.StartMonth,
                    data.StartYear,
                    data.EndMonth,
                    data.EndYear,
                    data.Description,
                    data.IsVisible,
                    curriculumId
                );
        }

        public int Delete(int id)
        {
            int result = _db.Context.usp_Studies_Delete(id);
            return result;
        }

        public Studies GetById(int id)
        {
            return _db.Context.Studies.Find(id);
        }

        public IQueryable<Studies> GetAll(int curriculumId)
        {
            return _db.Context.Studies.Where(s => s.ID_Curriculum == curriculumId);
        }

        public Studies GetLast()
        {
            return _db.Context.Studies.OrderByDescending(p => p.StudyID).First();
        }
    }
}
