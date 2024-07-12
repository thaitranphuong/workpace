using AutoMapper;
using DatabaseFirst.DTOs;
using DatabaseFirst.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatabaseFirst.Profiles
{
    public class ActorProfile : Profile
    {
        public ActorProfile()
        {
            CreateMap<Actor, ActorDTO>()
                .ForMember(dest => dest.ActorId, src => src.MapFrom(x =>x.ActorId))
                .ForMember(dest => dest.FirstName, src => src.MapFrom(x => x.FirstName))
                .ForMember(dest => dest.LastName, src => src.MapFrom(x => x.LastName))
                .ForMember(dest => dest.LastUpdate, src => src.MapFrom(x => x.LastUpdate));

            CreateMap<ActorDTO, Actor>()
                .ForMember(dest => dest.FirstName, src => src.MapFrom(x => x.FirstName))
                .ForMember(dest => dest.LastName, src => src.MapFrom(x => x.LastName));

        }
    }
}
