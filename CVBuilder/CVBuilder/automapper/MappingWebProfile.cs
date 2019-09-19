using AutoMapper;
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
            CreateMap<StudiesViewModel, StudiesDTO>();

            CreateMap<StudiesDTO, StudiesViewModel>()
                .ForMember(dest => dest.Type, act => act.UseValue(FormType.EDIT));
        }
    }
}