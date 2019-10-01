using CVBuilder.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CVBuilder.ViewModels.Curriculum
{
    interface ISectionViewModel
    {
        string FormId { get; set; }
        FormType Type { get; set; }
    }
}
