using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CVBuilder.Data
{
    public class CurriculumDL
    {
        private IDatabaseConnection _db = new DatabaseConnection();

        public Curriculum GetById(int id)
        {
            return _db.Context.Curriculum.Find(id);
        }
    }
}
