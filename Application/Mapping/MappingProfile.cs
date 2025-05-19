using Mottu.Application.DTOs;
using AutoMapper;
using Mottu.Domain.Entities;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Mottu.Application.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Moto, MotoDTO>().ReverseMap();
            CreateMap<Patio, PatioDTO>().ReverseMap();
        }
    }
}
