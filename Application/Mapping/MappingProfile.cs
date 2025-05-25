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
            CreateMap<Moto, MotoDTO>()
                .ForMember(dest => dest.Setor, opt => opt.MapFrom(src => src.Setor))
                .ForMember(dest => dest.Cor, opt => opt.MapFrom(src => src.Cor))
                .ForMember(dest => dest.NomePatio, opt => opt.MapFrom(src => src.Patio.Nome))
                .ReverseMap();

            CreateMap<Patio, PatioDTO>().ReverseMap();

            CreateMap<UsuarioPatio, UsuarioPatioDTO>().ReverseMap();
        }
    }
}