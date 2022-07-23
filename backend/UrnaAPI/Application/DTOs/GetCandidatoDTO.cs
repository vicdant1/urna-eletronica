namespace Application.DTOs
{
    public class GetCandidatoDTO
    {
        public int Id { get; set; }
        public string NomeCompleto { get; set; }
        public string NomeVice { get; set; }
        public Int32 Legenda { get; set; }
        public int VotoAmount { get; set; } = 0;
    }
}
