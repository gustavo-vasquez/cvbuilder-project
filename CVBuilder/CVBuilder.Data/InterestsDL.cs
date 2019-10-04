using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CVBuilder.Data
{
    public class InterestsDL : DataLayerBase, ICurriculumData<Interests>
    {
        public int Create(Interests data)
        {
            int result = _db.Context.usp_Interests_Create(
                    data.Name,
                    data.IsVisible,
                    data.ID_Curriculum
                );

            return result;
        }

        public void Update(Interests data)
        {
            _db.Context.usp_Interests_Update(
                    data.InterestID,
                    data.Name,
                    data.IsVisible,
                    data.ID_Curriculum
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

        public IQueryable<Interests> GetAll()
        {
            return _db.Context.Interests.Where(s => s.ID_Curriculum == 1);
        }

        public Interests GetLast()
        {
            return _db.Context.Interests.OrderByDescending(p => p.InterestID).First();
        }
    }
}
