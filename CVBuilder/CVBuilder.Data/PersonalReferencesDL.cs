using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CVBuilder.Data
{
    public class PersonalReferencesDL : DataLayerBase, ICurriculumData<PersonalReferences>
    {
        public int Create(PersonalReferences data)
        {
            int result = _db.Context.usp_PersonalReferences_Create(
                    data.Company,
                    data.ContactPerson,
                    data.AreaCode,
                    data.Telephone,
                    data.Email,
                    data.IsVisible,
                    data.ID_Curriculum
                );

            return result;
        }

        public void Update(PersonalReferences data)
        {
            _db.Context.usp_PersonalReferences_Update(
                    data.PersonalReferenceID,
                    data.Company,
                    data.ContactPerson,
                    data.AreaCode,
                    data.Telephone,
                    data.Email,
                    data.IsVisible,
                    data.ID_Curriculum
                );
        }

        public int Delete(int id)
        {
            int result = _db.Context.usp_PersonalReferences_Delete(id);
            return result;
        }

        public PersonalReferences GetById(int id)
        {
            return _db.Context.PersonalReferences.Find(id);
        }

        public IQueryable<PersonalReferences> GetAll()
        {
            return _db.Context.PersonalReferences.Where(s => s.ID_Curriculum == 1);
        }

        public PersonalReferences GetLast()
        {
            return _db.Context.PersonalReferences.OrderByDescending(p => p.PersonalReferenceID).First();
        }
    }
}
