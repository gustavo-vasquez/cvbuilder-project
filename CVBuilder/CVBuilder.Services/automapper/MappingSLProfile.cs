using AutoMapper;
using CVBuilder.Data;
using CVBuilder.Services.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CVBuilder.Services.automapper
{
    public class MappingSLProfile : Profile
    {
        public MappingSLProfile()
        {
            CreateMap<PersonalDetailsDTO, PersonalDetails>()
                .ForMember(dest => dest.ID_Curriculum, act => act.UseValue(1))
                .ForMember(dest => dest.BirthDate, act => act.ResolveUsing(src => { return this.GetBirthdateFromValues(src.Year, src.Month, src.Day); }))
                .ForMember(dest => dest.Curriculum, act => act.Ignore());

            CreateMap<PersonalDetails, PersonalDetailsDTO>()
                .ForMember(dest => dest.Year, act => act.ResolveUsing(src => { return src.BirthDate != null ? src.BirthDate.Value.Year : (int?)null; }))
                .ForMember(dest => dest.Month, act => act.ResolveUsing(src => { return src.BirthDate != null ? src.BirthDate.Value.ToString("MMMM", System.Globalization.CultureInfo.InvariantCulture).ToLower() : null; }))
                .ForMember(dest => dest.Day, act => act.ResolveUsing(src => { return src.BirthDate != null ? src.BirthDate.Value.Day : (int?)null; }));

            CreateMap<StudiesDTO, Studies>()
                //.ForMember(dest => dest.StudyID, act => act.MapFrom(src => src.studyid))
                .ForMember(dest => dest.ID_Curriculum, act => act.UseValue(1))
                .ForMember(dest => dest.Curriculum, act => act.Ignore());

            CreateMap<Studies, StudiesDTO>();
            //.ForMember(dest => dest.studyid, act => act.MapFrom(src => src.StudyID));

            CreateMap<CertificatesDTO, Certificates>()
                .ForMember(dest => dest.ID_Curriculum, act => act.UseValue(1))
                .ForMember(dest => dest.Curriculum, act => act.Ignore());

            CreateMap<Certificates, CertificatesDTO>();

            CreateMap<WorkExperiencesDTO, WorkExperiences>()
                .ForMember(dest => dest.ID_Curriculum, act => act.UseValue(1))
                .ForMember(dest => dest.Curriculum, act => act.Ignore());

            CreateMap<WorkExperiences, WorkExperiencesDTO>();

            CreateMap<LanguagesDTO, Languages>()
                .ForMember(dest => dest.ID_Curriculum, act => act.UseValue(1))
                .ForMember(dest => dest.Curriculum, act => act.Ignore());

            CreateMap<Languages, LanguagesDTO>();

            CreateMap<SkillsDTO, Skills>()
                .ForMember(dest => dest.ID_Curriculum, act => act.UseValue(1))
                .ForMember(dest => dest.Curriculum, act => act.Ignore());

            CreateMap<Skills, SkillsDTO>();
        }

        private DateTime? GetBirthdateFromValues(int? year, string month, int? day)
        {
            try
            {
                if (year == 0 || month == Common.MonthOptions.None || day == 0)
                    return null;

                return Convert.ToDateTime(year + "-" + month + "-" + day);
            }
            catch
            {
                return null;
            }
        }
    }
}
