using Calculadora.Application.Interfaces;
using Calculadora.Domain.Entities;
using Calculadora.MVC.Filters;
using Microsoft.AspNetCore.Mvc;

namespace Calculadora.MVC.Controllers
{
    [SessionAuthFilter]
    public class AdminController : Controller
    {
        private readonly ITasaService _tasaService;

        public AdminController(ITasaService tasaService)
        {
            _tasaService = tasaService;
        }

        // ── Listar todas las tasas ──
        public async Task<IActionResult> Index()
        {
            var tasas = await _tasaService.GetAllAsync();
            ViewBag.Usuario = HttpContext.Session.GetString("usuario");
            return View(tasas);
        }

        // ── Crear — formulario ──
        [HttpGet]
        public IActionResult Crear()
        {
            return View(new Tasa());
        }

        // ── Crear — guardar ──
        [HttpPost]
        public async Task<IActionResult> Crear(Tasa tasa)
        {
            if (string.IsNullOrEmpty(tasa.pais_nombre) || tasa.tarifa_usd <= 0)
            {
                ViewBag.Error = "Todos los campos son obligatorios y la tarifa debe ser mayor a 0.";
                return View(tasa);
            }

            await _tasaService.AddAsync(tasa);
            return RedirectToAction("Index");
        }

        // ── Editar — formulario ──
        [HttpGet]
        public async Task<IActionResult> Editar(int id)
        {
            var tasa = await _tasaService.GetByIdAsync(id);
            if (tasa == null) return NotFound();
            return View(tasa);
        }

        // ── Editar — guardar ──
        [HttpPost]
        public async Task<IActionResult> Editar(Tasa tasa)
        {
            if (string.IsNullOrEmpty(tasa.pais_nombre) || tasa.tarifa_usd <= 0)
            {
                ViewBag.Error = "Todos los campos son obligatorios y la tarifa debe ser mayor a 0.";
                return View(tasa);
            }

            await _tasaService.UpdateAsync(tasa);
            return RedirectToAction("Index");
        }

        // ── Eliminar ──
        [HttpPost]
        public async Task<IActionResult> Eliminar(int id)
        {
            await _tasaService.DeleteAsync(id);
            return RedirectToAction("Index");
        }
    }
}
