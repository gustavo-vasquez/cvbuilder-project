using AutoMapper;
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
                .ForMember(dest => dest.SummaryIsVisible, act => act.UseValue(true))
                .ForMember(dest => dest.UploadedPhoto, act => act.ResolveUsing(src => { return PostedFileToByteArray(src.UploadedPhoto); }))
                .ForMember(dest => dest.MimeType, act => act.ResolveUsing(src => { return src.UploadedPhoto.ContentType; }))
                .ForMember(dest => dest.Photo, act => act.Ignore());

            CreateMap<PersonalDetailsDTO, PersonalDetailsViewModel>()
                .ForMember(dest => dest.Type, act => act.UseValue(FormType.EDIT));

            CreateMap<StudiesViewModel, StudiesDTO>();

            CreateMap<StudiesDTO, StudiesViewModel>()
                .ForMember(dest => dest.Type, act => act.UseValue(FormType.EDIT));

            CreateMap<CertificatesViewModel, CertificatesDTO>();

            CreateMap<CertificatesDTO, CertificatesViewModel>()
                .ForMember(dest => dest.Type, act => act.UseValue(FormType.EDIT));

            CreateMap<WorkExperiencesViewModel, WorkExperiencesDTO>();

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
        }

        private byte[] PostedFileToByteArray(HttpPostedFileBase file)
        {
            if(file.ContentLength > 0)
            {
                MemoryStream ms = new MemoryStream();
                file.InputStream.CopyTo(ms);

                return ms.ToArray();
            }

            return null;
        }
    }
}