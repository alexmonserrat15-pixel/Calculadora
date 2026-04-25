using Calculadora.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Calculadora.Application.Interfaces
{
    public interface IAuthService
    {
        Task<bool> ValidarCredencialesAsync(LoginRequestDto request);
    }
}
