using Calculadora.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Calculadora.Domain.Repository
{
    public interface ITasaRepository
    {
        Task<IEnumerable<Tasa>> GetAllAsync();
        Task<Tasa> GetByPaisNombreAsync(string paisNombre);
        Task<Tasa> GetByIdAsync(int id);       
        Task AddAsync(Tasa tasa);               
        Task UpdateAsync(Tasa tasa);            
        Task DeleteAsync(int id);
    }
}
