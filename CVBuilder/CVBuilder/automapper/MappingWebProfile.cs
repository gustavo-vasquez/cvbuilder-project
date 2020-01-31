using AutoMapper;
using CVBuilder.Common;
using CVBuilder.enums;
using CVBuilder.Services.DTOs;
using CVBuilder.ViewModels.Curriculum;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace CVBuilder.automapper
{
    public class MappingWebProfile : Profile
    {
        public MappingWebProfile()
        {
            CreateMap<PersonalDetailsViewModel, PersonalDetailsDTO>()
                .ForMember(dest => dest.UploadedPhoto, act => act.ResolveUsing(src => { return PostedFileToByteArray(src.UploadedPhoto); }))
                .ForMember(dest => dest.MimeType, act => act.ResolveUsing(src => { return src.UploadedPhoto != null ? src.UploadedPhoto.ContentType : null; }))
                .ForMember(dest => dest.Photo, act => act.Ignore());

            CreateMap<PersonalDetailsDTO, PersonalDetailsViewModel>()
                .ForMember(dest => dest.Type, act => act.UseValue(FormType.EDIT));

            CreateMap<StudiesViewModel, StudiesDTO>()
                .ForMember(dest => dest.StartYear, act => act.ResolveUsing(src => { return (src.StartMonth == MonthOptions.NotShow) ? 0 : src.StartYear; }))
                .ForMember(dest => dest.EndYear, act => act.ResolveUsing(src => { return (src.EndMonth == MonthOptions.NotShow || src.EndMonth == MonthOptions.Present) ? 0 : src.EndYear; }));

            CreateMap<StudiesDTO, StudiesViewModel>()
                .ForMember(dest => dest.Type, act => act.UseValue(FormType.EDIT));

            CreateMap<CertificatesViewModel, CertificatesDTO>();

            CreateMap<CertificatesDTO, CertificatesViewModel>()
                .ForMember(dest => dest.Type, act => act.UseValue(FormType.EDIT));

            CreateMap<WorkExperiencesViewModel, WorkExperiencesDTO>()
                .ForMember(dest => dest.StartYear, act => act.ResolveUsing(src => { return (src.StartMonth == MonthOptions.NotShow) ? 0 : src.StartYear; }))
                .ForMember(dest => dest.EndYear, act => act.ResolveUsing(src => { return (src.EndMonth == MonthOptions.NotShow || src.EndMonth == MonthOptions.Present) ? 0 : src.EndYear; }));

            CreateMap<WorkExperiencesDTO, WorkExperiencesViewModel>()
                .ForMember(dest => dest.Type, act => act.UseValue(FormType.EDIT));

            CreateMap<LanguagesViewModel, LanguagesDTO>();

            CreateMap<LanguagesDTO, LanguagesViewModel>()
                .ForMember(dest => dest.Type, act => act.UseValue(FormType.EDIT));

            CreateMap<SkillsViewModel, SkillsDTO>();

            CreateMap<SkillsDTO, SkillsViewModel>()
                .ForMember(dest => dest.Type, act => act.UseValue(FormType.EDIT));

            CreateMap<InterestsViewModel, InterestsDTO>();

            CreateMap<InterestsDTO, InterestsViewModel>()
                .ForMember(dest => dest.Type, act => act.UseValue(FormType.EDIT));

            CreateMap<PersonalReferencesViewModel, PersonalReferencesDTO>();

            CreateMap<PersonalReferencesDTO, PersonalReferencesViewModel>()
                .ForMember(dest => dest.Type, act => act.UseValue(FormType.EDIT));

            CreateMap<CustomSectionsViewModel, CustomSectionsDTO>();

            CreateMap<CustomSectionsDTO, CustomSectionsViewModel>()
                .ForMember(dest => dest.Type, act => act.UseValue(FormType.EDIT));

            CreateMap<SummaryBlockDTO, SummaryBlockViewModel>();

            CreateMap<TemplatesDTO, FinishedViewModel>();

            CreateMap<PersonalDetailsDTO, PersonalDetailsDisplay>()
                .ForMember(dest => dest.Photo, act => act.ResolveUsing(src => { return src.Photo ?? CurriculumGlobals.DEFAULT_AVATAR_PATH; }))
                .ForMember(dest => dest.LinePhone, act => act.ResolveUsing(src => { return src.LinePhone != null && src.AreaCodeLP != null ? "(+" + src.AreaCodeLP + ") " + src.LinePhone : null; }))
                .ForMember(dest => dest.MobilePhone, act => act.ResolveUsing(src => { return src.MobilePhone != null && src.AreaCodeMP != null ? "(+" + src.AreaCodeMP + ") " + src.MobilePhone : null; }))
                .ForMember(dest => dest.Location, act => act.ResolveUsing(src => { return GenerateLocation(src.Address, src.City, src.Country, src.PostalCode); }));

            CreateMap<StudiesDTO, StudiesDisplay>()
                .ForMember(dest => dest.StateInTime, act => act.ResolveUsing(src => { return GenerateTimePeriodCV(src.StartMonth, src.StartYear, src.EndMonth, src.EndYear); }));

            CreateMap<WorkExperiencesDTO, WorkExperiencesDisplay>()
                .ForMember(dest => dest.StateInTime, act => act.ResolveUsing(src => { return GenerateTimePeriodCV(src.StartMonth, src.StartYear, src.EndMonth, src.EndYear); }));

            CreateMap<CertificatesDTO, CertificatesDisplay>();

            CreateMap<LanguagesDTO, LanguagesDisplay>();

            CreateMap<SkillsDTO, SkillsDisplay>();

            CreateMap<InterestsDTO, InterestsDisplay>();

            CreateMap<PersonalReferencesDTO, PersonalReferencesDisplay>()
                .ForMember(dest => dest.PhoneNumber, act => act.ResolveUsing(src => { return src.Telephone != null && src.AreaCode != null ? "(+" + src.AreaCode + ") " + src.Telephone : null; }));

            CreateMap<CustomSectionsDTO, CustomSectionsDisplay>();

            CreateMap<FinishedDTO, FinishedViewModel>();

            CreateMap<SectionVisibilityDTO, SectionVisibilityModel>();
        }

        private byte[] PostedFileToByteArray(HttpPostedFileBase file)
        {
            if(file != null && file.ContentLength > 0)
            {
                MemoryStream ms = new MemoryStream();
                file.InputStream.CopyTo(ms);

                return ms.ToArray();
            }

            return null;
        }

        private string GenerateLocation(string address, string city, string country, int? postalCode)
        {
            string location = string.Empty;

            if (address != null)
            {
                location = address;

                if (postalCode != null)
                    location += " (" + postalCode + ")";

                location += ", ";
            }   

            if (city != null)
                location += city;

            if (country != null)
                location += ", " + country;

            

            if (location == string.Empty)
                return null;
            else
                return location;
        }

        public string GenerateTimePeriodCV(string startMonth, int? startYear, string endMonth, int? endYear)
        {
            string timePeriod = CurriculumGlobals.GenerateStateInTimeFormat(startMonth, startYear, endMonth, endYear);

            return timePeriod.Substring(1, timePeriod.Length - 2);
        }
    }
}