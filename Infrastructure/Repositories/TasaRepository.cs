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
        public async Task<Tasa> GetByIdAsync(int id)
        {
            return await _context.Tasas
                .FirstOrDefaultAsync(t => t.id == id);
        }

        public async Task AddAsync(Tasa tasa)
        {
            await _context.Tasas.AddAsync(tasa);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Tasa tasa)
        {
            _context.Tasas.Update(tasa);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var tasa = await GetByIdAsync(id);
            if (tasa != null)
            {
                _context.Tasas.Remove(tasa);
                await _context.SaveChangesAsync();
            }
        }
    }
}
