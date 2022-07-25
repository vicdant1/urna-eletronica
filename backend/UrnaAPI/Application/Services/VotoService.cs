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
        private readonly ICandidatoService _candidatoService;
        public VotoService(IMapper mapper, IVotoRepository votoRepository, ICandidatoService candidatoService)
        {
            _mapper = mapper;
            _votoRepository = votoRepository;
            _candidatoService = candidatoService;
        }
        public async Task<Voto> CreateVoto(CreateVotoDTO createVotoDTO)
        {
            var voto = _mapper.Map<Voto>(createVotoDTO);

            if (await _candidatoService.GetCandidatoByIdAsync(voto.CandidatoId) == null)
                voto.CandidatoId = null;

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
