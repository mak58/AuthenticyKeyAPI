using Microsoft.AspNetCore.Mvc;
using ChaveAutenticidadeSelos.Core.Dto;
using ChaveAutenticidadeSelos.Services.Interfaces;

namespace ChaveAutenticidadeSelos.Controllers
{
    [Route("[controller]")]
    public class ChaveAutenticidadeTjController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<DadosServentiaDto>>> ConsultarChaveAutenticidadeTJRs(
            [FromServices] IChaveAutenticidadeService _chaveAutenticidadeService,
            [FromQuery] List<string> chavesAutenticidade)
        {
            var result =
                await _chaveAutenticidadeService.ObterDadosChaveAutenticidade(chavesAutenticidade);

            return Ok(result);
        }
    }
}