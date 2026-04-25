using Calculadora.Application.Dtos;
using Calculadora.Application.Interfaces;
using Calculadora.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Calculadora.Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public AuthService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<bool> ValidarCredencialesAsync(LoginRequestDto request)
        {
            var usuario = await _usuarioRepository.GetByUsuarioAsync(request.usuario);

            if (usuario == null)
                return false;

            // Comparación directa ya que la contraseña está en texto plano
            return usuario.password_hash == request.password;
        }
    }
}
