using Application.DTOs;
using Application.IServices;
using Microsoft.AspNetCore.Mvc;

namespace UrnaWebAPI.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class VotosController : ControllerBase
    {
        private readonly IVotoService _votoService;
        private readonly ICandidatoService _candidatoService;
        public VotosController(IVotoService votoService, ICandidatoService candidatoService)
        {
            _votoService = votoService;
            _candidatoService = candidatoService;
        }

        [HttpPost("/vote")]
        public async Task<IActionResult> CreateVoto(CreateVotoDTO createVotoDTO)
        {
            var voto = await _votoService.CreateVoto(createVotoDTO);

            if(voto != null)
                return Ok(voto);

            return BadRequest();
        }

        [HttpGet("/votes")]
        public async Task<IActionResult> GetCandidatos()
        {
            var candidatos = await _candidatoService.GetCandidatosAsync();

            if (candidatos != null)
                return Ok(candidatos);

            return NotFound();
        }

        [HttpGet("/getNullVotesAmount")]
        public IActionResult GetNullVotesAmount()
        {
            return Ok(_votoService.GetNullVotesAmount());
        }
    }
}
