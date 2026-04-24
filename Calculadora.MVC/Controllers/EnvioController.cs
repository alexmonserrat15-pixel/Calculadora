using Microsoft.AspNetCore.Mvc;
using Calculadora.Application.Interfaces;
using Calculadora.Application.Dtos;
using Calculadora.MVC.Models;

namespace Calculadora.MVC.Controllers
{
    public class EnvioController : Controller
    {
        private readonly IEnvioService _envioService;

        public EnvioController(IEnvioService envioService)
        {
            _envioService = envioService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var paises = await _envioService.GetPaisesAsync();
            var model = new EnvioViewModel
            {
                Paises = paises.ToList()
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Index(EnvioViewModel model)
        {
            var paises = await _envioService.GetPaisesAsync();
            model.Paises = paises.ToList();

            if (model.peso <= 0)
            {
                ModelState.AddModelError("peso", "El peso debe ser mayor a cero.");
                return View(model);
            }

            var request = new EnvioRequestDto
            {
                pais_nombre = model.pais_nombre,
                peso = model.peso
            };

            var resultado = await _envioService.CalcularTarifaAsync(request);

            model.tarifa_usd = resultado.tarifa_usd;
            model.costo_total = resultado.costo_total;
            model.MostrarResultado = true;

            return View(model);
        }
    }
}
