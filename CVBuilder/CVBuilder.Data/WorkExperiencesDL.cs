using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CVBuilder.Data
{
    public class WorkExperiencesDL : DataLayerBase, ICurriculumDL<WorkExperiences>
    {
        public int Create(WorkExperiences data)
        {
            int result = _db.Context.usp_WorkExperiences_Create(
                    data.Job,
                    data.City,
                    data.Company,
                    data.StartMonth,
                    data.StartYear,
                    data.EndMonth,
                    data.EndYear,
                    data.Description,
                    data.IsVisible,
                    data.ID_Curriculum
                );

            return result;
        }

        public void Update(WorkExperiences data)
        {
            _db.Context.usp_WorkExperiences_Update(
                    data.WorkExperienceID,
                    data.Job,
                    data.City,
                    data.Company,
                    data.StartMonth,
                    data.StartYear,
                    data.EndMonth,
                    data.EndYear,
                    data.Description,
                    data.IsVisible,
                    data.ID_Curriculum
                );
        }

        public int Delete(int id)
        {
            int result = _db.Context.usp_WorkExperiences_Delete(id);
            return result;
        }

        public WorkExperiences GetById(int id)
        {
            return _db.Context.WorkExperiences.Find(id);
        }

        public IQueryable<WorkExperiences> GetAll()
        {
            return _db.Context.WorkExperiences.Where(s => s.ID_Curriculum == 1);
        }

        public WorkExperiences GetLast()
        {
            return _db.Context.WorkExperiences.OrderByDescending(p => p.WorkExperienceID).First();
        }
    }
}
