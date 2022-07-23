using Domain.Entities;
using Domain.IRepository;
using Infra.Data.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Data.Repositories
{
    public class VotoRepository : IVotoRepository
    {
        private readonly AppDbContext _appDbContext;
        public VotoRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<Voto> CreateVoto(Voto voto)
        {
            _appDbContext.Add(voto);
            await _appDbContext.SaveChangesAsync();

            return voto;
        }

        public int GetVotoAmount(int? candidatoId)
        {
            return _appDbContext.Votos.Where(v => v.CandidatoId == candidatoId).Count();
        }

        public async Task<Voto> UpdateVoto(Voto voto)
        {
            _appDbContext.Update(voto);
            await _appDbContext.SaveChangesAsync();

            return voto;
        }
    }
}
