﻿using AutoMapper;
using CVBuilder.Data;
using CVBuilder.Services.DTOs;
using System;
using System.Collections.Generic;
using System.IO;
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
                .ForMember(dest => dest.Photo, act => act.MapFrom(src => src.UploadedPhoto))
                .ForMember(dest => dest.Curriculum, act => act.Ignore());

            CreateMap<PersonalDetails, PersonalDetailsDTO>()
                .ForMember(dest => dest.Photo, act => act.ResolveUsing(src => { return ByteArrayToBase64(src.Photo, src.MimeType); }));

            CreateMap<StudiesDTO, Studies>()
                .ForMember(dest => dest.Curriculum, act => act.Ignore());

            CreateMap<Studies, StudiesDTO>();

            CreateMap<CertificatesDTO, Certificates>()
                .ForMember(dest => dest.Curriculum, act => act.Ignore());

            CreateMap<Certificates, CertificatesDTO>();

            CreateMap<WorkExperiencesDTO, WorkExperiences>()
                .ForMember(dest => dest.Curriculum, act => act.Ignore());

            CreateMap<WorkExperiences, WorkExperiencesDTO>();

            CreateMap<LanguagesDTO, Languages>()
                .ForMember(dest => dest.Curriculum, act => act.Ignore());

            CreateMap<Languages, LanguagesDTO>();

            CreateMap<SkillsDTO, Skills>()
                .ForMember(dest => dest.Curriculum, act => act.Ignore());

            CreateMap<Skills, SkillsDTO>();

            CreateMap<InterestsDTO, Interests>()
                .ForMember(dest => dest.Curriculum, act => act.Ignore());

            CreateMap<Interests, InterestsDTO>();

            CreateMap<PersonalReferencesDTO, PersonalReferences>()
                .ForMember(dest => dest.Curriculum, act => act.Ignore());

            CreateMap<PersonalReferences, PersonalReferencesDTO>();

            CreateMap<CustomSectionsDTO, CustomSections>()
                .ForMember(dest => dest.Curriculum, act => act.Ignore());

            CreateMap<CustomSections, CustomSectionsDTO>();

            CreateMap<Templates, TemplatesDTO>();

            CreateMap<Curriculum, SectionVisibilityDTO>();
        }

        private string ByteArrayToBase64(byte[] file, string mimeType)
        {
            if (file != null && file.Length > 0)
                return String.Concat("data:", mimeType, ";base64,", Convert.ToBase64String(file));

            return null;
        }
    }
}
