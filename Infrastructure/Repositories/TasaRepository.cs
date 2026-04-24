using Calculadora.Domain.Entities;
using Calculadora.Domain.Repository;
using Calculadora.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Calculadora.Infrastructure.Repositories
{
    public class TasaRepository : ITasaRepository
    {
        private readonly ApplicationDbContext _context;

        public TasaRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Tasa>> GetAllAsync()
        {
            return await _context.Tasas.ToListAsync<Tasa>();
        }

        public async Task<Tasa> GetByPaisNombreAsync(string paisNombre)
        {
            return await _context.Tasas
                .FirstOrDefaultAsync(t => t.pais_nombre == paisNombre);
        }
    }
}
