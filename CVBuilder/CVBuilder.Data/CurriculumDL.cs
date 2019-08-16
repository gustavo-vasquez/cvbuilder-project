using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CVBuilder.Data
{
    public class CurriculumDL
    {
        private IDatabaseConnection _db;

        public CurriculumDL(IDatabaseConnection db)
        {
            _db = db;
        }

        public Curriculum GetById(int id)
        {
            return _db.Context.Curriculum.Find(id);
        }
    }
}
