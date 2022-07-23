using Application.DTOs;
using Application.IServices;
using AutoMapper;
using Domain.Entities;
using Domain.IRepository;

namespace Application.Services
{
    public class VotoService : IVotoService
    {
        private readonly IMapper _mapper;
        private readonly IVotoRepository _votoRepository;
        public VotoService(IMapper mapper, IVotoRepository votoRepository)
        {
            _mapper = mapper;
            _votoRepository = votoRepository;
        }
        public async Task<Voto> CreateVoto(CreateVotoDTO createVotoDTO)
        {
            var voto = _mapper.Map<Voto>(createVotoDTO);

            if (voto.CandidatoId == 0) voto.CandidatoId = null;

            return await _votoRepository.CreateVoto(voto);
        }

        public int GetVotoAmount(int? candidatoId)
            => _votoRepository.GetVotoAmount(candidatoId);
        

        public NullVotesAmountDTO GetNullVotesAmount()
        {
            NullVotesAmountDTO nullVotesAmount = new NullVotesAmountDTO();
            nullVotesAmount.NullVotesAmount = _votoRepository.GetVotoAmount(null);

            return nullVotesAmount;
        }
    }
}
