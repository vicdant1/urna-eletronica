using Domain.Entities;

namespace Domain.IRepository
{
    public interface IVotoRepository
    {
        Task<Voto> CreateVoto(Voto voto);
        Task<Voto> UpdateVoto(Voto voto);
        int GetVotoAmount(int? candidatoId);
    }
}
