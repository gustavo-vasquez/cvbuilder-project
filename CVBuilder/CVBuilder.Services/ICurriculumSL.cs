using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CVBuilder.Services
{
    interface ICurriculumSL
    {
        PersonalDetailsSL PersonalDetails { get; set; }
        StudiesSL Studies { get; set; }
        CertificatesSL Certificates { get; set; }
        WorkExperiencesSL WorkExperiences { get; set; }
        LanguagesSL Languages { get; set; }
        SkillsSL Skills { get; set; }
        PersonalReferencesSL PersonalReferences { get; set; }
        CustomSectionsSL CustomSections { get; set; }
    }
}
