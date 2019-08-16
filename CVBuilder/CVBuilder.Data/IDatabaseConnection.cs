using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CVBuilder.Data
{
    public interface IDatabaseConnection
    {
        CVBuilderEntities Context { get; set; }
        void OpenDb();
        void CloseDb(CVBuilderEntities context);
    }
}
