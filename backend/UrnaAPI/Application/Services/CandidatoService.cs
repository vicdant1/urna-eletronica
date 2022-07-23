﻿using Application.DTOs;
using Application.IServices;
using AutoMapper;
using Domain.Entities;
using Domain.IRepository;

namespace Application.Services
{
    public class CandidatoService : ICandidatoService
    {
        private readonly IMapper _mapper;
        private readonly ICandidatoRepository _candidatoRepository;
        private readonly IVotoService _votoService;
        public CandidatoService(IMapper mapper, ICandidatoRepository candidatoRepository, IVotoService votoService)
        {
            _mapper = mapper;
            _candidatoRepository = candidatoRepository;
            _votoService = votoService;
        }

        public async Task<Candidato> CreateAsync(CreateCandidatoDTO createCandidatoDTO)
        {
            var candidato = _mapper.Map<Candidato>(createCandidatoDTO);
            return await _candidatoRepository.CreateAsync(candidato);
        }

        public async Task<GetDetailedCandidatoDTO> GetCandidatoByIdAsync(int id)
        {
            var candidato = await _candidatoRepository.GetCandidatoByIdAsync(id);
            var candidatoMapeado = _mapper.Map<GetDetailedCandidatoDTO>(candidato);

            return candidatoMapeado;
        }

        public async Task<IEnumerable<GetCandidatoDTO>> GetCandidatosAsync()
        {
            var candidatos = await _candidatoRepository.GetCandidatosAsync();
            var candidatoMapeados = _mapper.Map<IEnumerable<GetCandidatoDTO>>(candidatos);

            return candidatoMapeados.OrderByDescending(x => x.VotoAmount);
        }

        public async Task<Candidato> RemoveAsync(int candidatoId)
        {
            var candidato = await _candidatoRepository.GetCandidatoByIdAsync(candidatoId);
            if (candidato == null)
                throw new Exception("Candidato Not Found");

            return await _candidatoRepository.RemoveAsync(candidato);
        }
    }
}
