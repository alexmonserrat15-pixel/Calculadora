using Calculadora.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Calculadora.Application.Interfaces
{
    public interface IEnvioService
    {
        Task<EnvioResponseDto> CalcularTarifaAsync(EnvioRequestDto request);
        Task<IEnumerable<string>> GetPaisesAsync();
    }
}
