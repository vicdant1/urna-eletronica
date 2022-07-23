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
        public VotosController(IVotoService votoService)
        {
            _votoService = votoService;
        }

        [HttpPost("/vote")]
        public async Task<IActionResult> CreateVoto(CreateVotoDTO createVotoDTO)
        {
            var voto = await _votoService.CreateVoto(createVotoDTO);

            if(voto != null)
                return Ok(voto);

            return BadRequest();
        }

        [HttpGet("/getNullVotes")]
        public IActionResult GetNullVotesAmount()
        {
            return Ok(_votoService.GetNullVotesAmount());
        }
    }
}
