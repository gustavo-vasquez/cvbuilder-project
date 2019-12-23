using CVBuilder.Data;
using CVBuilder.Services.automapper;
using CVBuilder.Services.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CVBuilder.Services
{
    public class CurriculumSL : ICurriculumSL
    {
        public PersonalDetailsSL PersonalDetails { get; set; }
        public StudiesSL Studies { get; set; }
        public CertificatesSL Certificates { get; set; }
        public WorkExperiencesSL WorkExperiences { get; set; }
        public LanguagesSL Languages { get; set; }
        public SkillsSL Skills { get; set; }
        public InterestsSL Interests { get; set; }
        public PersonalReferencesSL PersonalReferences { get; set; }
        public CustomSectionsSL CustomSections { get; set; }
        public TemplatesSL Templates { get; set; }

        public CurriculumSL()
        {
            PersonalDetails = new PersonalDetailsSL();
            Studies = new StudiesSL();
            Certificates = new CertificatesSL();
            WorkExperiences = new WorkExperiencesSL();
            Languages = new LanguagesSL();
            Skills = new SkillsSL();
            Interests = new InterestsSL();
            PersonalReferences = new PersonalReferencesSL();
            CustomSections = new CustomSectionsSL();
            Templates = new TemplatesSL();
        }

        public static int Create(string userId)
        {
            return new Data.CurriculumDL().Create(userId);
        }

        public int GetCurriculumId(string userId)
        {
            return new Data.CurriculumDL().GetCurriculumId(userId);
        }

        public SectionVisibilityDTO GetVisibilityStates(int curriculumId)
        {
            Curriculum curriculum = new Data.CurriculumDL().GetCurriculumById(curriculumId);
            return Mapping.Mapper.Map<Curriculum, SectionVisibilityDTO>(curriculum);
        }

        public FinishedDTO GetCurriculumContent(string userId, int curriculumId)
        {
            FinishedDTO dto = new FinishedDTO();
            TemplatesDTO template = Templates.GetByUserId(userId);
            dto.TemplateId = template.TemplateID;
            dto.Name = template.Name;
            dto.PreviewPath = template.PreviewPath;
            dto.PersonalDetails = PersonalDetails.GetPersonalDetailsByCurriculumId(curriculumId);
            dto.Studies = Studies.GetAllVisible(curriculumId);
            dto.WorkExperiences = WorkExperiences.GetAllVisible(curriculumId);
            dto.Certificates = Certificates.GetAllVisible(curriculumId);
            dto.PersonalReferences = PersonalReferences.GetAllVisible(curriculumId);
            dto.Languages = Languages.GetAllVisible(curriculumId);
            dto.Skills = Skills.GetAllVisible(curriculumId);
            dto.Interests = Interests.GetAll(curriculumId);
            dto.CustomSections = CustomSections.GetAllVisible(curriculumId);
            dto.SectionVisibility = GetVisibilityStates(curriculumId);

            return dto;
        }
    }
}