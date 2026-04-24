using Calculadora.Application.Dtos;
using Calculadora.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Calculadora.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EnvioController : ControllerBase
    {
        private readonly IEnvioService _envioService;

        public EnvioController(IEnvioService envioService)
        {
            _envioService = envioService;
        }

        [HttpGet("paises")]
        public async Task<IActionResult> GetPaises()
        {
            var paises = await _envioService.GetPaisesAsync();
            return Ok(paises);
        }

        [HttpPost("calcular")]
        public async Task<IActionResult> Calcular([FromBody] EnvioRequestDto request)
        {
            if (request.peso <= 0)
                return BadRequest("El peso debe ser mayor a cero.");

            var resultado = await _envioService.CalcularTarifaAsync(request);
            return Ok(resultado);
        }
    }
}
