using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CVBuilder.Data
{
    public class DatabaseConnection : IDatabaseConnection
    {
        public CVBuilderEntities Context { get; set; }

        public DatabaseConnection()
        {
            OpenDb();
        }

        public void OpenDb()
        {
            Context = new CVBuilderEntities();
        }

        public void CloseDb(CVBuilderEntities context)
        {
            Context.Dispose();
        }
    }
}
