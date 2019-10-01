using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CVBuilder.Data
{
    public abstract class DataLayerBase
    {
        protected IDatabaseConnection _db = new DatabaseConnection();
    }
}
