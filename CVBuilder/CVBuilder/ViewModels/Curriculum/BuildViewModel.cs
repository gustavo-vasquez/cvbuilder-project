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
        public List<SummaryBlockViewModel> WorkExperienceBlocks { get; set; }
        public List<SummaryBlockViewModel> LanguageBlocks { get; set; }
        public List<SummaryBlockViewModel> SkillBlocks { get; set; }
        public List<SummaryBlockViewModel> InterestBlocks { get; set; }
        public List<SummaryBlockViewModel> PersonalReferenceBlocks { get; set; }
        public List<SummaryBlockViewModel> CustomSectionBlocks { get; set; }

        public BuildViewModel()
        {
            PersonalDetails = new PersonalDetailsViewModel();
            StudyBlocks = new List<SummaryBlockViewModel>();
            CertificateBlocks = new List<SummaryBlockViewModel>();
            WorkExperienceBlocks = new List<SummaryBlockViewModel>();
            LanguageBlocks = new List<SummaryBlockViewModel>();
            SkillBlocks = new List<SummaryBlockViewModel>();
            InterestBlocks = new List<SummaryBlockViewModel>();
            PersonalReferenceBlocks = new List<SummaryBlockViewModel>();
            CustomSectionBlocks = new List<SummaryBlockViewModel>();
        }
    }
}