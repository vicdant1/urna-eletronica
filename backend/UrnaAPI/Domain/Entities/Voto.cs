using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public sealed class Voto
    {
        public int Id { get; set; }
        public int? CandidatoId { get; set; }
        public Candidato? Candidato { get; set; }
        public DateTime DataVoto { get; set; }
    }
}
