using Application.DTOs;
using Domain.Entities;

namespace Application.IServices
{
    public interface IVotoService
    {
        Task<Voto> CreateVoto(CreateVotoDTO createVotoDTO);
        int GetVotoAmount(int? candidatoId);
        public NullVotesAmountDTO GetNullVotesAmount();
    }
}
