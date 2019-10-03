using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CVBuilder.Data
{
    interface ICurriculumData<T> where T : class
    {
        int Create(T data);
        void Update(T data);
        int Delete(int id);
        T GetById(int id);
        IQueryable<T> GetAll();
        T GetLast();
    }
}
