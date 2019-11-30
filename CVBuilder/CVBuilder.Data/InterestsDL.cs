using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CVBuilder.Data
{
    public class InterestsDL : DataLayerBase, ICurriculumData<Interests>
    {
        public int Create(Interests data, int curriculumId)
        {
            int result = _db.Context.usp_Interests_Create(
                    data.Name,
                    data.IsVisible,
                    curriculumId
                );

            return result;
        }

        public void Update(Interests data, int curriculumId)
        {
            _db.Context.usp_Interests_Update(
                    data.InterestID,
                    data.Name,
                    data.IsVisible,
                    curriculumId
                );
        }

        public int Delete(int id)
        {
            int result = _db.Context.usp_Interests_Delete(id);
            return result;
        }

        public Interests GetById(int id)
        {
            return _db.Context.Interests.Find(id);
        }

        public IQueryable<Interests> GetAll(int curriculumId)
        {
            return _db.Context.Interests.Where(s => s.ID_Curriculum == curriculumId);
        }

        public Interests GetLast()
        {
            return _db.Context.Interests.OrderByDescending(p => p.InterestID).First();
        }
    }
}
