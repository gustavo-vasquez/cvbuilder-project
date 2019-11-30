using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CVBuilder.Data
{
    public class WorkExperiencesDL : DataLayerBase, ICurriculumData<WorkExperiences>
    {
        public int Create(WorkExperiences data, int curriculumId)
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
                    curriculumId
                );

            return result;
        }

        public void Update(WorkExperiences data, int curriculumId)
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
                    curriculumId
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

        public IQueryable<WorkExperiences> GetAll(int curriculumId)
        {
            return _db.Context.WorkExperiences.Where(s => s.ID_Curriculum == curriculumId);
        }

        public WorkExperiences GetLast()
        {
            return _db.Context.WorkExperiences.OrderByDescending(p => p.WorkExperienceID).First();
        }
    }
}
