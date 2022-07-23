
using System.ComponentModel.DataAnnotations;

namespace Application.DTOs
{
    public class CreateCandidatoDTO
    {
        [Required(ErrorMessage = "Por favor, informe o nome do candidato.")]
        public string NomeCompleto { get; set; }
        [Required(ErrorMessage = "Por favor, informe o nome do vice.")]
        public string NomeVice { get; set; }
        [Required(ErrorMessage = "Por favor, informe a legenda do candidato.")]
        public Int32 Legenda { get; set; }
        public DateTime DataRegistro = DateTime.Now;

    }
}
