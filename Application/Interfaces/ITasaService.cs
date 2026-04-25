using Calculadora.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Calculadora.Application.Interfaces
{
    public interface ITasaService
    {
        Task<IEnumerable<Tasa>> GetAllAsync();
        Task<Tasa> GetByIdAsync(int id);
        Task AddAsync(Tasa tasa);
        Task UpdateAsync(Tasa tasa);
        Task DeleteAsync(int id);
    }
}
