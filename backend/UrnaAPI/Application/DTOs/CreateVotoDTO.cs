namespace Application.DTOs
{
    public class CreateVotoDTO
    {
        public int? CandidatoId { get; set; }

        public DateTime DataVoto = DateTime.Now;
    }
}
