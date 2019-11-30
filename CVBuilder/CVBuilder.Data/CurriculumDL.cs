using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity.Core.Objects;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CVBuilder.Data
{
    public class CurriculumDL
    {
        private IDatabaseConnection _db = new DatabaseConnection();

        public int Create(string userId)
        {
            ObjectParameter id_curriculum_inserted = new ObjectParameter("id_curriculum_inserted", typeof(int));
            _db.Context.usp_Curriculum_Create(userId, id_curriculum_inserted);

            return (int)id_curriculum_inserted.Value;
        }

        public int GetCurriculumId(string userId)
        {
            return _db.Context.Curriculum.SingleOrDefault(c => c.ID_User == userId).CurriculumID;
        }
    }
}
