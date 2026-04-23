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
    }
}
