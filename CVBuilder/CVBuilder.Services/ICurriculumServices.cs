using CVBuilder.Services.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CVBuilder.Services
{
    interface ICurriculumServices<T> where T : class
    {
        int Create(T data, int curriculumId);
        void Update(T data, int curriculumId);
        int Delete(int id);
        T GetById(int id);
        List<SummaryBlockDTO> GetAllBlocks(int curriculumId);
        SummaryBlockDTO GetSummaryBlock(int id);
    }
}
