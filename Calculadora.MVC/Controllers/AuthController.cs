using Calculadora.Application.Dtos;
using Calculadora.Application.Interfaces;
using Calculadora.MVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace Calculadora.MVC.Controllers
{
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpGet]
        public IActionResult Login()
        {
            // Si ya está logueado, redirige al panel
            if (HttpContext.Session.GetString("usuario") != null)
                return RedirectToAction("Index", "Admin");

            return View(new LoginViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            var request = new LoginRequestDto
            {
                usuario = model.usuario,
                password = model.password
            };

            var valido = await _authService.ValidarCredencialesAsync(request);

            if (!valido)
            {
                model.error = "Usuario o contraseña incorrectos.";
                return View(model);
            }

            HttpContext.Session.SetString("usuario", model.usuario);
            return RedirectToAction("Index", "Admin");
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
    }
}
