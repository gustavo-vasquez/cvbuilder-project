using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CVBuilder.Services
{
    public class CurriculumSL : ICurriculumServices
    {
        public PersonalDetailsSL PersonalDetails { get; set; }
        public StudiesSL Studies { get; set; }

        public CurriculumSL()
        {
            this.PersonalDetails = new PersonalDetailsSL();
            this.Studies = new StudiesSL();
        }
    }
}
