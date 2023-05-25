using Microsoft.AspNetCore.Mvc;
using ChaveAutenticidadeSelos.Services.Interfaces;
using ChaveAutenticidadeTjRs.Core.Models;

namespace ChaveAutenticidadeSelos.Controllers
{
    [Route("[controller]")]
    public class ConsultarChaveAutenticidadeTJRsController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> ChaveAutenticidadeTj(
            [FromServices] IChaveAutenticidadeService _chaveAutenticidadeService,
            [FromQuery] List<string> chavesAutenticidade)
        {            
                var result = 
                        await _chaveAutenticidadeService.ObterDadosChaveAutenticidade(chavesAutenticidade);

                return result.Match<IActionResult>(Ok,
                            x => NotFound(Errors.ListaVazia),                    
                            y => BadRequest(Errors.ChaveInvalida),
                            w => BadRequest(Errors.ChaveNaoNumerica),
                            z => NotFound(Errors.ChaveNulla));                
        }
    }
}