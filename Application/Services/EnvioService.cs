using Calculadora.Application.Dtos;
using Calculadora.Application.Interfaces;
using Calculadora.Domain.Factory;
using Calculadora.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Calculadora.Application.Services
{
    public class EnvioService : IEnvioService
    {
        private readonly ITasaRepository _tasaRepository;

        public EnvioService(ITasaRepository tasaRepository)
        {
            _tasaRepository = tasaRepository;
        }

        public async Task<EnvioResponseDto> CalcularTarifaAsync(EnvioRequestDto request)
        {
            var tasa = await _tasaRepository.GetByPaisNombreAsync(request.pais_nombre);

            if (tasa == null)
                throw new KeyNotFoundException($"No se encontró tarifa para: {request.pais_nombre}");

            // Delega el cálculo a la clase del país correspondiente
            var tarifa = TarifaFactory.Crear(request.pais_nombre);

            return new EnvioResponseDto
            {
                pais_nombre = tarifa.pais_nombre,
                peso = request.peso,
                tarifa_usd = tasa.tarifa_usd,
                costo_total = tarifa.CalcularCosto(request.peso)
            };
        }

        public async Task<IEnumerable<string>> GetPaisesAsync()
        {
            var tasas = await _tasaRepository.GetAllAsync();
            return tasas.Select(t => t.pais_nombre);
        }
    }

}
