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
            CreateMap<StudiesDTO, Studies>()
                .ForMember(dest => dest.ID_Curriculum, act => act.UseValue(1));
        }
    }
}
