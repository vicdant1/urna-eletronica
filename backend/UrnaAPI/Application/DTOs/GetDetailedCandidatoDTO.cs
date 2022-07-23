
namespace Application.DTOs
{
    public class GetDetailedCandidatoDTO
    {
        public int Id { get; set; }
        public string NomeCompleto { get; set; }
        public string NomeVice { get; set; }
        public DateTime DataRegistro { get; set; }
        public Int32 Legenda { get; set; }
        public int VotoAmount { get; set; }
    }
}
