using Application.DTOs;
using AutoMapper;
using Domain.Entities;

namespace Application.Mapping
{
    public class UrnaMappingProfile : Profile
    {
        public UrnaMappingProfile()
        {
            CreateMap<Candidato, CreateCandidatoDTO>().ReverseMap();
            CreateMap<Candidato, GetCandidatoDTO>().ReverseMap();
            CreateMap<Candidato, GetDetailedCandidatoDTO>().ReverseMap();
            
            CreateMap<Voto, CreateVotoDTO>().ReverseMap();
        }
    }
}
