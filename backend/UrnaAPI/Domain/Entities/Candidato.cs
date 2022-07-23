using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public sealed class Candidato
    {
        public int Id { get; set; }
        public string NomeCompleto { get; set; }
        public string NomeVice { get; set; }
        public DateTime DataRegistro { get; set; }
        public Int32 Legenda { get; set; }

        public List<Voto> Votos { get; set; }
    }
}
