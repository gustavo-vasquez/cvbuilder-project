using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CVBuilder.Services.DTOs
{
    public class FinishedDTO
    {
        public int TemplateId { get; set; }
        public string Name { get; set; }
        public string PreviewPath { get; set; }
        public PersonalDetailsDTO PersonalDetails { get; set; }
        public List<StudiesDTO> Studies { get; set; }
        public List<WorkExperiencesDTO> WorkExperiences { get; set; }
        public List<CertificatesDTO> Certificates { get; set; }
        public List<LanguagesDTO> Languages { get; set; }
        public List<SkillsDTO> Skills { get; set; }
        public List<InterestsDTO> Interests { get; set; }
        public List<PersonalReferencesDTO> PersonalReferences { get; set; }
        public List<CustomSectionsDTO> CustomSections { get; set; }
    }
}
