using CVBuilder.Services.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CVBuilder.ViewModels.Curriculum
{
    public class BuildViewModel
    {
        public PersonalDetailsViewModel PersonalDetails { get; set; }
        public List<StudiesViewModel> Studies { get; set; }
        public List<CertificatesViewModel> Certificates { get; set; }
        public List<WorkExperiencesViewModel> WorkExperiences { get; set; }
        public List<LanguagesViewModel> Languages { get; set; }
        public List<SkillsViewModel> Skills { get; set; }
        public List<InterestsViewModel> Interests { get; set; }
        public List<PersonalReferencesViewModel> PersonalReferences { get; set; }
        public List<CustomSectionsViewModel> CustomSections { get; set; }
    }
}