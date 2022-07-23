using Domain.Entities;
using Domain.IRepository;
using Infra.Data.DataContext;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data.Repositories
{
    public class CandidatoRepository : ICandidatoRepository
    {
        private readonly AppDbContext _appDbContext;
        public CandidatoRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<Candidato> CreateAsync(Candidato candidato)
        {
            _appDbContext.Add(candidato);
            await _appDbContext.SaveChangesAsync();

            return candidato;
        }

        public async Task<Candidato> GetCandidatoByIdAsync(int id)
            => await _appDbContext.Candidatos.Include(x => x.Votos).FirstOrDefaultAsync(x => x.Id == id);

        public async Task<IEnumerable<Candidato>> GetCandidatosAsync()
            => await _appDbContext.Candidatos.Include(x => x.Votos).ToListAsync();

        public async Task<Candidato> RemoveAsync(Candidato candidato)
        {
            _appDbContext.Remove(candidato);
            await _appDbContext.SaveChangesAsync();

            return candidato;
        }

        public async Task<Candidato> UpdateAsync(Candidato candidato)
        {
            _appDbContext.Update(candidato);
            await _appDbContext.SaveChangesAsync();

            return candidato;
        }
    }
}
