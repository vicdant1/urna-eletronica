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
            CreateMap<Candidato, GetCandidatoDTO>().ForMember(m => m.VotoAmount, opt =>
            {
                opt.MapFrom(x => x.Votos.Count());
            }).ReverseMap();
            CreateMap<Candidato, GetDetailedCandidatoDTO>().ForMember(m => m.VotoAmount, opt =>
            {
                opt.MapFrom(x => x.Votos.Count());
            }).ReverseMap();
            
            CreateMap<Voto, CreateVotoDTO>().ReverseMap();
        }
    }
}
