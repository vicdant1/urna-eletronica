using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.IRepository
{
    public interface ICandidatoRepository
    {
        Task<IEnumerable<Candidato>> GetCandidatosAsync();
        Task<Candidato> GetCandidatoByIdAsync(int id);

        Task<Candidato> CreateAsync(Candidato candidato);
        Task<Candidato> UpdateAsync(Candidato candidato);
        Task<Candidato> RemoveAsync(Candidato candidato);

    }
}
