using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CVBuilder.ViewModels.Curriculum
{
    public class SectionVisibilityModel
    {
        public bool StudiesIsVisible { get; set; }
        public bool WorkExperiencesIsVisible { get; set; }
        public bool CertificatesIsVisible { get; set; }
        public bool LanguagesIsVisible { get; set; }
        public bool SkillsIsVisible { get; set; }
        public bool InterestsIsVisible { get; set; }
        public bool PersonalReferencesIsVisible { get; set; }
        public bool CustomSectionsIsVisible { get; set; }
    }
}