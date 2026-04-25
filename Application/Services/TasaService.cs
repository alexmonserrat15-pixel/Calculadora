using Calculadora.Application.Interfaces;
using Calculadora.Domain.Entities;
using Calculadora.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Calculadora.Application.Services
{
    public class TasaService : ITasaService
    {
        private readonly ITasaRepository _tasaRepository;

        public TasaService(ITasaRepository tasaRepository)
        {
            _tasaRepository = tasaRepository;
        }

        public async Task<IEnumerable<Tasa>> GetAllAsync()
        {
            return await _tasaRepository.GetAllAsync();
        }

        public async Task<Tasa> GetByIdAsync(int id)
        {
            return await _tasaRepository.GetByIdAsync(id);
        }

        public async Task AddAsync(Tasa tasa)
        {
            await _tasaRepository.AddAsync(tasa);
        }

        public async Task UpdateAsync(Tasa tasa)
        {
            await _tasaRepository.UpdateAsync(tasa);
        }

        public async Task DeleteAsync(int id)
        {
            await _tasaRepository.DeleteAsync(id);
        }
    }
}
