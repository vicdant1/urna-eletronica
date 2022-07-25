using Application.DTOs;
using Domain.Entities;

namespace Application.IServices
{
    public interface ICandidatoService
    {
        Task<IEnumerable<GetCandidatoDTO>> GetCandidatosAsync();
        Task<GetDetailedCandidatoDTO> GetCandidatoByIdAsync(int? id);
        Task<Candidato> CreateAsync(CreateCandidatoDTO createCandidatoDTO);
        Task<Candidato> RemoveAsync(int candidatoId);

    }
}
