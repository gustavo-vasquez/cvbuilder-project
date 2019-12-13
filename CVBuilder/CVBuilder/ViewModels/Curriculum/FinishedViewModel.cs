using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CVBuilder.ViewModels.Curriculum
{
    public class FinishedViewModel
    {
        public int TemplateId { get; set; }
        public string Name { get; set; }
        public string PreviewPath { get; set; }
        public PersonalDetailsDisplay PersonalDetails { get; set; }
        public IEnumerable<StudiesDisplay> Studies { get; set; }
        public IEnumerable<WorkExperiencesDisplay> WorkExperiences { get; set; }
        public IEnumerable<CertificatesDisplay> Certificates { get; set; }
        public IEnumerable<LanguagesDisplay> Languages { get; set; }
        public IEnumerable<SkillsDisplay> Skills { get; set; }
        public IEnumerable<InterestsDisplay> Interests { get; set; }
        public IEnumerable<PersonalReferencesDisplay> PersonalReferences { get; set; }
        public IEnumerable<CustomSectionsDisplay> CustomSections { get; set; }
    }

    public class PersonalDetailsDisplay
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Photo { get; set; }
        public string LinePhone { get; set; }
        public string MobilePhone { get; set; }
        public int? IdentityCard { get; set; }
        public string Location { get; set; }
        public string Summary { get; set; }
        public string SummaryCustomTitle { get; set; }
        public bool SummaryIsVisible { get; set; }
        public string WebPageUrl { get; set; }
        public string LinkedInUrl { get; set; }
        public string GithubUrl { get; set; }
        public string FacebookUrl { get; set; }
        public string TwitterUrl { get; set; }
    }

    public class StudiesDisplay
    {
        public string Title { get; set; }
        public string Institute { get; set; }
        public string City { get; set; }
        public string StateInTime { get; set; }
        public string Description { get; set; }
        public bool IsVisible { get; set; }
    }

    public class WorkExperiencesDisplay
    {
        public string Job { get; set; }
        public string City { get; set; }
        public string Company { get; set; }
        public string StateInTime { get; set; }
        public string Description { get; set; }
        public bool IsVisible { get; set; }
    }

    public class CertificatesDisplay
    {
        public string Name { get; set; }
        public string Institute { get; set; }
        public bool OnlineMode { get; set; }
        public bool InProgress { get; set; }
        public int? Year { get; set; }
        public string Description { get; set; }
        public bool IsVisible { get; set; }
    }

    public class LanguagesDisplay
    {
        public string Name { get; set; }
        public string Level { get; set; }
        public bool IsVisible { get; set; }
    }

    public class SkillsDisplay
    {
        public string Name { get; set; }
        public string Level { get; set; }
        public bool IsVisible { get; set; }
    }

    public class InterestsDisplay
    {
        public string Name { get; set; }
        public bool IsVisible { get; set; }
    }

    public class PersonalReferencesDisplay
    {
        public string Company { get; set; }
        public string ContactPerson { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public bool IsVisible { get; set; }
    }

    public class CustomSectionsDisplay
    {
        public string SectionName { get; set; }
        public string Description { get; set; }
        public bool IsVisible { get; set; }
    }
}