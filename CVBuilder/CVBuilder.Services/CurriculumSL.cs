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
        public CertificatesSL Certificates { get; set; }
        public WorkExperiencesSL WorkExperiences { get; set; }

        public CurriculumSL()
        {
            PersonalDetails = new PersonalDetailsSL();
            Studies = new StudiesSL();
            Certificates = new CertificatesSL();
            WorkExperiences = new WorkExperiencesSL();
        }
    }
}
