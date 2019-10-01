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
        public List<SummaryBlockViewModel> StudyBlocks { get; set; }
        public List<SummaryBlockViewModel> CertificateBlocks { get; set; }
        public List<SummaryBlockViewModel> WorkExperiencesBlocks { get; set; }
        public List<LanguagesViewModel> Languages { get; set; }
        public List<SkillsViewModel> Skills { get; set; }
        public List<InterestsViewModel> Interests { get; set; }
        public List<PersonalReferencesViewModel> PersonalReferences { get; set; }
        public List<CustomFieldsViewModel> CustomFields { get; set; }

        public BuildViewModel()
        {
            PersonalDetails = new PersonalDetailsViewModel();
            StudyBlocks = new List<SummaryBlockViewModel>();
            CertificateBlocks = new List<SummaryBlockViewModel>();
            WorkExperiencesBlocks = new List<SummaryBlockViewModel>();
            Languages = new List<LanguagesViewModel>();
            Skills = new List<SkillsViewModel>();
            Interests = new List<InterestsViewModel>();
            PersonalReferences = new List<PersonalReferencesViewModel>();
            CustomFields = new List<CustomFieldsViewModel>();
        }
    }
}