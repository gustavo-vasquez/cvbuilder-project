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

        public BuildViewModel()
        {
            PersonalDetails = new PersonalDetailsViewModel();
            Studies = new List<StudiesViewModel>();
            Certificates = new List<CertificatesViewModel>();
            WorkExperiences = new List<WorkExperiencesViewModel>();
            Languages = new List<LanguagesViewModel>();
            Skills = new List<SkillsViewModel>();
            Interests = new List<InterestsViewModel>();
            PersonalReferences = new List<PersonalReferencesViewModel>();
            CustomSections = new List<CustomSectionsViewModel>();
        }
    }
}