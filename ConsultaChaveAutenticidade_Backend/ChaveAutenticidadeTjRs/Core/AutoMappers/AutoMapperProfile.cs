using AutoMapper;
using ChaveAutenticidadeSelos.Core.Dto;
using ChaveAutenticidadeSelos.Core.Models;

namespace ChaveAutenticidadeSelos.Core.AutoMappers
{
    public class AutoMapperProfile : Profile
    {
        protected AutoMapperProfile()
        {
            CreateMap<DadosServentiaDto, DadosServentia>()
                .ReverseMap();
        }
    }
}