using Application.DTOs;
using Application.IServices;
using Microsoft.AspNetCore.Mvc;

namespace UrnaWebAPI.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class CandidatosController : ControllerBase
    {
        private readonly ICandidatoService _candidatoService;
        public CandidatosController(ICandidatoService candidatoService)
        {
            _candidatoService = candidatoService;
        }

        [HttpPost("/candidate")]
        public async Task<IActionResult> CreateCandidato([FromBody]CreateCandidatoDTO candidatoDTO)
        {
            var candidato = await _candidatoService.CreateAsync(candidatoDTO);
            if(candidato != null)
                return Ok(candidato);

            return BadRequest();
        }

        [HttpDelete("/candidate")]
        public async Task<IActionResult> DeleteCandidato(int id)
        {
            var candidato = await _candidatoService.RemoveAsync(id);
            if (candidato != null)
                return Ok(candidato);

            return BadRequest();
        }

        [HttpGet("/votes")]
        public async Task<IActionResult> GetCandidatos()
        {
            var candidatos = await _candidatoService.GetCandidatosAsync();

            if (candidatos != null && candidatos.Count() > 0)
                return Ok(candidatos);

            return NotFound();
        }

        [HttpGet("/getCandidatoById")]
        public async Task<IActionResult> GetCandidatoById(int id)
        {
            var candidato = await _candidatoService.GetCandidatoByIdAsync(id);
            if (candidato != null)
                return Ok(candidato);

            return NotFound();
        }
    }
}
