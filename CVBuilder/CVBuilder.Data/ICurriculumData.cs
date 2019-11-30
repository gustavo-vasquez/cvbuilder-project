using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CVBuilder.Data
{
    interface ICurriculumData<T> where T : class
    {
        int Create(T data, int curriculumId);
        void Update(T data, int curriculumId);
        int Delete(int id);
        T GetById(int id);
        IQueryable<T> GetAll(int curriculumId);
        T GetLast();
    }
}
