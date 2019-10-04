﻿using AutoMapper;
using CVBuilder.enums;
using CVBuilder.Services.DTOs;
using CVBuilder.ViewModels.Curriculum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CVBuilder.automapper
{
    public class MappingWebProfile : Profile
    {
        public MappingWebProfile()
        {
            CreateMap<PersonalDetailsViewModel, PersonalDetailsDTO>()
                .ForMember(dest => dest.SummaryIsVisible, act => act.UseValue(true));

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
    }
}