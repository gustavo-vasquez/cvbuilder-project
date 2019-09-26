using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CVBuilder.Services
{
    interface ICurriculumServices
    {
        PersonalDetailsSL PersonalDetails { get; set; }
        StudiesSL Studies { get; set; }
    }
}
